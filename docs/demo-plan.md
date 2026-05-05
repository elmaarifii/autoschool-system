# Demo Plan - Autoschool System

## 1. Titulli i projektit

**Autoschool System** - sistem per menaxhimin e orareve dhe rezervimeve ne autoshkolle.

## 2. Problemi qe zgjidh

Ne nje autoshkolle, oraret e vozitjes shpesh menaxhohen me mesazhe, thirrje ose lista manuale. Kjo krijon konfuzion: klienti nuk e di cilat orare jane te lira, instruktori mund te kete rezervime te dyfishta, dhe administratori e ka veshtire te mbaje kontroll mbi statusin e orareve.

Ky projekt e zgjidh problemin duke ofruar nje API dhe nje frontend ku oraret mund te shfaqen, filtrohen, rezervohen dhe lirohen me status te qarte.

## 3. Perdoruesit kryesore

- **Klienti**: shikon oraret e lira dhe rezervon nje slot per vozitje.
- **Instruktori**: publikon ose menaxhon oraret e veta.
- **Administratori**: kontrollon te dhenat dhe gjendjen e rezervimeve.

## 4. Flow-i qe do ta demonstroj live

Flow kryesor:

**dashboard -> kerkim/filter -> rezultat -> rezervim/anulim -> status i perditesuar**

Do te demonstroj pjesen e orareve sepse eshte pjesa me e qarte dhe me funksionale e projektit. Ky flow tregon nje problem real te autoshkolles dhe lidhet direkt me backend-in permes endpoint-eve `GET /api/Slots`, `POST /api/Slots/{id}/book` dhe `POST /api/Slots/{id}/release`.

Rendi i demos:

1. Hap frontend-in `UI/index.html`.
2. Shpjegoj se dashboard-i tregon oraret e instruktoreve.
3. Filtro sipas instruktorit, p.sh. `Arben`.
4. Filtro sipas statusit, p.sh. vetem oraret e lira.
5. Rezervoj nje slot te lire.
6. Tregoj qe statusi ndryshon nga `I lire` ne `I rezervuar`.
7. Liroj nje slot te rezervuar per te treguar anulimin.

## 5. Nje problem real qe e kam zgjidhur

Problemi ishte qe slotet mund te shfaqeshin pa kontroll te mjaftueshem dhe pa validim te te dhenave. Nese krijohej nje slot me ID jo valide, emer bosh ose ore ne format te gabuar, sistemi mund te ruante te dhena te pasakta.

Problemi ishte ne logjiken e menaxhimit te orareve, konkretisht te `SlotService`.

Zgjidhja:

- U shtua validim per ID pozitive.
- U ndalua krijimi i slotit me emer instruktori bosh.
- U kontrollua formati i ores me `TimeOnly.TryParse`.
- U shtua normalizim i te dhenave para ruajtjes.
- U perdor `Repository Pattern` per ta ndare logjiken e biznesit nga ruajtja ne file.

## 6. Cka mbetet ende e dobet

Pjesa e autentikimit dhe rolet nuk jane ende plotesisht te lidhura me frontend-in. Sistemi ka modele per perdorues, materiale dhe kuize, por demo live do te fokusohet vetem te flow-i me i stabilizuar: oraret dhe rezervimet.

Per permiresim te ardhshem:

- login/register te lidhet plotesisht me UI;
- panel i ndare per admin, instruktor dhe klient;
- ruajtje e te gjitha te dhenave ne database, jo vetem CSV per slotet;
- mesazhe me te detajuara per gabimet ne frontend.

## 7. Struktura e prezantimit (5-7 min)

**Hyrja (1 min)**  
Prezantimi i problemit: autoshkollat kane nevoje per menaxhim me te qarte te orareve dhe rezervimeve.

**Demo live (2-3 min)**  
Hap dashboard-in, filtro slotet, bej nje rezervim dhe pastaj anuloj nje rezervim.

**Shpjegimi teknik (1 min)**  
Shpjegoj shkurt arkitekturen: Controller -> Service -> Repository -> CSV/API response.

**Problemi + zgjidhja (1 min)**  
Tregoj validimin ne `SlotService` dhe pse ndihmon qe sistemi te mos ruaje te dhena te gabuara.

**Mbyllja (30 sek)**  
Permbledh cka funksionon live dhe cka mbetet per permiresim.

## Demo readiness dhe Plan B

Para prezantimit:

- Te ekzekutoj backend-in me `dotnet run --launch-profile https`.
- Te hap `UI/index.html` ne browser.
- Te kontrolloj qe API URL eshte `https://localhost:7075`.
- Te kem Swagger si backup: `https://localhost:7075/swagger`.
- Te kem gati README dhe kete dokument nese kerkohet shpjegim.

Plan B nese API nuk funksionon live:

- Frontend-i shfaq automatikisht te dhena demo.
- Mund te tregoj flow-in vizual me filtrat dhe ndryshimin e statusit ne te dhenat demo.
- Mund te hap Swagger ose screenshot-et ekzistuese ne `docs/Images`.
- Mund te shpjegoj endpoint-et dhe validimin direkt nga kodi.
