# 🚗 Autoschool System

Autoschool System është një aplikacion full-stack për menaxhimin e autoshkollës, i ndërtuar për të organizuar në mënyrë efikase procesin e mësimit teorik dhe praktik të vozitjes.

Ky sistem mundëson bashkëpunimin midis **klientëve**, **instruktorëve** dhe **administratorëve**, duke automatizuar oraret, rezervimet dhe përmbajtjen mësimore.

---

## 🎯 Qëllimi i Projektit

Qëllimi i këtij projekti është të krijojë një sistem të strukturuar dhe të shkallëzueshëm për:

* Menaxhimin e orareve të vozitjes
* Rezervimin dhe anulimin e orëve
* Shpërndarjen e materialeve teorike
* Testimin e njohurive përmes kuizeve

---

## 👥 Rolet në Sistem

### 👤 Klienti

* Regjistrohet dhe kyçet në sistem
* Shikon oraret e lira
* Rezervon dhe anulon orë
* Akseson materiale teorike
* Zgjidh kuize dhe sheh rezultatet

### 👨‍🏫 Instruktori

* Vendos oraret e lira
* Shikon rezervimet
* Publikon materiale teorike
* Krijon kuize për testim

### 🛠️ Administratori

* Menaxhon përdoruesit
* Menaxhon materialet dhe kuizet
* Kontrollon sistemin në tërësi

---

## ⚙️ Funksionalitetet Kryesore

* ✅ Regjistrim dhe autentikim (Login/Register)
* 📅 Menaxhimi i orareve të instruktorëve
* 🧾 Rezervimi dhe anulimi i orëve
* 📚 Materiale teorike (tekst, video, dokumente)
* 📝 Kuize për testimin e njohurive
* 📊 Ruajtja e rezultateve dhe progresit
* 🛡️ Menaxhim nga administratori

---

## 💻 Teknologjitë e Përdorura

| Shtresa    | Teknologjia               |
| ---------- | ------------------------- |
| Frontend   | HTML, CSS, JavaScript     |
| Backend    | C# / ASP.NET Core Web API |
| Database   | PostgreSQL                |
| ORM        | Entity Framework Core     |
| Versioning | Git & GitHub              |

---

## 🏗️ Arkitektura e Projektit

Projekti ndjek një arkitekturë me shtresa (Layered Architecture):

```plaintext
Autoschool-System/
│
├── AutoshkollaAPI/
│   ├── Controllers/   # API endpoints (UI Layer)
│   ├── Models/        # Entitetet (User, Booking, Slot, etj.)
│   ├── Services/      # Logjika e biznesit
│   ├── Data/          # DbContext + Repository Pattern
│   ├── docs/          # UML + dokumentim
│
├── frontend/          # HTML / CSS / JS
│   └── index.html
│
├── .gitignore
└── README.md
```

---

## 🧠 Parimet e Dizajnit (SOLID)

Projekti implementon parimet SOLID:

* **S – Single Responsibility Principle**
  Çdo klasë ka një përgjegjësi të vetme (p.sh. Services për logjikë, Repository për data)

* **O – Open/Closed Principle**
  Sistemi mund të zgjerohet pa ndryshuar kodin ekzistues (p.sh. IRepository)

* **L – Liskov Substitution Principle**
  Implementimet e repository mund të zëvendësohen pa ndikuar sistemin

* **I – Interface Segregation Principle**
  Interface është i thjeshtë dhe i fokusuar vetëm në metodat e nevojshme

* **D – Dependency Inversion Principle**
  Services varen nga abstractions (IRepository), jo nga implementime konkrete

---

## 🔄 Repository Pattern

Është implementuar **Repository Pattern** për ndarjen e logjikës së aksesit në të dhëna:

* `IRepository<T>` – interface bazë
* `FileRepository<T>` – implementim për ruajtje në file (CSV/JSON)

Kjo e bën sistemin:

* më fleksibil
* më të testueshëm
* më të lehtë për zgjerim (p.sh. me DatabaseRepository)

---

## 🚀 Si ta ekzekutosh projektin

### 🔧 Backend

Kërkesat:

* .NET SDK
* PostgreSQL

Hapat:

```bash
dotnet run
```

Pastaj hap:

```
https://localhost:xxxx/swagger
```

---

### 🌐 Frontend

* Hape folderin `frontend`
* Hap `index.html` në browser

---

## 📊 Dokumentimi

* 📄 `docs/architecture.md` – përshkrimi i arkitekturës
* 📄 `docs/class-diagram.md` – UML diagrami i klasave

---

## 📌 Statusi i Projektit

🚧 Në zhvillim (Project in progress)
Po shtohen funksionalitete në mënyrë iterative sipas kërkesave javore.

---

## 👩‍💻 Autori

**Elma Arifi**
Universiteti i Mitrovicës “Isa Boletini”
Fakulteti i Inxhinierisë Kompjuterike
2026
