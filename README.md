# Yash_OrderSystem

This is a simplified Order Processing System built with .NET Core and Entity Framework Core.
## Table of Contents

## Project Setup Instructions

### Prerequisites

1. **.NET SDK**: Ensure that you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. **SQLite**: The application uses SQLite as the database. Ensure that the SQLite provider is installed.
3. **Git**: Git is used for version control. If you don't have it installed, you can get it from [here](https://git-scm.com/).

### Steps to Run the Application

1. **Clone the Repository**:
   Open a terminal/command prompt and run the following command to clone the repository:

   ```bash
   git clone https://github.com/yashyks/Yash_OrderSystem.git

2. Restore Dependencies: Run the following command to restore the required NuGet packages:
dotnet restore

3.Run Migrations: Apply the migrations to set up the database. Run the following command:
dotnet ef database update

4. Run the Application: Start the application using:
dotnet run
