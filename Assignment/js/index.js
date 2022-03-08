let menu_button = document.querySelector('.menu_button');
let button_list = document.querySelector('.button_list');
menu_button.addEventListener("click",()=>{
    button_list.classList.toggle('button_list_click');
});

function displayJoke(data) {
    const jokeData = data;

    var type = jokeData.type;

    if (type == 'single') {
        // joke is a one-liner
        var jokeLine1Div = document.getElementById('joke-line-1');
        const heading = document.createElement("p");
        heading.innerHTML = jokeData.joke;
        jokeLine1Div.appendChild(heading);
    }
    if (type == 'twopart') {
        // joke with setup and delivery
        var jokeLine1Div = document.getElementById('joke-line-1');
        const heading = document.createElement("p");
        heading.innerHTML = jokeData.setup;
        jokeLine1Div.appendChild(heading);

        var jokeLine2Div = document.getElementById('joke-line-2');
        const heading2 = document.createElement("p");
        heading2.innerHTML = jokeData.delivery;
        jokeLine2Div.appendChild(heading2);
    }
}

function makeGetRequest() {
    axios.get('https://v2.jokeapi.dev/joke/Programming').then(
        (response) => {
            var result = response.data;
            //console.log(result);
            displayJoke(result);
        },
        (error) => {
            console.log(error);
        }
    );
}

makeGetRequest();

function clearJokeCard() {
    document.getElementById('joke-line-1').innerHTML = "";
    document.getElementById('joke-line-2').innerHTML = "";
}

let another_joke_button = document.querySelector('.another_joke');
another_joke_button.addEventListener("click", () => {
    clearJokeCard();
    makeGetRequest();
})