# Autoschool System

Autoschool System eshte nje aplikacion per menaxhimin e orareve dhe rezervimeve ne autoshkolle. Projekti ka backend me ASP.NET Core Web API dhe nje frontend demonstrues me HTML, CSS dhe JavaScript.

Qellimi i projektit eshte te ndihmoje klientet, instruktoret dhe administratorin te kene me pak konfuzion rreth orareve te vozitjes: cilat jane te lira, cilat jane te rezervuara dhe si ndryshon statusi i nje sloti.

## Flow kryesor per demo

Flow-i qe do te prezantohet live:

```text
dashboard -> filter/kerkim -> rezultat -> rezervim/anulim -> status i perditesuar
```

Ne demo hapet `UI/index.html`, filtrohen slotet sipas instruktorit ose statusit dhe pastaj rezervohet ose lirohet nje slot.

## Funksionalitete qe punojne live

- Shfaqja e te gjitha slot-eve nga `GET /api/Slots`
- Filtrim sipas instruktorit
- Filtrim sipas statusit `I lire` / `I rezervuar`
- Rezervim i slotit me `POST /api/Slots/{id}/book`
- Anulim/leshimi i slotit me `POST /api/Slots/{id}/release`
- Validim i te dhenave ne `SlotService`
- Plan B ne frontend me te dhena demo nese API nuk hapet gjate prezantimit

## Teknologjite

- Frontend: HTML, CSS, JavaScript
- Backend: C# / ASP.NET Core Web API
- Data access: Repository Pattern
- Storage per slotet: `slots.csv`
- Database e konfiguruar: PostgreSQL
- Testing: xUnit

## Si ta ekzekutosh projektin

Kerkesat:

- .NET SDK
- Browser
- PostgreSQL nese perdoret lidhja e plote me database

Nis backend-in:

```bash
dotnet run --launch-profile https
```

Pastaj hap:

```text
https://localhost:7075/swagger
```

Per frontend:

```text
UI/index.html
```

Frontend-i perdor si API URL:

```text
https://localhost:7075
```

## Testet

Testet gjenden ne projektin `AutoshkollaAPI.Tests`.

Ekzekutimi:

```bash
dotnet test AutoshkollaAPI.sln
```

## Arkitektura

Projekti ndjek ndarje me shtresa:

- `Models` - entitetet si `AvailableSlot`, `Booking`, `User`
- `Controllers` - endpoint-et e API-se
- `Services` - logjika e biznesit dhe validimi
- `Data` - repository dhe ruajtja e te dhenave
- `UI` - frontend demonstrues
- `docs` - dokumentim dhe plan demo

Shembull i flow-it teknik:

```text
Frontend -> SlotsController -> SlotService -> IRepository -> slots.csv
```

## Dokumentimi

- `docs/demo-plan.md` - plani i demos live
- `docs/architecture.md` - pershkrimi i arkitektures
- `docs/class-diagram.md` - diagrami i klasave
- `docs/implementation.md` - shenime implementimi

## Statusi

Projekti eshte ne zhvillim. Pjesa me e pergatitur per demo eshte menaxhimi i orareve dhe rezervimeve. Pjeset qe mbeten per permiresim jane autentikimi i plote, rolet ne frontend dhe lidhja e te gjitha moduleve me UI.

## Autor

Elma Arifi  
Universiteti i Mitrovices "Isa Boletini"  
Fakulteti i Inxhinierise Kompjuterike  
2026
