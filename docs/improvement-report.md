# Improvement Report

## Permiresimi 1: rregullim i modelit `User` dhe konsistences se domain-it

### Cka ishte problemi me pare

Modeli `User` perdorte fushen `Password`, ndersa pjeset tjera te kodit dhe konfigurimi i databazes prisnin `PasswordHash`. Kjo krijonte mospajtim ne projekt dhe sillte gabim ne build.

### Cfare ndryshova

- e ndryshova `User.Password` ne `User.PasswordHash`
- shtova vlera default per `Name`, `Email`, dhe `PasswordHash`
- perditesova `AppDbContext` qe te perdore `PasswordHash`

### Pse versioni i ri eshte me i mire

Tani modeli i perdoruesit perputhet me konfigurimin e databazes dhe me rrjedhen e autentikimit. Kjo e ben projektin me te qendrueshem dhe shmang gabimet strukturore.

## Permiresimi 2: validim dhe error handling me i mire per `slots`

### Cka ishte problemi me pare

`SlotService` kishte validim minimal, perdorte `Exception` te pergjithshme, dhe kishte logjike te perseritur ne disa metoda. Kjo e bente te veshtire dallimin mes gabimeve te inputit dhe gabimeve te sistemit.

### Cfare ndryshova

- krijova `SlotValidationException`
- centralizova validimin e `slots` ne nje metode te vetme
- shtova validime per:
  - ID pozitive
  - ID te pa-dublikuara ne `Add`
  - emer instruktori jo bosh
  - ore ne format te vlefshem
  - date te detyrueshme
- normalizova emrin e instruktorit dhe daten para ruajtjes
- perditesova `SlotsController` qe te ktheje `400 Bad Request` per gabime validimi dhe `404 Not Found` kur mungon slot-i
- perditesova `IRepository.GetById` qe te reflektoje qe rezultati mund te mungoje

### Pse versioni i ri eshte me i mire

Kodi eshte me i qarte, me i lehte per mirembajtje, dhe API-ja jep pergjigje me kuptimplote. Kjo rrit besueshmerine e backend-it dhe ul shanset per sjellje te paqarta.

## Permiresimi 3: testim dhe dokumentim me i qarte

### Cka ishte problemi me pare

Testet mbulonin vetem disa raste baze, ndersa README kishte udhezime jo plotesisht te qarta per startup dhe kufizimet aktuale te projektit.

### Cfare ndryshova

- shtova teste te reja per:
  - ID te dublikuar
  - ore jo valide
  - fshirje te nje ID-je qe nuk ekziston
  - normalizim te emrit dhe dates
- permiresova `README.md` me udhezime me te qarta per `dotnet run`, `dotnet test`, dhe me shenime mbi storage aktual
- shtova `docs/project-audit.md` dhe kete raport

### Pse versioni i ri eshte me i mire

Versioni i ri eshte me i shpjegueshem dhe me i verifikueshem. Profesori ose nje zhvillues tjeter mund te shohin jo vetem cfare ben projekti, por edhe si eshte menduar dhe si po permiresohet.

## Cka mbetet ende e dobet ne projekt

- Projekti ende perdor storage te perzier: `slots.csv` dhe PostgreSQL.
- `Booking`, `Material`, dhe `Quiz` nuk jane ende te implementuara plotesisht.
- Frontend-i aktual eshte kryesisht demo dhe jo i lidhur ne menyre te plote me backend-in.
- Autentikimi me JWT nuk eshte ende i kompletuar ne startup pipeline.
- `FileRepository<T>` eshte praktik vetem per `AvailableSlot` dhe nuk eshte vertet generic ne kuptimin e plote.
