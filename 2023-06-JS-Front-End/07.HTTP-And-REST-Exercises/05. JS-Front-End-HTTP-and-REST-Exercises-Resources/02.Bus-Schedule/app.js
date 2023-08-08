function solve() {   
    const infoBox = document.querySelector("#info .info");
    const departBtn = document.querySelector("#depart");
    const arriveBtn = document.querySelector("#arrive");
    let bus = {
        name: '',
        next: 'depot'
    };

    function depart() {
        departBtn.disabled = true;
        arriveBtn.disabled = false;
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${bus.next}`)
        .then((res) => res.json())
        .then(stopInfo => {
            bus = stopInfo;
            infoBox.textContent = `Next stop ${bus.name}`;
        })
        .catch();
    }

    async function arrive() {
        departBtn.disabled = false;
        arriveBtn.disabled = true;
        infoBox.textContent = `Arriving at ${bus.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();