let menu_button = document.querySelector('.menu_button');
let button_list = document.querySelector('.button_list');
menu_button.addEventListener("click",()=>{
    button_list.classList.toggle('button_list_click');
});

function displayJoke(data) {
    const jokeData = data;

    var type = jokeData.type;

    if (typeof (type) == 'single') {
        // joke is a one-liner
        var jokeLine1Div = document.getElementById('joke-card');
        const heading = document.createElement("h1");
        heading.innerHTML = jokeData.joke;
        jokeLine1Div.appendChild(heading);
    }
    if (typeof (type) == 'twopart') {
        // joke with setup and delivery
        var jokeLine1Div = document.getElementById('joke-card');
        const heading = document.createElement("h1");
        heading.innerHTML = jokeData.setup;
        jokeLine1Div.appendChild(heading);
    }
}

function makeGetRequest() {
    axios.get('https://v2.jokeapi.dev/joke/Programming').then(
        (response) => {
            var result = response.data;
            console.log(result);
            displayJoke(result);
        },
        (error) => {
            console.log(error);
        }
    );
}

makeGetRequest();