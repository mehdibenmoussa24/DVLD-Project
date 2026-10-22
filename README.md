# DVLD — Driving & Vehicle License Department

A C# Windows Forms desktop application for managing people, users, driving license applications, driving tests, and local and international driving licenses.

## Overview

**DVLD** is a database-driven desktop application that simulates the core operations of a Driving & Vehicle License Department. It brings together people management, application processing, test scheduling, driver registration, and license lifecycle management in one system.

The project applies Object-Oriented Programming (OOP), a three-tier architecture, ADO.NET, and Microsoft SQL Server to organize business workflows and separate application responsibilities.

## Features

### People Management
- Add, update, view, and manage people records.
- Search and filter people.
- Display person details using reusable UserControls.

### User Management
- Create and update user accounts.
- View user information.
- Change user passwords.
- Authenticate users through a login form.
- Remember login credentials using the Windows Registry.

### Application Management
- Manage application types.
- Create and manage local driving license applications.
- View application details and related information.

### Driving Tests
- Manage test types.
- Schedule test appointments.
- Record attendance and test results.
- Support test retakes.
- Validate appointments and test-related business rules.
- Manage vision, written, and practical driving tests.

### Driver and License Management
- Manage driver records.
- Issue local driving licenses for the first time.
- View driver license information and license history.
- Renew local driving licenses.
- Replace lost or damaged licenses.
- Detain and release licenses.
- Issue and manage international driving licenses.
- Apply eligibility checks and prevent duplicate operations where implemented.

### Account Settings
- View account information.
- Change passwords.
- Sign out of the application.

## Technologies

| Technology | Purpose |
|---|---|
| C# | Application and business logic |
| .NET Framework 4.7.2 | Application framework |
| Windows Forms (WinForms) | Desktop user interface |
| Microsoft SQL Server | Relational database |
| ADO.NET | Database connectivity and data access |
| SQL | Database queries and data manipulation |
| Visual Studio | Development environment |
| Git and GitHub | Version control and source code hosting |

## Architecture

The application follows a **Three-Tier Architecture**, separating the presentation layer, business logic layer, and data access layer.

```text
+----------------------------------+
|       Presentation Layer         |
|              DVLD                |
|       Windows Forms (UI)         |
+----------------------------------+
                 |
                 v
+----------------------------------+
|         Business Layer           |
|          DVLD.Business           |
|      Business Rules and Logic    |
+----------------------------------+
                 |
                 v
+----------------------------------+
|        Data Access Layer         |
|         DVLD.DataAccess          |
|       ADO.NET / SQL Server       |
+----------------------------------+
                 |
                 v
+----------------------------------+
|       Microsoft SQL Server       |
|        Relational Database       |
+----------------------------------+
```

### Layer Responsibilities

**Presentation Layer — `DVLD`**
- Contains Windows Forms and reusable UserControls.
- Handles user interaction and displays information.
- Calls business-layer functionality.

**Business Logic Layer — `DVLD.Business`**
- Contains business entities and application logic.
- Coordinates operations between the UI and data access layers.
- Applies validation and business rules for application and licensing workflows.

**Data Access Layer — `DVLD.DataAccess`**
- Communicates with SQL Server using ADO.NET.
- Executes database queries and data manipulation operations.
- Provides database access functionality to the business layer.

This separation improves code organization, maintainability, and extensibility.

## Database

The application uses Microsoft SQL Server to store and manage its data.

The database includes the following **14 tables**:

| Category | Tables |
|---|---|
| People and Users | `People`, `Users`, `Countries` |
| Applications | `Applications`, `ApplicationTypes`, `LocalDrivingLicenseApplications` |
| Drivers and Licenses | `Drivers`, `LicenseClasses`, `Licenses`, `InternationalLicenses`, `DetainedLicenses` |
| Tests | `TestTypes`, `TestAppointments`, `Tests` |

These tables support applicant registration, application processing, test scheduling, driver management, and license issuance and administration.

### Database Setup

The database must be created and populated with the required schema and initial data before running the application.

