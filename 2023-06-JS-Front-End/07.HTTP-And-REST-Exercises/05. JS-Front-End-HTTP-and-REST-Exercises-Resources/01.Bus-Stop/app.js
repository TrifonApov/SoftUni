function getInfo() {
    const id = document.querySelector("#stopId").value;
    const list = document.querySelector("#buses");
    const stopName = document.querySelector("#stopName");

    list.innerHTML = "";
    
    fetch(`http://localhost:3030/jsonstore/bus/businfo/${id}`)
        .then((res) => res.json())
        .then((busStop) => {


            Object.entries(busStop.buses).map(([busNumber, timeInMinutes]) => {
                stopName.textContent = busStop.name;

                const item = document.createElement("li");
                item.textContent = `Bus ${busNumber} arrives in ${timeInMinutes} minutes`;

                list.appendChild(item);
            });
        })
        .catch(() => {
            stopName.textContent = "Error";
        });
}