    var inputval = document.querySelector('#cityinput')
    var btn = document.querySelector('#add');
    var city = document.querySelector('#cityoutput')
    var country = document.querySelector('#country')
    var descrip = document.querySelector('#description')
    var humidity = document.querySelector('#humidity')
    var temp = document.querySelector('#temp')
    var tempfeelslike = document.querySelector('#tempfeelslike')
    var tempmax = document.querySelector('#tempmax')
    var tempmin = document.querySelector('#tempmin')
    var wind = document.querySelector('#wind')
    var winddir = document.querySelector('#winddirection')
    var airpre = document.querySelector('#pressure')

    apik = "d9663da104dbbce4e707c54f37bbd603"

    function convertion(val){
    return (val - 273).toFixed(1)
    }

    btn.addEventListener('click', function(){  
//This is the api link from where all the information will be collected
        fetch('https://api.openweathermap.org/data/2.5/weather?q='+inputval.value+'&appid='+apik)
        .then(res => res.json())
        //.then(data => console.log(data))
        .then(data => {
//To collect the necessary information with the API link. Now I will collect that information and store it in different constants.
            var nameval = data['name']
            var countryval = data['sys']['country']
            var desc = data['weather']['0']['description']
            var hum = data['main']['humidity']
            var temparature = data['main']['temp']
            var temparatureFeelslike = data['main']['feels_like']
            var temparaturemax = data['main']['temp_max']
            var temparaturemin = data['main']['temp_min']
            var windspd = data['wind']['speed']
            var winddirec = data['wind']['deg']
            var airpressure = data['main']['pressure']

//with the help of innerHTML you have to make arrangements to display all the information in the webpage.
            city.innerHTML=`Weather of <span>${nameval},${countryval}<span>`
            temp.innerHTML = `Temperature: <span>${ convertion(temparature)}°C</span>`
            tempfeelslike.innerHTML = `Temperature Feels Like: <span>${ convertion(temparatureFeelslike)}°C</span>`
            tempmax.innerHTML = `Temperature Max: <span>${ convertion(temparaturemax)}°C</span>`
            tempmin.innerHTML = `Temperature Max: <span>${ convertion(temparaturemin)}°C</span>`
            description.innerHTML = `Cloud Cover Conditions: <span>${desc}<span>`
            humidity.innerHTML = `Humidity: <span>${hum}%<span>`
            wind.innerHTML = `Wind Speed: <span>${windspd}km/h<span>`
            winddirection.innerHTML = `Wind Direction: <span>${winddirec}°</span>`
            pressure.innerHTML = `Air Pressure: <span>${airpressure}hPa<span>`
            document.getElementById('icon').src = "http://openweathermap.org/img/w/" + data.weather[0].icon + ".png"
        })

        .catch(err => alert('You entered Wrong city name'))
    })