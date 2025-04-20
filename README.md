# 🚀 ASP.NET Core Web API – Authentication & Role-Based Authorization

## 📌 Project Overview

This is a secure ASP.NET Core Web API with JWT-based Authentication and Role-Based Authorization using MongoDB. It supports Admin and User roles, handles authentication with JWT, and includes protected CRUD endpoints for product management.

A secure REST API featuring:
- JWT Authentication
- Role-Based Authorization (Admin/User)
- MongoDB CRUD Operations
- Swagger Documentation

## 📌 Table of Contents
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [API Endpoints](#-api-endpoints)
- [Setup](#-setup)
- [Authentication Flow](#-authentication-flow)
- [Postman Collection](#-postman-collection)
- [Swagger UI](#-swagger-ui)

## 🎯 Features
| Feature                | Status   |
|------------------------|--------- |
| User Registration      | ✅       |
| Admin Registration     | ✅      |
| JWT Login              | ✅      |
| Role-Based Access      | ✅      |
| Product CRUD           | ✅      |
| Swagger Docs           | ✅      |

## 🛠️ Tech Stack
- **Backend**: ASP.NET Core 9.0
- **Database**: MongoDB Atlas
- **Authentication**: JWT Bearer Tokens
- **Security**: 
  - BCrypt Password Hashing
  - Custom `[AuthorizeRole]` Attribute
- **Tools**:
  - Swagger UI
  - Postman (Testing)

---

## 🔌 API Endpoints

### 🔐 Authentication
| Method | Endpoint                 | Description           | Access  |
|--------|------------------------  |-----------------------|---------|
| POST   | `/api/Auth/register`     | User registration     | Public  |
| POST   | `/api/Auth/adminRegister`| Admin registration*   | Public  |
| POST   | `/api/Auth/login`        | JWT Token generation  | Public  |

> *Disable `adminRegister` in production

### 📦 Product Management
| Method | Endpoint                   | Description       | Access  |
|--------|------------------------    |-------------------|---------|
| POST   | `/api/Product/create`      | Create product    | Admin   |
| GET    | `/api/Product/getAll`      | Get all products  | Public  |
| PUT    | `/api/Product/update/{id}` | Update product    | Admin   |
| DELETE | `/api/Product/delete/{id}` | Delete product    | Admin   |

---

## 🚀 Setup

### Prerequisites
- .NET 9 SDK
- MongoDB Atlas account
- Postman (optional)

### 1. Clone the Repository
```bash
git clone https://github.com/SanjeevanTech/AuthApiBackendTask.git

