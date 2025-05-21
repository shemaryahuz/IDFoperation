# IDF Operation – C# Project

## 🪖 Overview

This C# project models a simplified structure of a military operation involving the **IDF (Israel Defense Forces)** and **Hamas**. The core design uses interfaces and object-oriented principles to simulate organizational structures, operational units, and attack strategies.

The purpose of this simulation is to explore class design, interfaces, and hierarchical object relationships using C#.

---

## 🏗️ Project Architecture

### Interfaces

- **`IOrganization`**
  - Members:
    - `DateTime DateOfEstablishment`
    - `string CurrentCommander`

- **`IStrikeOption`**
  - To be implemented by different strike option classes (e.g., AirStrike, DroneStrike, etc.)

---

### Classes

- **`IDF`** (Implements `IOrganization`)
  - Members:
    - `AMAN` (Military Intelligence) – *Planned*
    - `StrikeUnit`
      - Holds a `List<IStrikeOption>`

- **`Hamas`** (Implements `IOrganization`)
  - Members:
    - `List<Terrorist>`
    - Intelligence and methods – *Planned*

- **`Terrorist`**
  - Basic properties and identity of enemy operatives

- **Strike Option Classes** (Implement `IStrikeOption`)
  - Examples (not implemented yet): `AirStrike`, `DroneStrike`, `CyberAttack`, etc.

---

## 🔄 Class Relationship Diagram

<pre> ``` /IDFOperation │ ├── Interfaces/ │ ├── IOrganization.cs │ └── IStrikeOption.cs │ ├── Core/ │ ├── IDF.cs │ ├── Hamas.cs │ ├── AMAN.cs │ ├── StrikeUnit.cs │ ├── Terrorist.cs │ ├── StrikeOptions/ │ ├── AirStrike.cs │ ├── DroneStrike.cs │ └── CyberAttack.cs │ └── README.md ``` </pre>