See the [Getting Started](#getting-started) section for setup instructions.

## Getting Started

### Prerequisites

- Windows.
- Visual Studio with support for .NET Framework 4.7.2 development.
- Microsoft SQL Server.
- SQL Server Management Studio (SSMS), or another compatible SQL Server management tool.

### 1. Clone the Repository

```bash
git clone https://github.com/mehdibenmoussa24/DVLD-Project.git
cd DVLD-Project
```

### 2. Set Up the Database

1. Open SQL Server Management Studio.
2. Connect to your SQL Server instance.
3. Execute the database creation script to create the database and its tables.
4. Ensure that the required initial data is available.

> The database script is comming soon.

### 3. Configure the Connection String

Locate the `DataAccessSettings` class in the `DVLD.DataAccess` project and configure the connection string for your SQL Server instance.

Example using Windows Authentication:

```text
Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;
```

Replace `YOUR_SERVER` and `YOUR_DATABASE` with your local SQL Server instance and database name. Keep the format consistent with the connection string expected by the project.

### 4. Open the Solution

Open `DVLD.slnx` in a compatible version of Visual Studio.

### 5. Build and Run

1. Restore any required project dependencies.
2. Build the solution.
3. Verify that the database connection is configured correctly.
4. Set `DVLD` as the startup project if necessary.
5. Run the application and sign in with a valid user account configured in the database.

**Security note:** Do not commit personal credentials or production connection strings to a public repository.

## Project Structure

The solution is organized into the following main projects:

```text
DVLD-Project/
├── DVLD/
│   ├── Forms
│   ├── UserControls
│   ├── Resources
│   └── Application UI
├── DVLD.Business/
│   ├── Business Entities
│   ├── Business Logic
│   └── Validation
├── DVLD.DataAccess/
│   ├── Data Access Classes
│   ├── SQL Server Operations
│   └── Connection Settings
├── Common/
│   └── Shared Utilities and Logging
├── DVLD.slnx
└── README.md
```

*This is a conceptual overview. The exact folder structure may vary from the representation above.*

## Screenshots

<img width="827" height="546" alt="Screenshot 2026-10-22 192842" src="https://github.com/user-attachments/assets/12a3b60b-e13b-40c0-9b4b-9b50d6013c5c" />
<img width="1442" height="981" alt="Screenshot 2026-10-22 193001" src="https://github.com/user-attachments/assets/b3da41b2-bac7-46da-aa94-425aec655a43" />
<img width="1496" height="770" alt="Screenshot 2026-10-22 193045" src="https://github.com/user-attachments/assets/efd9b543-4a82-4edb-ab93-64e9440f4365" />
<img width="891" height="745" alt="Screenshot 2026-10-22 193130" src="https://github.com/user-attachments/assets/d6de8645-e24b-47c2-85b8-092245feda50" />
<img width="1412" height="738" alt="Screenshot 2026-10-22 193205" src="https://github.com/user-attachments/assets/40683add-ce1e-4fa7-806a-816034adccda" />
<img width="891" height="957" alt="Screenshot 2026-10-22 203011" src="https://github.com/user-attachments/assets/aa9c7202-97e2-4ce2-a7f3-3c713e3b6f91" />
<img width="1101" height="732" alt="Screenshot 2026-10-22 203046" src="https://github.com/user-attachments/assets/6df1c017-087a-4030-b764-575d267a88e8" />
<img width="1136" height="813" alt="Screenshot 2026-10-22 203108" src="https://github.com/user-attachments/assets/6230acb6-11ed-4fb2-bbed-01be8949c16f" />
<img width="692" height="668" alt="Screenshot 2026-10-22 203130" src="https://github.com/user-attachments/assets/91b138dc-f1b6-4ab4-aae3-4a20b40d2892" />
<img width="1071" height="732" alt="Screenshot 2026-10-22 203157" src="https://github.com/user-attachments/assets/b649754b-3e68-4af5-a457-05ba7817a14d" />
<img width="1118" height="867" alt="Screenshot 2026-10-22 203225" src="https://github.com/user-attachments/assets/0ef15537-ced3-4596-a861-1c887f58b0c4" />




## Key Development Concepts

- Object-Oriented Programming (OOP) in C#.
- Three-tier application architecture.
- Separation of concerns.
- Reusable Windows Forms UserControls.
- ADO.NET database operations.
- SQL Server integration.
- CRUD operations and data validation.
- Business-rule implementation.
- Application and license lifecycle workflows.
- Git branching, commits, and pull requests.
- Error logging through the Windows Event Log.

## Future Improvements

- Automated unit and integration testing.
- More centralized application configuration.
- Further authentication and credential-security improvements.
- More comprehensive logging and exception handling.
- Additional reporting and search capabilities.
- Further user interface and usability enhancements.

## Author

**Mehdi Benmoussa**

- GitHub: [@mehdibenmoussa24](https://github.com/mehdibenmoussa24)
- Project Repository: [DVLD-Project](https://github.com/mehdibenmoussa24/DVLD-Project)

## License

No license has been specified in this README. Add a `LICENSE` file to the repository if you intend to distribute the project under a specific open-source license.
