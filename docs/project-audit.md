# Project Audit

## 1. Pershkrimi i shkurter i projektit

Autoschool System eshte nje aplikacion per menaxhimin e autoshkolles. Sistemi synon te mbuloje nje pjese te procesit te mesimit teorik dhe praktik te vozitjes duke organizuar oraret, rezervimet dhe permbajtjen mesimore.

Perdoruesit kryesore jane:
- klientet/kursantet
- instruktoret
- administratori

Funksionaliteti kryesor aktual eshte menaxhimi i `slots` per oret e vozitjes, listimi i tyre ne API, rezervimi/anulimi, dhe nje UI demonstruese qe prezanton rolet kryesore te sistemit.

## 2. Cka funksionon mire?

- Projekti ka nje ndarje relativisht te qarte ne `Controllers`, `Services`, `Data`, `Models` dhe `UI`.
- CRUD bazik per `slots` ekziston dhe mund te perdoret nga API.
- Projekti ka testim bazik me `xUnit` per logjiken e `SlotService`.
- README jep nje pasqyre te mire te qellimit, roleve dhe teknologjive.
- UI demonstron qarte se si mund te duket sistemi per klientin, instruktorin dhe administratorin.

## 3. Dobesite e projektit

- Ruajtja e `slots` behet ne `slots.csv`, ndersa `Users` ne database; kjo e ben arkitekturen jo konsistente.
- Validimi i inputit ka qene shume i kufizuar dhe i shperndare ne menyre jo te njejte.
- Error handling ka qene i bazuar kryesisht ne `Exception`, pa dalluar mire gabimet e perdoruesit nga gabimet e sistemit.
- Modeli `User` nuk ka qene ne perputhje me `AppDbContext`, gje qe ka krijuar mospajtim ne kod.
- Disa modele si `Booking`, `Material`, dhe `Quiz` jane ende placeholder bosh.
- Frontend-i aktual eshte kryesisht demo; jo te gjitha veprimet lidhen me backend-in real.
- Testet kane mbuluar vetem rastet baze dhe jo rastet e deshtimit me te rendesishme.
- README kishte udhezime jo plotesisht te qarta per startup dhe testim.

## 4. 3 permiresime qe do t'i implementoj

### Permiresimi 1: konsistence me e mire ne modelin `User`

Problemi:
Modeli `User` perdorte `Password`, ndersa konfigurimi ne `AppDbContext` dhe rrjedha e autentikimit kerkonin `PasswordHash`.

Zgjidhja:
Do ta perditesoj modelin `User` qe te perdore `PasswordHash` dhe vlera default te sigurta per stringjet.

Pse ka rendesi:
Kjo e ben kodin me konsistent, shmang gabimet ne build, dhe e ben modelin me te pershtatshem per autentikim real.

### Permiresimi 2: validim dhe error handling me i mire per `slots`

Problemi:
`SlotService` pranonte input me validim minimal dhe perdorte `Exception` te pergjithshme pothuajse ne cdo rast.

Zgjidhja:
Do te krijoj validim te centralizuar per `slots`, do te shtoj rregulla per ID, formatin e ores dhe te dhenat e detyrueshme, si dhe do te dalloj gabimet e validimit nga ato te mungeses se te dhenave.

Pse ka rendesi:
API-ja behet me e parashikueshme, me e sigurt ndaj inputeve te gabuara, dhe me e lehte per t'u mirembajtur.

### Permiresimi 3: dokumentim me i qarte per startup dhe per auditin e projektit

Problemi:
Dokumentimi ekzistues jep nje pasqyre te mire, por nuk e shpjegon mjaftueshem gjendjen aktuale, kufizimet dhe arsyen e permiresimeve.

Zgjidhja:
Do te shtoj `docs/project-audit.md`, `docs/improvement-report.md`, dhe do te qartesoj disa pjese ne `README.md`.

Pse ka rendesi:
Dokumentimi e ben projektin me te kuptueshem per profesorin, bashkepunetoret dhe per veten time ne iterimet e ardhshme.

## 5. Nje pjese qe ende nuk e kuptoj plotesisht

Ende nuk e kuptoj plotesisht si duhet te lidhen ne menyre te paster `JWT authentication`, `role-based authorization` dhe konfigurimi ne `Program.cs` ne menyre qe API-ja te jete njekohesisht e sigurt dhe e thjeshte per testim ne Swagger. Kjo eshte nje pjese qe dua ta kuptoj me mire ne hapin tjeter.
