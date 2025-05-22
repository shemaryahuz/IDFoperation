# IDF Operation - C# Project

## 🧭 Overview

This C# project models a simplified military operation involving the **IDF (Israel Defense Forces)** and **Hamas**.  
The design leverages interfaces, abstract classes, and object-oriented principles to simulate organizational structure, military units, intelligence, and strategic strike operations.

---

## 🏗️ Project Architecture

---
### 🧱 Abstract Classes

- **`Organization`** *(abstract)*  
  Base class for IDF and Hamas

- **`StrikeOption`** *(abstract)*  
  Base class for different types of strike implementations

---

## 🔷 IDF Classes

- **`IDF`** *(inherits from `Organization`)*
  - Members:
    - `AMAN` (Intelligence unit)
    - `StrikeUnit` (Attack force)

- **`AMAN`**
  - Holds: `List<IntelligenceMessage>`

- **`StrikeUnit`**
  - Holds: `List<StrikeOption>` (can be `Plain`, `Drone`, `Artillery`, etc.)

- **`IntelligenceMessage`**
  - Contains intelligence data collected by AMAN

- **Strike Option Types** *(inherit from `StrikeOption`)*
  - `Plain`
  - `Drone`
  - `Artillery`

---

## 🔴 Hamas Classes

- **`Hamas`** *(inherits from `Organization`)*
  - Holds: `List<Terrorist>`

- **`Terrorist`**
  - Contains identifying information and traits

---

## 🎮 Controller Class

- **`IDFCommander`**
  - Manages the full simulation
  - Responsibilities:
    - Displays data
    - Manipulates object states
    - Initiates attacks
    - Coordinates between IDF and Hamas objects

---

## 📁 Folder Structure
```
/IDFOperationApp
│
├── Base/
│ ├── Organization.cs
│ └── StrikeOption.cs
│
├── IDF/
│ ├── IDF.cs
│ ├── AMAN.cs
│ ├── StrikeUnit.cs
│ ├── IntelligenceMessage.cs
│ └── StrikeOptions/
│   ├── Plain.cs
│   ├── Drone.cs
│   └── Artillery.cs
│
├── Hamas/
│ ├── Hamas.cs
│ └── Terrorist.cs
│
├── Core/
  ├── IDFComander.cs
  └── Program.cs
```

