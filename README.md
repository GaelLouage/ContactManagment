# 📇 Contact Management System (WPF, C#)

A simple desktop-based Contact Management System built using **C#**, **WPF**, and **JSON** for data persistence. The app allows users to **create, update, delete, search, and sort** contacts with ease.

## 🚀 Features

- Add, update, and delete contacts.
- Real-time search functionality.
- Sort by name, email, or phone.
- Email validation and input field checks.
- JSON file used for persistent storage.
- Built with WPF (Windows Presentation Foundation).

## 🛠️ Tech Stack

- **.NET Framework**
- **C#**
- **WPF (Windows Presentation Foundation)**
- **Newtonsoft.Json** (for JSON serialization)

## 📷 Screenshots

> _You can include screenshots of the UI here for better presentation._

## 📁 Folder Structure

```bash
ContactManagementSystem/
├── Base/
│   └── ContactAlreadyExistsException.cs
├── Entities/
│   └── ContactEntity.cs
├── Enums/
│   └── OrderType.cs
├── Helpers/
│   ├── EmailHelper.cs
│   └── ValidateFieldsHelper.cs
├── Services/
│   ├── Interfaces/
│   │   └── IJsonService.cs
│   └── Classes/
│       └── JsonService.cs
├── MainWindow.xaml.cs
├── UpdateForm.xaml.cs
└── Create.xaml.cs (not included in provided code, but should exist)

🧩 How It Works

    On launch, the app reads contact data from a .json file.

    The main window loads contacts into a ListView with search and sort features.

    Users can add new contacts, update existing ones, or delete selected contacts.

    All changes are saved back to the JSON file.

🧪 To-Do / Possible Improvements

Add unit/integration tests

Use MVVM pattern for better scalability

Refactor for dependency injection

Migrate to use SQLite or Entity Framework

Improve UI/UX

    Add export/import options

▶️ Getting Started

    Clone the repository

    git clone https://github.com/yourusername/contact-management-system.git
    cd contact-management-system

    Open the solution in Visual Studio.

    Build and run the application.

    Make sure .json file gets generated on the first run, or create contacts.json manually.
