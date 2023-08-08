function attachEvents() {
    const button = document.querySelector("#submit");
    button.addEventListener("click", getWeather);
    
    let locations;
    
    fetch(`http://localhost:3030/jsonstore/forecaster/locations`)
    .then((res) => res.json())
    .then(locationsInfo => {
        locations = locationsInfo
    })
    .catch(error => {
        console.log(error);
        return;
    });
    
    function getWeather() {
        const request = document.querySelector("#location");
        const requestedLocation = locations.filter(location => location.name.toLowerCase() === request.value.toLowerCase())[0];
        
        getTodayForecast(requestedLocation);
        getUpcomingForecast(requestedLocation);
    }
    
    function getSymbol(str) {
        switch (str.toLowerCase()) {
            case 'sunny': return '&#x2600;';
            case 'partly sunny': return '&#x26C5;';
            case 'overcast': return '&#x2601;';
            case 'rain': return '&#x2614;';
            case 'degrees': return '&deg;';
        }
    }

    function getTodayForecast(location) {
        document.querySelector("#forecast").style = '';
        const currentDiv = document.querySelector("#current");
        
        if(currentDiv.childElementCount > 1) {
            currentDiv.lastChild.remove();
        }

        const forecastBox = document.createElement("div");
        forecastBox.classList.add("forecasts");
        currentDiv.appendChild(forecastBox);
        

        // name: locationName,
        // forecast: { low: temp, high: temp, condition: condition }

        fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
            .then((res) => res.json())
            .then(currentCityInfo => {
                const symbol = document.createElement("span");
                symbol.classList.add("condition");
                symbol.classList.add("symbol");
                symbol.innerHTML = getSymbol(currentCityInfo.forecast.condition);
                forecastBox.appendChild(symbol);
                
                const conditionBox = document.createElement("span");
                conditionBox.classList.add("condition");
                forecastBox.appendChild(conditionBox);
                
                const cityName = document.createElement("span");
                cityName.classList.add("forecast-data");
                cityName.innerHTML = currentCityInfo.name;
                
                const temperature = document.createElement("span");
                temperature.classList.add("forecast-data");
                
                temperature.innerHTML = `${currentCityInfo.forecast.low}${getSymbol('Degrees')}/${currentCityInfo.forecast.high}${getSymbol('Degrees')}`;

                const conditionText = document.createElement("span");
                conditionText.classList.add("forecast-data");
                conditionText.innerHTML = currentCityInfo.forecast.condition;

                conditionBox.appendChild(cityName);
                conditionBox.appendChild(temperature);
                conditionBox.appendChild(conditionText);

            })
    }

    async function getUpcomingForecast(location) {
        try {
            const response = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`);
            const locationInfo = await response.json();
            
            const container = document.querySelector("#upcoming");
            const forecastInfo = document.createElement("div")
            forecastInfo.classList.add("forecast-info");
            container.appendChild(forecastInfo);

            
            locationInfo.forecast.forEach(day => {
                const upcomingContainer = document.createElement("span");
                upcomingContainer.classList.add("upcoming");
                forecastInfo.appendChild(upcomingContainer);
                debugger;
                const symbol = document.createElement("span");
                symbol.classList.add("symbol");
                symbol.innerHTML = `${getSymbol(day.condition)}`;
                upcomingContainer.appendChild(symbol);
                
                const forecastData = document.createElement("span");
                forecastData.classList("forecast-data");
                forecastData.innerHTML = `${day.low}${getSymbol('degrees')}/${day.high}${getSymbol('degrees')}`;
                upcomingContainer.appendChild(forecastData);
            });

        } catch (err) {}
    }

}

attachEvents();