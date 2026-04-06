# Sprint 2 Report — Elma Arifi

## Çka Përfundova
- Implementova dhe përditësova logjikën për menaxhimin e `AvailableSlot` në `SlotService`, duke përfshirë shtimin, listimin me filtra, gjetjen sipas ID, update dhe delete.
- Implementova validime për rastet kufitare në metodat `Add` dhe `Update`, si p.sh. sigurimi që `InstructorName` dhe `Time` nuk lejohen të jenë bosh.
- Krijova projektin e testeve `AutoshkollaAPI.Tests` dhe shtova 4 unit teste që mbulojnë:
  - rast normal: shtim i suksesshëm i një slot-i valid
  - rast kufitar: emër instruktori bosh
  - kërkim/filter për një instruktor ekzistues
  - kërkim/filter për një instruktor që nuk ekziston
- Rregullova konfigurimin e build-it duke përjashtuar skedarët e testeve nga `AutoshkollaAPI.csproj`, për të shmangur konfliktet gjatë kompilimit.

Output që dëshmon:
`dotnet test AutoshkollaAPI.Tests/AutoshkollaAPI.Tests.csproj`

Rezultati:
`Passed: 4, Failed: 0, Total: 4`

## Çka Mbeti
- Disa nullable warnings ende shfaqen gjatë build-it (p.sh. te modelet me string jo-nullable pa vlera iniciale).
- Dokumentimi mund të zgjerohet me shembuj shtesë për endpoint-et dhe test cases.
- Nuk janë shtuar ende teste integrimi/API (aktualisht janë vetëm unit tests për service layer).

## Çka Mësova
- Mësova si të strukturoj më mirë testet me xUnit duke përdorur të dhëna të izoluara për secilin test.
- Mësova si të rregulloj konfliktet e kompilimit mes projektit kryesor dhe projektit të testeve në konfigurimin e `.csproj`.
- Mësova rëndësinë e mbulimit të rasteve kufitare (jo vetëm rrjedhën "happy path") për të siguruar stabilitet më të mirë të aplikacionit.
