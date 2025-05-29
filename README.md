# 🎓 Al-Araby: Online Learning Web App (Kenouz)

[![GitHub](https://img.shields.io/badge/GitHub-Repository-blue?logo=github)](https://github.com/MohamedSaidEl-Sayed/Al-Araby.git)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Framework-purple)](https://dotnet.microsoft.com/)

> **Freelance Project** – A comprehensive online learning platform developed for an Arabic Language Teacher  
> 📅 **Start Date:** May 2022  
> 👨‍💻 **Developer:** [Mohamed Said El-Sayed](https://github.com/MohamedSaidEl-Sayed)

---

## 📋 Table of Contents
- [Project Overview](#-project-overview)
- [Technologies Used](#-technologies-used)
- [Features](#-features)
- [Getting Started](#-getting-started)
- [Installation Guide](#-installation-guide)
- [Default Admin Account](#-default-admin-account)
- [Usage](#-usage)
- [Project Structure](#-project-structure)
- [Contributing](#-contributing)
- [Application Screenshots](#-application-screenshots)

---

## 📌 Project Overview
Al-Araby is a secure, role-based online learning platform specifically designed for Arabic language education. The platform provides a comprehensive solution for teachers to manage students, deliver content, and assess learning progress through an intuitive web interface.

### Key Highlights
- **Secure Authentication System** with unique student codes
- **Device-based Access Control** for enhanced security
- **Role-based Content Management** for different educational levels
- **Multimedia Learning Support** with embedded videos
- **Assessment Tools** with built-in quiz functionality

---

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core (MVC)** - Web framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database management system
- **ASP.NET Core Identity** - Authentication and authorization

### Frontend
- **HTML5** - Markup structure
- **CSS3** - Styling and responsive design
- **JavaScript** - Interactive functionality

### Development Tools
- **Visual Studio** / **Visual Studio Code**
- **SQL Server Management Studio**
- **Git** - Version control

---

## ✨ Features

### 🔐 Authentication & Security
- **Unique Login Codes**: Students access the platform using admin-generated codes
- **Device Restriction**: One device per student login for enhanced security
- **Session Management**: Admin can monitor and control active sessions
- **Code Management**: Ability to revoke or reset student access codes

### 👨‍🏫 Admin Dashboard
- **Student Management**: Create, edit, and manage student accounts
- **Content Control**: Upload and organize educational materials
- **Access Monitoring**: Track student login activities and progress
- **Role Assignment**: Categorize students by educational levels

### 📚 Educational Content
- **Structured Lessons**: Organized Arabic language curriculum
- **Video Integration**: Multimedia content for enhanced learning
- **Assessment Tools**: Built-in quiz system for knowledge evaluation

### 🎯 Student Categorization
- **1st Secondary Level**
- **2nd Secondary Level** 
- **3rd Secondary Level**
- Personalized content delivery based on assigned levels

---

## 🚀 Getting Started

### Prerequisites
Before you begin, ensure you have the following installed:
- **.NET 6.0 SDK** or later
- **SQL Server** (LocalDB, Express, or Full version)
- **Visual Studio 2022** or **Visual Studio Code**
- **Git** for version control

### System Requirements
- **OS**: Windows 10/11, macOS, or Linux
- **RAM**: Minimum 4GB (8GB recommended)
- **Storage**: At least 2GB free space

---

## 🔧 Installation Guide

### 1. Clone the Repository
```bash
git clone https://github.com/MohamedSaidEl-Sayed/Al-Araby.git
cd Al-Araby
```

### 2. Restore NuGet Packages
```bash
dotnet restore
```

### 3. Database Setup
Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AlArabyDB;Trusted_Connection=true;MultipleActiveResultSets=true"  (e.g. your connection)
  }
}
```

### 4. Apply Database Migrations
```bash
dotnet ef database update
```

### 5. Build and Run the Application
```bash
dotnet build
dotnet run
```

The application will be available at: `https://localhost:5001` or `http://localhost:5000`

---

## 🔑 Default Admin Account

A default admin account has been created through database seeding during the initial migration.

### Admin Login Credentials
- **Login Code**: `0A209d429admin`
- **Role**: Admin
- **Permissions**: Full system access

> ⚠️ **Important Note**: Change the default admin credentials from Migrations that seeding the Role "Admin" and seeding the Code of the Admin

### First-Time Setup
1. Navigate to the login page
2. Enter the admin code: `0A209d429admin`
3. Access the admin dashboard
4. Create student accounts and generate their unique login codes
5. Configure educational content and lessons

---

## 💡 Usage

### For Administrators
1. **Login** using the admin code
2. **Create Student Accounts** with appropriate level assignments
3. **Generate Login Codes** for each student
4. **Upload Content** including lessons and videos
5. **Create Assessments** using the quiz management system

### For Students
1. **Receive Login Code** from your teacher
2. **Access Platform** using your unique code
3. **Complete Lessons** in your assigned level
4. **Take Quizzes** to test your knowledge

---

## 📁 Project Structure

```
Al-Araby/
├── Controllers/         # MVC Controllers
├── Models/              # Data models
├── Views/               # Razor views
├── Data/                # Entity Framework context and migrations
├── Migrations/          # migrations
├── wwwroot/             # Static files (CSS, JS, images)
├── ViewModels/          # Transfer Data
├── Areas/               # Admin and user areas
└── appsettings.json     # Configuration file
```

---

## 🤝 Contributing

This is a freelance project developed for a specific client. However, if you'd like to contribute or have suggestions:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request
---


## 📱 Application Screenshots

### 🏠 Home Page
![Main Page](https://github.com/MohamedSaidEl-Sayed/Al-Araby/blob/main/Demo_ScreenShots/MainPage.png)

---

### 👨‍🏫 Manage Resourses
![Manage Resourses](https://github.com/MohamedSaidEl-Sayed/Al-Araby/blob/main/Demo_ScreenShots/ManagedResources.png)

---

### 📚 Exams
![Examst](https://github.com/MohamedSaidEl-Sayed/Al-Araby/blob/main/Demo_ScreenShots/Exams.png)

---

### 📊 Quiz Management System
![Quiz Management](https://github.com/MohamedSaidEl-Sayed/Al-Araby/blob/main/Demo_ScreenShots/QuizManagement.PNG)

---

### 🎬 Videos
![Videos](https://github.com/MohamedSaidEl-Sayed/Al-Araby/blob/main/Demo_ScreenShots/Videos.png)

---

**⭐ If you find this project helpful, please consider giving it a star on GitHub!**

---

*Last Updated: May 2025*



