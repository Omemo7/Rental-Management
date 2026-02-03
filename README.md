# Rental Management System (Web API) 🏢

A robust, enterprise-grade **Backend Web API** designed to streamline the administration of rental properties. This solution handles the complete lifecycle of property management, from tenant onboarding to complex lease negotiations and maintenance workflows.

> **Note:** This repository is a pure **Backend** implementation. It exposes RESTful endpoints via **Swagger UI** and is designed to be consumed by web or mobile clients.

## 🏗 System Architecture

The solution follows **Clean Architecture** principles to ensure modularity and scalability:
* **Core:** Contains domain entities (Leases, Tenants, Buildings) and business rules.
* **Infrastructure:** Handles Entity Framework Core database contexts and migrations.
* **Presentation:** ASP.NET Core controllers exposing the API endpoints.

## 🔌 API Capabilities

Based on the exposed Swagger documentation, the system supports the following domains:

### 📜 Lease Management (Advanced)
Beyond simple creation, the system handles complex lease lifecycle events:
* **Lifecycle Actions:** Endpoints to `Terminate`, `Renew`, and check `IsActive` status.
* **Financial Adjustments:** dedicated endpoints to `IncreaseRent`, `ChangeDepositAmount`, and `ChangeRentPaymentFrequency`.

### 🛠 Maintenance System
A workflow-driven approach to property upkeep:
* **Scheduling:** Admins can `Schedule` requests and assign dates.
* **Completion:** specialized endpoints to mark requests as `Complete` and archive them.

### 🏢 Property & Tenancy
* **Hierarchy:** Manages relationships between **Buildings** and individual **Apartments**.
* **Tenant Profiles:** Secure management of tenant data and history.
* **Payments:** Tracking mechanism for rent collection and financial reporting.

## 🛠 Tech Stack

* **Framework:** .NET 6+ Web API
* **Language:** C#
* **Documentation:** Swagger / OpenAPI
* **Database:** SQL Server (Entity Framework Core)
* **Architecture:** Clean Architecture (N-Tier)
d navigate to `/swagger/index.html` to test the endpoints interactively.
