# 🏥 Red Cross Mediation Service Management System

## 📌 Overview
This project is a **service mediation management system** for the Red Cross.  
It facilitates how **Centers**  can request and manage **services** through **Mediators**.  

The system is built using **Clean Architecture + ASP.NET Core Web API + MediatR (CQRS)**, ensuring scalability, maintainability, and separation of concerns.

---

## 🎯 Goals
- Allow **Centers** to request services easily.  
- Assign and track **Mediators** handling these demands.  
- Manage **Users**, **Languages**, and **Service details** for efficient coordination.  
- Provide a transparent workflow for **Demands**, including their **status, type, priority, and timelines**.  

---

## 📂 Domain Model (Database Schema)

The core entities of the system partial design:
<img width="897" height="744" alt="image" src="https://github.com/user-attachments/assets/5810be4b-a37f-4aaf-a130-edf69d911c0a" />

---

## 🔄 Workflow

1. A **Center (User of role Demander the director of a center)** creates a new **Demand** for a specific **Service**.  
2. A **Mediator (User of role Mediator)** is assigned to the demand.  
3. **DemandDetails** are created to specify required services, responsibilities, and communication by **Admin (User of role Admin as a coordinator)**.  
4. The demand is tracked with **status, priority, and deadlines**.  
5. Completed demands are stored for reporting and accountability.  

---

## 🏗️ Architecture

- **Domain Layer** → Entities, Value Objects, Business rules.  
- **Application Layer** → Use Cases (CQRS with MediatR), DTOs, Interfaces.  
- **Infrastructure Layer** → EF Core, Repositories, external services.  
- **Web API Layer** → ASP.NET Core controllers, middlewares, authentication.  

---

## 🚀 Features (Planned)
- [x] Create and manage **Centers**  
- [ ] Register and manage **Users (Mediators Admin and Demander)**
- [ ] Login oauth using google futur outlook
- [ ] Define available Services
- [ ] Create and track Demands from centers
- [ ] Handle unavialabilities (absences and holidays of users)
- [ ] Let residents participate at least see the presence of mediators in a day
- [ ] Assign Mediators and manage workload
- [ ] Support multi-language communication
- [ ] Add reporting & analytics for demand tracking
- [ ] Integrate to mail services
- [ ] Frontend dragable UI components
- [ ] Integrate to distance and map services
- [ ] Add to agenda

