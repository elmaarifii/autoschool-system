# Architecture – Autoshkolla System

Ky dokument përshkruan arkitekturën e projektit për semestrin.

---

## Layers / Shtresat e Projektit

### 1. Models
- Përmbajnë strukturën e të dhënave:
    - User, AvailableSlot, Booking, Material, Quiz
- Vetëm **properties** (atribute private)
- Nuk përmbajnë logjikë

### 2. Data
- Menaxhon ruajtjen e të dhënave
- Implementon **Repository Pattern**
    - `IRepository<T>` → kontrata
    - `FileRepository<T>` → ruan/lexon nga CSV
- Mund të zgjerohet për database (PostgreSQL)

### 3. Services
- Përmban logjikën e biznesit sipas user stories:
    - Regjistrim/Login
    - Vendosja e orareve
    - Rezervimet
    - Materialet teorike
    - Kuize
- Komunikon me **Data layer** për CRUD

### 4. Controllers / UI
- Ndërfaqja për përdoruesit
- Përdor **Controllers** si entry point
- Ekspozon endpoint-et për frontend ose Swagger

### 5. Docs
- Këtu ruhen dokumentimet: 
    - UML diagram
    - Architecture
    - User stories

---

## Pse u zgjodh kjo arkitekturë?

- **Separation of Concerns** – secila shtresë ka përgjegjësinë e vet
- **Lehtë për mirëmbajtje** – logjika ndahet nga të dhënat dhe UI
- **Zgjerim i lehtë** – mund të shtohen features pa ndryshuar pjesë ekzistuese

---

## SOLID Principles të aplikuara

### S – Single Responsibility Principle (SRP)
- Çdo klasë ka vetëm një përgjegjësi
- Shembull: `BookingService` vetëm menaxhon rezervimet

### O – Open/Closed Principle (OCP)
- Klasat janë të hapura për zgjerim, të mbyllura për ndryshim
- Shembull: mund të shtohet `DatabaseRepository` pa ndryshuar `BookingService`

### L – Liskov Substitution Principle (LSP)
- Mund të zëvendësosh `FileRepository` me `DatabaseRepository` dhe të funksionojë njësoj

### I – Interface Segregation Principle (ISP)
- `IRepository<T>` ka vetëm metodat bazë (GetAll, GetById, Add, Save)
- Nuk detyron klasat të implementojnë metoda të panevojshme

### D – Dependency Inversion Principle (DIP)
- Services varen nga abstraksione (IRepository), jo nga implementimi konkret (`FileRepository`)