# Implementation

## Përshkrimi

Në këtë fazë të projektit është implementuar funksionaliteti CRUD për modelin **AvailableSlot** duke përdorur arkitekturë me shtresa.

Aplikacioni është ndarë në këto shtresa:

- Controller (UI / API layer)
- Service (Business Logic)
- Repository (Data Access)
- File (slots.csv)

Të dhënat ruhen në një file CSV (`slots.csv`) në vend të databazës, për thjeshtësi dhe për të demonstruar punën me file system.

---

## Funksionalitetet e implementuara

### 1. Listimi i orareve (GET)

Endpoint:
GET /api/slots

Sistemi lexon të dhënat nga `slots.csv` përmes Repository dhe i shfaq në Swagger.

---

### 2. Gjetja sipas ID (GET by ID)

Endpoint:
GET /api/slots/{id}

Kthen një orar specifik në bazë të ID-së.

---

### 3. Shtimi i orarit (POST)

Endpoint:
POST /api/slots

Lejon shtimin e një orari të ri me validim:

- Emri i instruktorit nuk duhet të jetë bosh
- Koha nuk duhet të jetë bosh
- ID gjenerohet automatikisht nëse nuk është valid

Të dhënat ruhen në `slots.csv`.

---

### 4. Përditësimi i orarit (PUT)

Endpoint:
PUT /api/slots/{id}

Lejon modifikimin e një orari ekzistues:

- Kontrollohet nëse ekziston slot
- Bëhet validimi i të dhënave
- Ndryshimet ruhen në `slots.csv`

---

### 5. Fshirja e orarit (DELETE)

Endpoint:
DELETE /api/slots/{id}

Fshin një orar ekzistues dhe përditëson file-in `slots.csv`.

---

## Arkitektura

Rrjedha e sistemit është:

Controller → Service → Repository → File (CSV)

- Controller merret me request/response
- Service përmban logjikën e biznesit dhe validimin
- Repository menaxhon leximin dhe shkrimin në file
- CSV përdoret si storage

---

## Rezultati

Sistemi funksionon plotësisht dhe mbështet operacionet CRUD:

- Lexon të dhënat nga CSV
- Shton të dhëna të reja
- Përditëson të dhëna ekzistuese
- Fshin të dhëna
- Shfaq rezultatet përmes Swagger UI

---

## Screenshot

### GET /api/slots
![GET Screenshot](images/get.png)

### POST /api/slots
![POST Screenshot](images/post.png)

### GETBYID /api/slots/{id}
![GETBYID Screenshot](images/getbyid.png)

### UPDATE /api/slots
![UPDATE Screenshot](image/update.png)

### DELETE /api/slots
![DELETE Screenshot](image/delete.png)

