# PhoneBook

This microservice application is a ASP.NET Core Web API application using Mongo DB NoSQL database connection on docker has Swagger implementation
Dockerfile implementation, has RabbitMQ to trigger event queue, for routing inside using Ocelot API Gateway 

##How to Run The Project
###Enviorement:Visual Studio 2019,.Net Core 3.1 or later, Docker Desktop

###Open Docker Desktop and run this command bellow:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up –d

Microservices  urls:

RabbitMQ -> http://localhost:15672/
PhoneBook API -> http://localhost:8000/swagger/index.html
Report API -> http://localhost:8001/swagger/index.html
API Gateway -> http://localhost:7000/Order?username=swn
