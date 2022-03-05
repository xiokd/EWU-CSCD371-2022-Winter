let index;

getWordCount();

function getWordCount() {
    axios.get('/api/wordle/WordCount')
        .then(response => {
            let max = response.data;
            let randomIndex = Math.floor(Math.random() * max);
            console.log(randomIndex);
            index = randomIndex;
        })
}

function checkWord() {
    let guess = document.getElementById("guess").value;
    console.log(guess);

    axios.post('/api/wordle/guess', { MyGuess: guess, WordIndex: index })
        .then(response => {
            console.log(response);
            let message = "";
            if (response.data.isValidGuess) {
                let html = "<div>";
                for (let character of response.data.data) {
                    if (character.state === 0) {
                        // Wrong letter
                        html += `<span class="badge bg-secondary">${character.character}</span>`;
                    } else if (character.state === 1) {
                        // Right letter wrong place
                        html += `<span class="badge bg-info">${character.character}</span>`;
                    } else if (character.state === 2) {
                        // Right letter right place
                        html += `<span class="badge bg-success">${character.character}</span>`;
                    }
                }
                html += "</div>";
                let element = document.getElementById("result");
                console.log(html);
                element.innerHTML += html;
                message = "Guess again";
            } else {
                message = response.data.message;
            }
            let element = document.getElementById("message");
            element.innerText = message;

        });
}