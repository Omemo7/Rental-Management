# Rental Management System 🏢

A robust, enterprise-grade application designed to streamline the administration of rental properties. This solution handles the end-to-end lifecycle of property management, from tenant onboarding to maintenance request resolution.

## 🏗 System Architecture

This project is built using **Clean Architecture** to ensure separation of concerns, high testability, and scalability. The solution is strictly divided into three core layers:

* **Core (Business Layer):** Encapsulates the enterprise logic, entities, and service interfaces. It has zero external dependencies.
* **Infrastructure:** Manages data persistence, repository implementations, and external service integrations (e.g., Database contexts).
* **Presentation:** Handles the API endpoints and user interaction logic, decoupled from the core business rules.

## 🚀 Key Features

* **Maintenance Request System:** A complete workflow for tenants to submit maintenance tickets and for admins to track status changes (Pending → In Progress → Resolved).
* **Tenant & Lease Management:** centralized handling of tenant profiles and lease agreements.
* **Property Administration:** Tools to manage unit availability and property details.
* **Repository Pattern:** Implements the Repository design pattern to abstract data access logic and ensure clean dependency injection.

## 🛠 Tech Stack

* **Language:** C#
* **Framework:** .NET 6+ / .NET Core
* **Architecture:** Clean Architecture (N-Tier)
* **Database:** Entity Framework Core (SQL Server)
