# Rental Management System (Web API) 🏢

A robust, enterprise-grade **Backend Web API** designed to streamline the administration of rental properties. This solution handles the complete lifecycle of property management, from tenant onboarding to complex lease negotiations and maintenance workflows.

> **Note:** This repository is a pure **Backend** implementation. It exposes RESTful endpoints via **Swagger UI** and is designed to be consumed by web or mobile clients.

## 🏗 System Architecture

The solution follows **Clean Architecture** principles to ensure modularity, testability, and scalability:
* **Core (Domain Layer):** Encapsulates the enterprise logic, entities (Leases, Tenants), and interfaces. It has zero external dependencies.
* **Infrastructure:** Manages data persistence, repository implementations, and database migrations.
* **Presentation:** ASP.NET Core controllers that handle API requests and response formatting.

## 🚀 Key Modules & Capabilities

### 📜 Advanced Lease Management
Unlike simple CRUD applications, this system handles complex business rules for lease lifecycles:
* **Lifecycle Workflows:** Logic to handle Lease Renewals, Early Terminations, and Status Validations.
* **Financial Adjustments:** dedicated workflows for processing Rent Increases, Deposit Adjustments, and changing Payment Frequencies during an active lease.

### 🛠 Maintenance Tracking
A complete workflow for property upkeep:
* **Ticket Management:** Capability to schedule, prioritize, and assign maintenance requests.
* **Resolution Workflow:** Tracks the status of requests from "Pending" to "Completed" and maintains a history of repairs.

### 🏢 Property & Tenancy
* **Hierarchical Management:** Manages relationships between Buildings and individual Apartments.
* **Tenant Profiles:** Secure handling of tenant personal data and leasing history.
* **Payment Processing:** Records rent collections and tracks outstanding balances.

## 🛠 Tech Stack

* **Framework:** .NET 6+ Web API
* **Language:** C#
* **Documentation:** Swagger / OpenAPI
* **Database:** SQL Server (Entity Framework Core)
* **Design Pattern:** Repository Pattern & Dependency Injection
n:**
    Launch the app and navigate to `/swagger/index.html` to interact with the endpoints.
