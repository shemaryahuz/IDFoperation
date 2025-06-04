
# IDF Operation - C# Project

## 🧭 Overview

This C# project simulates a simplified military operation involving the **IDF (Israel Defense Forces)** and **Hamas**.  
It uses interfaces, abstract classes, and OOP design to represent the structure and behavior of military organizations, intelligence analysis, and strike operations.

---

## 🏗️ Project Architecture

### 🧱 Abstract Classes & Interfaces

- **`Organization`** *(abstract)*  
  Base class for both `IDF` and `Hamas`.

- **`IStrikeOption`** *(interface)*  
  Implemented by all strike option types (`Plain`, `Drone`, `Artillery`).

---

## 🔷 IDF Classes

- **`IDF`** *(inherits from `Organization`)*
  - Composed of:
    - `IntelUnit` - Gathers and processes intelligence
    - `StrikeUnit` - Manages and executes strike operations

- **`IntelUnit`**
  - Holds:
    - `List<IntelMessage>` - Raw intelligence messages
    - `List<IntelTerrorist>` - Identified terrorists (extended from `Terrorist`)
  - Purpose: Processes messages and identifies threats

- **`IntelMessage`**
  - Represents collected raw intelligence data.

- **`IntelTerrorist`** *(inherits from `Terrorist`)*
  - Enhanced terrorist information obtained through analysis.

- **`StrikeUnit`**
  - Holds:
    - `Dictionary<string, List<IStrikeOption>>`  
      - Keys: `"Plains"`, `"Drones"`, `"Artilleries"`  
      - Values: Lists of strike option implementations
  - Purpose: Executes different types of military strikes

- **Strike Option Types** *(implement `IStrikeOption`)*
  - `Plain`
  - `Drone`
  - `Artillery`

---

## 🔴 Hamas Classes

- **`Hamas`** *(inherits from `Organization`)*
  - Holds:
    - `List<Terrorist>` - Operative members

- **`Terrorist`**
  - Contains identifying information and traits.

---

## 🎮 Controller & Utility Classes

- **`OperationManager`**
  - Main driver of the program
  - Manages user flow and calls relevant methods based on user input
  - Delegates control to `Displayer` and `IDFCommander`

- **`IDFCommander`**
  - Controls operations within the IDF:
    - Handles intelligence processing
    - Chooses and executes strike actions

- **`Displayer`**
  - Responsible for user interaction:
    - Displays menu options
    - Shows information about IDF units and status

---

## 🧑‍💻 User Interaction Flow

The application presents the user with the following options:

1. **View IDF Info**  
   - Displays intelligence messages and identified terrorists  
   - Shows available strike options and units

2. **Choose Attack Method**  
   - Select a method of attack (`Plain`, `Drone`, or `Artillery`)  
   - Initiate a strike using available data

The `OperationManager` coordinates this flow by calling methods in `Displayer` to show the menu and in `IDFCommander` to process the selected actions.

---

## 📁 Folder Structure
```
/IDFoperationApp
│
├── Base/
│   ├── IStrikeOption.cs
│   └── Organization.cs
│
├── Core/
│   ├── Displayer.cs
│   ├── FactoryManager.cs
│   ├── IDFCommander.cs
│   └── OperationManager.cs
│
├── GeminiService/
│   ├── GeminiClasses.cs
│   └── GeminiService.cs
│
├── Hamas/
│   ├── Hamas.cs
│   ├── Terrorist.cs
│   └── TerroristFactory.cs
│
├── IDF/
│   ├── IDF.cs
│   ├── IntelUnit/
│   │   ├── IntelMessage.cs
│   │   ├── IntelMessageFactory.cs
│   │   ├── IntelTerrorist.cs
│   │   └── IntelUnit.cs
│   └── StrikeUnit/
│       ├── Artillery.cs
│       ├── Drone.cs
│       ├── Plain.cs
│       ├── StrikeFactory.cs
│       └── StrikeUnit.cs
│
└── Program.cs
```
