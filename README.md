# react-asp-net-core-phonebook
.Net Core Microservices with MongoDb and React client app

## Features:

- Microservices architecture

- Api gateway with Service Bus

- Message broker for async processing

- Command pattern for Commands + Events

- React client app

- Swagger Api UI

## Tech stack

### Back-end

- MongoDb with C# driver
- RabbitMq
- Asp.net Core WebApi


### Front-end

- Nodejs
- React client app
- Sass pipeline

## Prerequisite

Install Docker. Go to https://www.docker.com/products/docker-desktop

## Install
```sh
$ docker run -p 5672:5672 rabbitmq
$ docker run -d -p 27017:27017 mongo
```

## Run
```sh
$ dotnet run -p phonebook.services.entry/phonebook.services.entry.csproj
```
- Go to https://localhost:5051/index.html
```sh
$ dotnet run -p phonebook.api/phonebook.api.csproj
```
- Go to https://localhost:5001/swagger/index.html
```sh
$ cd phonebook.api/client && npm i && npm start
```
- Go to http://127.0.0.1:8080

## Notes

- If you encounter the 'connection is not private' browser error message, please proceed to localhost(unsafe) to view swagger page or microservice page.

