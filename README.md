Autoschool System

Autoschool System është një aplikacion për menaxhimin e autoshkollës, i krijuar për të ndihmuar klientët, instruktorët dhe administratorët të menaxhojnë oraret, materialet teorike dhe kuizet.

🛠 Funksionalitetet Kryesore
Përdoruesit: Regjistrim dhe login për klientë, instruktorë dhe administratorë.
Oraret e instruktorëve: Instruktorët vendosin oraret e lira për mësime praktike.
Rezervime dhe anulime: Klientët mund të rezervojnë ose të anulojnë orët e vozitjes.
Materiale teorike: Instruktorët shtojnë materiale për mësim.
Kuize teorike: Testim i njohurive për klientët përgatitje për testin teorik.
Menaxhim i përmbajtjes: Administratori mund të menaxhojë përdoruesit dhe përmbajtjen.
Historiku: Ruajtja e historikut të orëve dhe rezultateve të kuizeve.
💻 Teknologjitë e Përdorura
Frontend: HTML, CSS, JavaScript
Backend: C# me .NET
Database: PostgreSQL
📁 Strukturë Projekti
Autoschool-System/
│
├─ AutoshkollaAPI/      # Backend me .NET
│  ├─ Controllers/
│  ├─ Data/             # AppDbContext.cs
│  ├─ Models/           # Modelet e përdoruesve dhe orëve
│  ├─ Services/         # Logjika e biznesit
│
├─ frontend/            # Frontend HTML / CSS / JS
│  └─ index.html
│
├─ .gitignore
└─ README.md
🚀 Si ta ekzekutosh projektin
1️⃣ Backend
Siguro që ke instaluar .NET SDK
 dhe PostgreSQL.
Konfiguro AppDbContext.cs me kredencialet e databazës.
Nis backend-in nga Visual Studio ose terminali:
dotnet run
Backend-i do të ekzekutohet në http://localhost:5000 (ose port tjetër në konfigurim).
2️⃣ Frontend
Hape folderin frontend.
Hap index.html në browser (Chrome / Edge / Firefox).

Autori: Elma Arifi
Universiteti i Mitrovicës 2026