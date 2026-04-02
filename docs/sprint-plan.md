# Sprint 2 Plan — Elma Arifi

Data: 1 Prill 2026

## Gjendja Aktuale

### Çka funksionon tani:

* API funksionale për menaxhimin e orareve të vozitjes (AvailableSlot)
* Implementim i plotë i CRUD operacioneve:

  * GET (listimi i të gjitha orareve)
  * GET by ID (kthimi i një orari specifik)
  * POST (shtimi i një orari të ri)
  * PUT (përditësimi i një orari ekzistues)
  * DELETE (fshirja e një orari)
* Ruajtja dhe leximi i të dhënave nga file CSV (slots.csv)
* Implementim i arkitekturës me shtresa:

  * Controller (ndërfaqja / API layer)
  * Service (logjika e biznesit)
  * Repository (qasja në të dhëna)
* Validim bazë në Service:

  * Emri i instruktorit nuk lejohet të jetë bosh
  * Koha nuk lejohet të jetë bosh
* Swagger UI për testim dhe demonstrim të API

### Çka nuk funksionon:

* Nuk është implementuar error handling i plotë në të gjitha shtresat
* Programi mund të dështojë në rast të:

  * mungesës së file-it CSV
  * input-it të pavlefshëm nga useri
  * kërkesave për ID që nuk ekziston
* Nuk ka unit tests për validimin e funksionalitetit
* Nuk ka ende frontend (HTML/CSS/JavaScript)

### A kompajlohet dhe ekzekutohet programi:

* Po, projekti kompajlohet dhe ekzekutohet pa gabime

---

## Plani i Sprintit

### Feature e Re

**Filtrim dhe kërkim i orareve sipas instruktorit dhe statusit (i lirë / i rezervuar)**

Përshkrimi:
Do të implementohet një funksionalitet që lejon kërkimin dhe filtrimin e orareve në bazë të:

* emrit të instruktorit
* statusit të orarit (i lirë ose i rezervuar)

Si përdoret nga useri:

* Useri dërgon kërkesë përmes API (p.sh. Swagger ose frontend)
* Jep parametrat e filtrimit (p.sh. emrin e instruktorit)
* Sistemi kthen vetëm rezultatet që përputhen me kriteret

Shembull:
GET /api/slots?instructorName=Arben&isBooked=false

Rezultati:
Shfaqen vetëm oraret e instruktorit “Arben” që janë të lira

Shembull tjetër:
GET /api/slots?isBooked=true

Rezultati:
Shfaqen vetëm oraret e rezervuara

Arkitektura:

* Controller merr parametrat
* Service përpunon logjikën e filtrimit
* Repository kthen të dhënat nga CSV

---

### Error Handling

Qëllimi: Programi të mos crashojë në asnjë rast dhe të japë mesazhe të qarta për userin.

Do të trajtohen këto raste:

1. File nuk ekziston

* Problem: leximi i file-it CSV mund të dështojë
* Zgjidhje:

  * përdorim i try-catch në Repository
  * nëse file mungon → krijohet automatikisht
  * mesazh: "File nuk u gjet, po krijohet një file i ri"

2. Input i pavlefshëm nga useri

* Problem: useri mund të dërgojë të dhëna të gabuara
* Zgjidhje:

  * validim në Service dhe Controller
  * përdorim i try-catch për kapjen e gabimeve
  * mesazh: "Ju lutem shkruani të dhëna valide"
  * programi vazhdon pa u ndalur

3. ID nuk ekziston

* Problem: kërkohet një slot që nuk ekziston
* Zgjidhje:

  * kontroll në Service
  * nëse nuk gjendet → kthehet null ose mesazh
  * Controller kthen: "Slot nuk u gjet"

---

### Teste

Do të krijohet projekt test me xUnit për të verifikuar funksionalitetin.

Metodat që do të testohen:

1. Add()

* Rast normal: shto slot valid → duhet të ruhet me sukses
* Rast kufitar: emër bosh → duhet të kthejë error

2. GetById()

* ID ekziston → kthen slot korrekt
* ID nuk ekziston → kthen null

3. Feature e re (filtrimi)

* Filtrim me instruktor ekzistues → kthen rezultate
* Filtrim me instruktor jo-ekzistues → kthen listë bosh

Qëllimi i testeve:

* Verifikimi i funksionimit korrekt
* Testimi i rasteve kufitare (edge cases)
* Parandalimi i bug-eve

---

## Afati

* **Deadline:** Martë, 8 Prill 2026, ora 08:30 (dorëzim i kodit final + `docs/sprint-report.md` në GitHub dhe link në Student Hub)

