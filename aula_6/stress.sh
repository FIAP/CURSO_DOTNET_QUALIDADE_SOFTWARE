#!/bin/bash
for i in {1..10000}; do
  curl https://dotnet-redoc.onrender.com/WeatherForecast
  sleep $1
done
