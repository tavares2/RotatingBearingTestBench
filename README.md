# Rotating Bending Main Bearing Test Bench System

## Overview

This project is a software prototype for a mechanical test bench that simulates a rotating bending main bearing arrangement. It includes a backend API built with ASP.NET Core, a frontend UI built using Blazor, and a database to store test sequences and results. The system allows users to define a test sequence, start a simulation, and visualize the results both graphically and in tabular format.

## Table of Contents

- [Technologies](#technologies)
- [System Overview](#system-overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Usage](#usage)
- [Future Enhancements](#future-enhancements)
- [Licenses](#licenses)

## Technologies

- **Backend**: ASP.NET Core Web API 
- **Frontend**: Blazor Server
- **Database**: SQL Server
- **Charting Library**: IgniteUI.Blazor for data visualization
- **ORM**: Entity Framework Core
- **Database Management**: SQL Server Management Studio
- **Version Control**: Git, GitHub

## System Overview

The system consists of two main parts:

1. **RotatingBearingAPI**:
   - A Web API built with ASP.NET Core that simulates the rotating bending test and stores test results in a SQL Server database.
   - Includes models for `TestSequence`, `TestStep`, and `TestResults`.
   - Exposes two controllers: `TestSequenceController` (for managing test sequences) and `TestResultController` (for running and retrieving test results).
   
2. **RotatingBearingUI**:
   - A Blazor Server UI that allows users to create a test sequence, start the simulation, and view the results.
   - The frontend interacts with the API to manage and run the test sequences and display the results in both chart and tabular formats.

## Features

- **Test Simulation**: Simulate a rotating bending test with configurable steps (Setpoint and Duration).
- **Test Sequence Management**: Define and manage test sequences consisting of multiple steps.
- **Result Visualization**: View simulation results in both graphical (chart) and tabular format.
- **Test Result History**: Fetch and view past test results based on the test sequence ID.
- **API Integration**: The backend API provides endpoints for creating, retrieving, and managing test sequences and results.

## Getting Started

### Prerequisites

- **.NET 6 & 8 SDK**: To run and build the application.
- **SQL Server**: Used to store test sequences and results.
- **Entity Framework Core**: ORM for database management.
- **Visual Studio or VS Code**: To open and work on the project.

### Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/tavares2/RotatingBearingTestBench.git
   ```
   
2. **Database Setup**:
   - Create a new database in SQL Server for the application (e.g., `RotatingBearingDB`).
   - Configure the connection string in `appsettings.json` in the `RotatingBearingAPI` project.
   
3. **Run Migrations**:
   - Open the `RotatingBearingAPI` project and run the following commands in the Package Manager Console to apply the migrations and create the necessary tables:
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

4. **Build and Run**:
   - Open the `RotatingBearingUI` project, navigate to `Program.cs` and update the API URL to match the URL of your `RotatingBearingAPI`.
   - Open the solution in Visual Studio or Visual Studio Code.
   - Build and run both the `RotatingBearingAPI` (backend API) and `RotatingBearingUI` (Blazor UI).
   - The backend API will be available at `https://localhost:5001` (or similar).
   - The Blazor UI will be available at `https://localhost:5002` (or similar).

6. **Start Testing**:
   - In the Blazor UI, go to the "Test Simulation" page to create a new test sequence, define steps, and start the simulation.
   - In the Blazor UI, go to the "Sequence Results" page to view the test results for the desire test sequence.

## Project Structure

### Backend (API - RotatingBearingAPI)

- **Controllers**:
  - `TestSequenceController.cs`: Manages test sequence CRUD operations.
  - `TestResultController.cs`: Starts the simulation and retrieves test results.
  
- **Models**:
  - `TestSequence.cs`: Represents the test sequence with name and steps.
  - `TestStep.cs`: Represents a step within a test sequence (setpoint and duration).
  - `TestResult.cs`: Represents the test results (timestamp, rotation speed, stress level, and temperature).
  
- **Services & Repositories**:
  - `TestSequenceService.cs`: Handles business logic related to test sequences.
  - `TestResultService.cs`: Handles business logic for running test simulations and storing results.
  - `TestSequenceRepository.cs` & `TestResultRepository.cs`: Data access layer for test sequences and results.
  
- **Database**: SQL Server database with Entity Framework Core, managing `TestSequence` and `TestResult` tables.

### Frontend (UI - RotatingBearingUI)

- **Pages**:
  - `SimulationTest.razor`: Allows users to input test sequence name and steps (setpoint, duration), to start the simulation and to see the results in a graphical chart and tabular format.
  - `TestRunner.razor`: Allows users to input a `TestSequenceId` and view test results in tabular format.
  - `Index.razor`: The default landing page.

- **Services**:
  - `TestService.cs`: Communicates with the API to manage test sequences and results.

- **Components**:
  - `TestResultsChart.razor`: Displays the test results in a graphical chart using `IgniteUI.Blazor`.

## Database Schema

### TestSequence Table

| Column Name  | Data Type     | Description                              |
|--------------|---------------|------------------------------------------|
| Id           | int           | Primary key, auto-incremented            |
| Name         | string        | Name of the test sequence                |

### TestStep Table

| Column Name  | Data Type     | Description                              |
|--------------|---------------|------------------------------------------|
| Id           | int           | Primary key, auto-incremented            |
| Setpoint     | float         | Rotation speed for the test step         |
| Duration     | int           | Duration in seconds for the test step    |
| TestSequenceId | int         | Foreign key to `TestSequence` table      |

### TestResult Table

| Column Name  | Data Type     | Description                              |
|--------------|---------------|------------------------------------------|
| Id           | int           | Primary key, auto-incremented            |
| Timestamp    | DateTime      | Timestamp of the test result             |
| RotationSpeed | float        | Rotation speed during the test           |
| StressLevel  | float         | Stress level during the test             |
| Temperature  | float         | Temperature during the test              |
| TestSequenceId | int         | Foreign key to `TestSequence` table      |

## Usage

### Create a Test Sequence

1. Navigate to the **"Test Simulation"** page in the Blazor UI.
2. Enter a **test sequence name** and define **multiple test steps** (setpoint, duration).
3. Click **"Start Simulation"** to initiate the test.
4. View the simulation results.

### View Test Results

1. Navigate to the **"Sequence Results"** page.
2. Input a **TestSequenceId** to retrieve all results related to that specific sequence.
3. Results will be displayed in a tabular format, showing timestamp, rotation speed, stress level, and temperature.

### View Test Results in Chart Format

- Results are displayed as a graphical chart using **IgniteUI.Blazor**.
- The chart visualizes key parameters like **stress level** and **temperature** for each **rotation speed**.

## Future Enhancements

- **Real-time Data Visualization**: Implement real-time updates during the test simulation.
- **Input Validation**: Add validation for user input on both test sequence creation and result display.
- **Cloud Deployment**: Implement CI/CD pipelines and deploy the system on a cloud platform such as Azure.
- **PLC Integration**: Integrate with hardware PLCs for real-time monitoring and control of the test bench.
