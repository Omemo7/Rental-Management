# Rental Management System 🏢

A robust, enterprise-grade **Backend API** designed to streamline the administration of rental properties. This solution handles the end-to-end lifecycle of property management, from tenant onboarding to maintenance request resolution.

> **Note:** This repository is a pure **Backend** implementation. It exposes RESTful API endpoints and manages business logic/data persistence. It is designed to be consumed by a separate frontend client (Web or Mobile).

## 🏗 System Architecture

This project is built using **Clean Architecture** to ensure separation of concerns, high testability, and scalability. The solution is strictly divided into three core layers:

* **Core (Business Layer):** Encapsulates the enterprise logic, entities, and service interfaces. It has zero external dependencies.
* **Infrastructure:** Manages data persistence, repository implementations, and external service integrations (e.g., Database contexts).
* **Presentation (API):** Handles HTTP requests, controllers, and response formatting, decoupled from the core business rules.

## 🚀 Key Features

* **Maintenance Request System:** A complete API workflow for submitting and tracking maintenance tickets (Pending → In Progress → Resolved).
* **Tenant & Lease Management:** Centralized handling of tenant profiles and lease agreements.
* **Property Administration:** Endpoints to manage unit availability and property details.
* **Repository Pattern:** Implements the Repository design pattern to abstract data access logic and ensure clean dependency injection.

## 🛠 Tech Stack

* **Language:** C#
* **Framework:** .NET 6+ / .NET Core
* **Architecture:** Clean Architecture (N-Tier)
* **Database:** Entity Framework Core (SQL Server)
