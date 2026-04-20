# 🚗 Autoschool System

**Autoschool System** është një aplikacion full-stack për menaxhimin e autoshkollës, i ndërtuar për të organizuar në mënyrë efikase procesin e mësimit teorik dhe praktik të vozitjes.

Ky sistem mundëson bashkëpunimin midis klientëve, instruktorëve dhe administratorëve, duke automatizuar oraret, rezervimet dhe përmbajtjen mësimore.

---

## 🎯 Qëllimi i Projektit

Qëllimi i këtij projekti është të krijojë një sistem të strukturuar dhe të shkallëzueshëm për:

- Menaxhimin e orareve të vozitjes  
- Rezervimin dhe anulimin e orëve  
- Shpërndarjen e materialeve teorike  
- Testimin e njohurive përmes kuizeve  

---

## 👥 Rolet në Sistem

### 👤 Klienti
- Regjistrohet dhe kyçet në sistem  
- Shikon oraret e lira  
- Rezervon dhe anulon orë  
- Akseson materiale teorike  
- Zgjidh kuize dhe sheh rezultatet  

### 👨‍🏫 Instruktori
- Vendos oraret e lira  
- Shikon rezervimet  
- Publikon materiale teorike  
- Krijon kuize për testim  

### 🛠️ Administratori
- Menaxhon përdoruesit  
- Menaxhon materialet dhe kuizet  
- Kontrollon sistemin në tërësi  

---

## ⚙️ Funksionalitetet Kryesore

- ✅ Regjistrim dhe autentikim (Login/Register)  
- 📅 Menaxhimi i orareve të instruktorëve  
- 🧾 Rezervimi dhe anulimi i orëve  
- 📚 Materiale teorike (tekst, video, dokumente)  
- 📝 Kuize për testimin e njohurive  
- 📊 Ruajtja e rezultateve dhe progresit  
- 🛡️ Menaxhim nga administratori  

---

## 🧪 Unit Testing

Në projekt është shtuar testing me **xUnit** për të testuar funksionalitetet kryesore të backend-it.

### 📦 Setup i testimeve

Testet gjenden në projektin:

AutoshkollaAPI.Tests

### ▶️ Si të ekzekutohen testet

Nga root folder i projektit:

```bash
dotnet test AutoshkollaAPI.Tests
```

Ose:

```bash
dotnet test AutoshkollaAPI.sln
```

✅ Çfarë testohet
✔ Rast normal (valid input)
✔ Rast kufitar (invalid input, p.sh. emër bosh)
✔ Verifikim i logjikës së shërbimeve (Services)
🧾 Shembuj testesh
Test për shtim të një slot-i valid
Test për validim të input-it
Test për kërkim të të dhënave
💻 Teknologjitë e Përdorura
Shtresa	Teknologjia
Frontend	HTML, CSS, JavaScript
Backend	C# / ASP.NET Core Web API
Database	PostgreSQL
ORM	Entity Framework Core
Testing	xUnit
Versioning	Git & GitHub
🏗️ Arkitektura e Projektit

Projekti ndjek një arkitekturë me shtresa (Layered Architecture):

Autoschool-System/
│
├── AutoshkollaAPI/
│   ├── Controllers/        # API endpoints (UI Layer)
│   ├── Models/             # Entitetet (User, Booking, Slot, etj.)
│   ├── Services/           # Logjika e biznesit
│   ├── Data/               # DbContext + Repository Pattern
│
├── docs/                   # UML + dokumentim
├── AutoshkollaAPI.Tests/   # Unit tests (xUnit)
├── frontend/               # HTML / CSS / JS
│   └── index.html
│
├── .gitignore
└── README.md
🧠 Parimet e Dizajnit (SOLID)

Projekti implementon parimet SOLID:

S – Single Responsibility Principle
Çdo klasë ka një përgjegjësi të vetme
O – Open/Closed Principle
Sistemi mund të zgjerohet pa ndryshuar kodin ekzistues
L – Liskov Substitution Principle
Implementimet mund të zëvendësohen pa prishur sistemin
I – Interface Segregation Principle
Interface të fokusuara dhe të thjeshta
D – Dependency Inversion Principle
Varet nga abstractions, jo implementime konkrete
🔄 Repository Pattern

Është implementuar Repository Pattern për ndarjen e logjikës së aksesit në të dhëna:

IRepository – interface bazë
FileRepository – implementim për ruajtje në file

Kjo e bën sistemin:

më fleksibil
më të testueshëm
më të lehtë për zgjerim
🚀 Si ta ekzekutosh projektin
🔧 Backend

Kërkesat:

.NET SDK
PostgreSQL

Hapat:

```bash
dotnet run
```

Pastaj hap:

https://localhost:xxxx/swagger

### Shënime të rëndësishme

- Endpoint-et e `Slots` përdorin `slots.csv` si storage lokal.
- `Users` ruhen në PostgreSQL përmes `AppDbContext`.
- Frontend-i aktual është një UI demonstrues dhe jo të gjitha veprimet janë të lidhura ende direkt me backend-in.
- Për të testuar ndryshimet në backend, rifillo aplikacionin pas çdo ndryshimi në `Program.cs` ose `Controllers`.
🌐 Frontend
Hape folderin frontend
Hap index.html në browser
📊 Dokumentimi
📄 docs/architecture.md – përshkrimi i arkitekturës
📄 docs/class-diagram.md – UML diagrami i klasave
📌 Statusi i Projektit

🚧 Në zhvillim (Project in progress)
Po shtohen funksionalitete në mënyrë iterative sipas kërkesave javore.

👩‍💻 Autori

Elma Arifi
Universiteti i Mitrovicës “Isa Boletini”
Fakulteti i Inxhinierisë Kompjuterike
2026
