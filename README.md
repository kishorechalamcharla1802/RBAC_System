# RBAC_System

RBAC stands Role-Based Access Control (RBAC). This is a system which is used to manage user access through predefined roles — Admin, Editor, and Viewer.
This application is built with **Angular** on the frontend and **ASP.NET Core Web API** on the backend.

---

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Setup and Installation](#setup-and-installation)
- [Accessing the Application](#Accessing-the-application)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Role-Based Access](#role-based-access)

---

## Features

- User authentication using JWT
- Role-based access control (Admin / Editor / Viewer)
- User management (Add/Edit/Delete users)
- Setup steps management (Add/Edit/Delete steps)
- Inline editing in Angular Material tables
- Form validations with required fields.
- New User Registration

---

## Tech Stack

- **Frontend:** Angular, Angular Material, TypeScript, RxJS
- **Backend:** ASP.NET Core Web API, C#
- **Authentication:** JWT Bearer Tokens

---

## Prerequisites

- [Node.js](https://nodejs.org/) (v18.20.8)
- [Angular CLI](https://angular.io/cli) (v17.3.17)
- [.NET SDK](https://dotnet.microsoft.com/download) (v8.0.413)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [Visual studio Code](https://code.visualstudio.com/download)

---

## Setup and Installation

### 1. Clone the repository

```bash
git clone https://github.com/your-username/your-repo.git
cd your-repo
```

### 2. Backend (ASP.NET Core API) - Visual Studio Setup

1. **Open Visual Studio**

   - Launch Visual Studio 2022 (or your installed version).
   - Ensure **ASP.NET and web development** workload is installed.

2. **Open the Project**

   - Go to `File > Open > Project/Solution`.
   - Navigate to the backend folder (`BE/`) and select the `.sln` file.

3. **Restore NuGet Packages**

   - Right-click the solution in **Solution Explorer** → `Restore NuGet Packages`.
   - Or open **Package Manager Console** and run:
     ```bash
     dotnet restore
     ```

4. **Configure Connection Strings**

   - Open `appsettings.json`.
   - check the JWT settings cofiguration.

5. **Build the Project**

   - Click `Build > Build Solution`.
   - Ensure there are no build errors.

6. **Run the API**
   - Right-click the backend project → `Set as Startup Project` (if multiple projects exist).
   - To Debug -> Press `F5` or click **Start Debugging** under Debug.
   - Without Debug -> Press `Ctrl+F5` or click **Start without Debugging** under Debug
   - The API will run at `https://localhost:7148` (or the URL shown in the browser).

### 3. Frontend (Angular)

```bash
cd frontend
npm install
ng serve
```

The Angular app will run at `http://localhost:4200`.

---

## Accessing the Application

1. Open the Angular app in your browser: `http://localhost:4200`
2. Login with a registered user or create a new user.
3. Navigate through pages according to your role:
   - **Admin:** Full access
   - **Editor:** Add/Edit/Delete steps
   - **Viewer:** Read-only access
4. Add, edit, or delete setup steps (based on role permissions).
5. Form fields include **required validations**, and inline error messages appear for invalid input.

---

## API Endpoints

- After running the backend all APIs will be visible in Swagger to Test and Execute

---

## Authentication

- JWT-based authentication
- Include the token in the request header:

```
Authorization: Bearer <token>
```

- Token is obtained on login and stored in localStorage for subsequent API calls.

---

## Role-Based Access

| Role   | Permissions                   |
| ------ | ----------------------------- |
| Admin  | Add/Edit/Delete users & steps |
| Editor | Add/Edit/Delete steps         |
| Viewer | Read-only access              |

---
