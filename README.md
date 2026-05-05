# 🏥 Mediation Management System

## 📌 Overview
This program is made to make the life easier on managing the demands of mediators by centers.
 
1. The ***backend system*** is built using **Clean Architecture + ASP.NET Core Web API + MediatR (CQRS)**, ensuring scalability, maintainability, and separation of concerns.
2. The ***frontend system*** is built using angular 19 and material design 19 [Check the frontend here](https://github.com/AbielKiflu/mediator)

## 📂 Domain Model (Database Schema)

The core entities of the system partial design:
<img width="897" height="744" alt="image" src="https://github.com/user-attachments/assets/5810be4b-a37f-4aaf-a130-edf69d911c0a" />

 ---

## 👥 System Roles

* **Admin:** Configures core system configurations, master data, centers, and system settings.
* **Coordinator:** Acts as the dispatcher/manager. Reviews, validates, and assigns incoming demands to eligible mediators.
* **Client:** The beneficiary at a refugee center who initiates requests for specific services.
* **Mediator:** The field worker assigned to a center who delivers the specialized services based on language skills and availability.
* 
---

 ## 🏗️ Core Structural Rules

1. **User:** Can be an Admin, Coordinator, Client, or Mediator. Each user belongs to exactly **one Center**.
2. **Language:** The master list of distinct languages spoken by mediators.
3. **UserLanguage:** A many-to-many join table linking **Users** to the **Languages** they speak fluently.
4. **Center:** The physical facility (20 distinct locations) where localized support is provided.
5. **Service:** The type of assistance provided by mediators (*Translation*, *Mediation*, *Training*).
6. **Demand:** A formal service request initiated by a **Client** at a **Center**, requiring authorization and assignment by a **Coordinator**.
7. **Demand Detail:** The structural child entity of a Demand specifying the exact **Service** and context required.

---

## 🔄 End-to-End System Workflow

### Phase 1: Foundational Setup & Registration
Before any operational services can be requested, system data constraints and user configurations must be established.
* **System Initialization:** The **Admin** populates the master registries for `Users`, `Centers`, `Languages`, `UserLanguage`. and `Services`.

### Phase 2: Request Initiation (Demand Creation)
This phase captures the moment a localized need arises at a specific center.
* **Need Identification:** A **Client** at a center requires a specific form of assistance (e.g., an Arabic translator for an intake interview).
* **Drafting the Request:** The client creates a **Demand** specifying metadata (`CenterId`, `Description`, `Priority`, `StartDate`, `FinishDate`). The state defaults to `Submitted`.
* **Attaching Details:** A corresponding **DemandDetail** record is instantly appended to the Demand, defining the exact type of **Service** needed.

### Phase 3: Validation & Smart Matching (The Coordinator Gate)
This phase executes the application's core business domain validation and algorithmic rules.
* **Quality Assurance:** The **Coordinator** reviews incoming `Submitted` demands to verify details.
* **Eligibility Evaluation:** The system searches for matching **Mediators** by validating three strict domain invariants:
  1. **Location Match:** The mediator must belong to the requesting `CenterId`.
  2. **Language Match:** The mediator must have the required language mapped in their `UserLanguage` profile.
  3. **Availability Check:** The current date must not fall inside the mediator's `PauseStartDate` and `PauseEndDate` window.
* **Task Allocation:** The **Coordinator** selects a qualified mediator. The system records the assignment in `DemandedUserId` and transitions the status to `Assigned`.

### Phase 4: Execution & Resolution
The final phase tracks the actual field delivery of the service to the client.
* **Start:** The assigned **Mediator** checks their dashboard, reviews the message instructions, and marks the Demand status as `InProgress` when they begin helping the client.
* **Delivery:** The **Mediator** provides the specialized **Service** directly to the **Client** at the center.
* **Fulfillment & Closure:** Once concluded, the **Mediator** switches the status to `Completed`. The system logs the closure for historical reporting and metrics tracking.

---


## 📊 Workflow Summary Matrix

| Persona | Operational Actions | Primary Table Interactions |
| :--- | :--- | :--- |
| **Admin** | Populates system constraints & configurations | `Center`, `Language`, `Service`, `User` |
| **Client** | Requests localized center services | `Demand`, `DemandDetail` |
| **Coordinator** | Validates requests & matches personnel | Reads `UserLanguage`, Updates `Demand` |
| **Mediator** | Manages availability & fulfills assignments | Updates `User` (Pause dates), Updates `Demand` (Status) |


## 🚀 Features (Planned)
- [x] .....
- [ ] ....

