use std::iter::Map;
use serde::Deserialize;

#[derive(Debug, Deserialize)]
struct Todo {
    weatherForecast: Vec<InsideMap>,
}
#[derive(Debug, Deserialize)]
struct InsideMap {
    forecastDate: String,
    forecastMaxtemp: Temp,
    forecastMintemp: Temp,
    PSR: String,
}
#[derive(Debug, Deserialize)]
struct Temp {
    value: f64,
    unit: String,
}

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>> {
    let url = "https://data.weather.gov.hk/weatherAPI/opendata/weather.php?dataType=fnd&lang=tc";
    let todo: Todo = reqwest::get(url)
        .await?
        .json()
        .await?;

    let res = todo.weatherForecast;
    for happy in res {
        print!("日期: {}", happy.forecastDate);
        print!(" 溫度: {}{}{}", happy.forecastMintemp.value, "-", happy.forecastMaxtemp.value);
        println!(" 下雨機率: {}", happy.PSR)
    }
    Ok(())
}