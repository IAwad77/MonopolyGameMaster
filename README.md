## Monopoly Game Master

Monopoly Game Master is a full-stack application that acts as the banker, rule enforcer, and game manager for a digital version of Monopoly. It uses a microservice architecture, a React frontend, a centralized API gateway, and full CI/CD with Docker and Kubernetes orchestration.



## This is an ongoing project that is actively maintained and improved. New features, refinements, and expanded test coverage are regularly added as part of continuous learning and development.



## What It Does
Manages players, turn order, bank balances, and property ownership

Allows users to register, log in, and take turns through a clean React interface

Parses CSV files (player lists, properties, etc.) and converts them into usable models

Generates secure JWT tokens for authenticated actions

Connects backend microservices through a centralized .NET API Gateway

Runs in containers using Docker and Kubernetes for scalable deployment



## Project Structure

MonopolyGameMaster

 backend

  -PlayerService – handles player data

  -BankService – tracks in-game money

  -PropertyService – manages properties (buying, selling, renting)

  -GameLogicService – manages player turns using a queue

  -AuthService – handles login and JWT generation

  -FileParserService – parses uploaded CSV files

 gateway – YARP-based .NET API Gateway

 frontend – React app for user interaction

 tests – unit, integration, BDD, Selenium tests

 k8s – Kubernetes deployment files

 docker-compose.yml – local orchestration setup



## Tools and Technologies
Backend: C Sharp, .NET 8, REST APIs, YARP

Frontend: React 18, Axios, React Router

Auth: JWT token handling

Testing: xUnit, Moq, SpecFlow for BDD, Selenium WebDriver

DevOps: Docker, Docker Compose, Kubernetes, GitHub Actions for CI and CD



## Testing Coverage
Unit tests for each service and model logic

Controller tests using mocks and dependency injection

Integration tests using WebApplicationFactory

BDD tests written in Gherkin with full step definitions

Selenium tests for UI validation and simulated browser interaction



## Why I Love This Project

Monopoly Game Master is a hands-on demonstration of how real-world software systems are designed. It includes authentication, microservices, frontend interaction, testing automation, and containerized deployment. It brings together everything I have learned from school, internships, and independent development into one fun and technically rich challenge.
