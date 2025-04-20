# 🚀 ASP.NET Core Web API – Authentication & Role-Based Authorization

## 📌 Project Overview

This is a secure ASP.NET Core Web API with JWT-based Authentication and Role-Based Authorization using MongoDB. It supports Admin and User roles, handles authentication with JWT, and includes protected CRUD endpoints for product management.

## 🧑‍💼 How to Register an Admin

Use the following endpoint to create an admin manually:

- **POST** `/api/Auth/adminRegister`

**Example Body:**
```json
{
  "username": "admin01",
  "firstName": "Admin",
  "lastName": "User",
  "email": "admin@example.com",
  "password": "Password@123"
}




#### ✅ 2. **Clarify Role-Based Access Rules**
Add under your feature list or in a new section:

```markdown
## 🔒 Role-Based Access Control

- 🟢 **All Authenticated Users** can:
  - View products (`GET /api/Product/getAll`)

- 🔴 **Only Admins** can:
  - Create products
  - Update products
  - Delete products


---

## 🛠️ Technologies Used

- ASP.NET Core (.NET 9)
- MongoDB Atlas
- ASP.NET Core Identity
- JWT (JSON Web Token)
- BCrypt for password hashing
- Swagger (API Docs)
- Postman (Testing)

---

## 🚧 Features Implemented

- ✅ Admin & User registration
- ✅ Login with JWT token generation
- ✅ Role-based access using custom `[AuthorizeRole]`
- ✅ CRUD operations for products (Admin-only for Create, Update, Delete)
- ✅ MongoDB integration
- ✅ Manual testing with Postman
- ✅ API documentation via Swagger

---

## 🔧 Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd your-project-folder

   2. **Create a `.env` file** in the root directory:

    MONGODB_CONNECTION_STRING=mongodblink
    MONGO_DATABASE_NAME=your-db-name
    JWT_SECRET_KEY=your-secret-key
    JWT_ISSUER=your-app
    JWT_AUDIENCE=your-users
