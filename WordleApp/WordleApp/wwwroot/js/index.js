let index;

getWordCount();

document.getElementById('guess').addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        checkWord();
    }
});

document.getElementById('guess').addEventListener('keyup', function (e) {
    // See how many words there are.
    showPossibleWordCount(document.getElementById('guess').value);
});


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
                let html = "<div><h3>";
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
                html += "</h3></div>";
                let element = document.getElementById("result");
                console.log(html);
                element.innerHTML += html;
                if (response.data.winner) {
                    message = "You got it!";
                } else {
                    message = "Guess again";
                }
            } else {
                message = response.data.message;
            }
            let element = document.getElementById("message");
            element.innerText = message;
            // Clear the last word
            document.getElementById('guess').value = "";
        });
}

function showPossibleWordCount(guess, otherLetters) {
    axios.get('/api/wordle/PossibleWords', { params: { correctLetters: guess, otherLetters: otherLetters } })
        .then(response => {
            console.log(`${guess} with ${otherLetters}': ${response.data}`);
            if (response.data === 1) {
                document.getElementById("words").innerText = `${response.data} word`;
            } else {
                document.getElementById("words").innerText = `${response.data} words`;
            }
        });
}