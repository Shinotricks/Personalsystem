# Personalsystem
<strong>Backlog:<br>
Personalsystem</strong><br>
Det skall finnas 4 typer av användare: Admin, Chefer, Arbetare och Sökande.
Systemet skall ha en enkel och tydlig grafisk design.

<strong>Admin:</strong><br>
En sökande blir admin när han skapar ett företag i systemet(för det företaget).
Ett företag har följande struktur: Företagsnamn, Ledning, Avdelning 1, Avdelning1 Grupp1, Avdelning1 Grupp2……., Avdelning 2, Avdelning2 Grupp1……….
Skall bjuda in befintlig personal till företaget i systemet.
Skall kunna ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.
Skall kunna vara owner och kunna lägga till fler admin.
Skall kunna lägga ut nyheter. Bestämma vilka nyheter som ska vara interna eller externa.
Återgå till sökande genom att tas bort från företaget.

<strong>Chefer:</strong><br>
Skall kunna se olika ansökningar som ligger under sitt ansvarsområde.
Skall behandla ansökningar genom att godkänna, avböja eller kalla till intervju.
Vid avböjande eller kallande till intervju skall man komma till en ruta där hen kan komponera en förklaring eller inbjudan. 
Vid godkännande skall ett meddelande skickas till den sökande där hen kan välja att ta platsen eller avstå.
Skall kunna lägga ut arbetsscheman till avdelningar med fler grupper eller till enbart en grupp om denne grupps personal skall jobba på olika tider. Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).
Skall kunna lägga ut nyheter. Bestämma vilka nyheter som ska vara interna eller externa.
Återgå till sökande genom att tas bort från företaget.

<strong>Sökande:</strong><br>
Skall kunna ladda upp CV samt konsultprofil till sin användarprofil.
Skall söka lediga platser genom att klicka på en ”Sök den här tjänsten” knapp som låter användaren fylla i ett personligt brev till platsen.
När användare skapar sitt konto skall man bli lagd i gruppen sökande.
Skall kunna välja bland de företag som använder sig av systemet och se om det finns några vakanser. Existerar det vakanser skall dessa gå att söka via systemet.

<strong>Arbetare:</strong><br>
Kunna se när hen skall jobba.
Kunna se vilka hen jobbar med.
Kunna få en inblick i företaget.
Återgå till sökande genom att tas bort från företaget.

<strong>Kategorisering:</strong><br>
Databas
Adminhantering
Cheferhantering
Sökandehantering
Arbetarhantering
GUI

<strong>Databas:</strong><br>
User Model
{
int Id,
string Name 
}

Company Model</strong><br>
{
int Id,
string Name<br>
Ienumerable<'Department'> Departments() //Avdelningar<br>
Ienumerable<'Job'> Jobs() //Jobb
}

Department Model
{
int Id,
string Name<br>
Ienumerable<'Group'> Groups() //Grupper
}

Group Model
{
int Id,
string Name<br>
Ienumerable<'User'> Users() //Användare
}

News Model
{
int Id,
string Text
}

Job Model
{
int Id,
string Name
string Description<br>
DateTime Published
DateTime Deadline
}

<strong>Användar-historier<br>
Adminhantering:</strong><br>
Som användare vill jag kunna skapa ett företag i systemet (blir då admin).
Som admin skall jag kunna skapa företagets ledning.
Som admin skall jag kunna skapa företagets avdelningar.
Som admin skall jag kunna skapa avdelningarnas grupper.
Som admin skall jag kunna bjuda in redan befintlig personal till företaget.
Som admin skall jag kunna ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.
Som admin skall jag kunna vara owner och kunna lägga till fler admin.
Som admin skall jag kunna lägga ut nyheter.
Som admin skall jag kunna bestämma vilka nyheter som ska vara interna eller externa.
Som admin skall jag kunna återgå till sökande genom att tas bort från företaget.

<strong>Cheferhantering:</strong><br>
Som chef skall jag kunna se olika ansökningar som ligger under sitt ansvarsområde.
Som chef skall jag kunna behandla ansökningar genom att godkänna.
Som chef skall jag vid godkännande skicka ett meddelande till den sökande där hen kan välja att ta platsen eller avstå.
Som chef skall jag kunna behandla ansökningar genom att avböja.
Som chef skall jag vid avböjande komma till en ruta där chefen kan komponera en förklaring. 
Som chef skall jag kunna behandla ansökningar genom att kalla till intervju.
Som chef skall jag vid kallande till intervju komma till en ruta där chefen kan komponera en inbjudan. 
Som chef skall jag kunna lägga ut arbetsscheman till avdelningar med flera grupper om gruppens personal skall jobba på olika tider. Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).
Som chef skall jag kunna lägga ut arbetsscheman till avdelningar med enbart en grupp om denne grupps personal skall jobba på olika tider. Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).
Som chef skall jag kunna lägga ut nyheter.
Som chef skall jag kunna bestämma vilka nyheter som ska vara interna eller externa.
Som chef skall jag kunna återgå till sökande genom att tas bort från företaget.

<strong>Sökandehantering:</strong><br>
Som sökande skall jag kunna ladda upp CV till min användarprofil.
Som sökande skall jag kunna ladda upp konsultprofil till min användarprofil.
Som sökande skall jag kunna söka lediga platser genom att klicka på en ”Sök den här tjänsten” knapp som låter användaren fylla i ett personligt brev till platsen.
Som användare skall jag automatiskt läggas till i gruppen sökande när jag skapar mitt konto.
Som sökande skall jag kunna välja bland de företag som använder sig av systemet och se om det finns några vakanser.
Som sökande skall jag kunna söka existerande vakanser.

<strong>Arbetarehantering:</strong><br>
Som arbetare skall jag kunna se när jag skall jobba.
Som arbetare skall jag kunna se vilka jag jobbar med.
Som arbetare skall jag kunna få en inblick i företaget.
Som arbetare skall jag kunna återgå till sökande genom att tas bort från företaget.

<strong>Prioritering</strong><br>
1 Databas 2 Admin- 3 Chefer- 4 Sökande- 5 Arbetarhantering 6 GUI<br>
Vad är viktigt för kunden?<br>
Vilka beroenden finns det?<br>
Vilka delar är tekniskt viktiga?<br>
Hur komplext är kravet?<br>

<strong>Workitems</strong><br>
Skapa en modell. 
Skapa en controller för modeller.
Skapa en repository.
Skapa en vy för att visa en startmeny-modell.
Skapa en funktion som lägger till ett företag.
Skapa en funktion som lägger till ett företags ledning.
Skapa en funktion som lägger till ett företags avdelningar.
Skapa en funktion som lägger till en avdelnings grupper.
Skapa en funktion som lägger till (bjuder in) personal i företaget.
Skapa en vy för att visa företaget.
Skapa en funktion som kan ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.
Skapa en funktion som kan lägga till fler admin.
Skapa en funktion som kan ta bort admin (owner).
Skapa en funktion som kan lägga ut nyheter.
Skapa en funktion som kan lägga till vilka nyheter som ska vara interna eller externa.
Skapa en funktion som kan ta bort användaren från företaget.
Skapa en funktion som visar olika ansökningar som ligger under ett ansvarsområde.
Skapa en vy för att visa ansökningar.
Skapa en funktion som kan godkänna en ansökning och skicka ett meddelande till den sökande där hen kan välja att ta platsen eller avstå.
Skapa en funktion som kan avböja en ansökning och komma till en ruta där man kan komponera en förklaring och skicka denna till den sökande.
Skapa en funktion som kan kalla till intervju och komma till en ruta där man kan komponera en inbjudan och skicka denna till den sökande.
Skapa en funktion som lägger ut arbetsscheman till avdelningar med flera grupper om gruppens personal skall jobba på olika tider. Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).
Skapa en funktion som lägger ut arbetsschema till avdelningar med enbart en grupp om gruppens personal skall jobba på olika tider.
Skapa en vy för arbetsscheman.
Skapa en funktion för att kunna ladda upp CV till min användarprofil.
Skapa en funktion för att kunna ladda upp konsultprofil till min användarprofil.
Skapa en funktion för att söka lediga platser genom att klicka på en ”Sök den här tjänsten” knapp som låter användaren fylla i ett personligt brev till platsen.
Skapa en funktion för att automatiskt läggas till i gruppen sökande när jag skapar mitt konto.
Skapa en funktion för att kunna välja bland de företag som använder sig av systemet och se om det finns några vakanser.
Skapa en funktion för att kunna söka existerande vakanser.
Skapa en vy för att kunna se vakanser.
Skapa en vy för att kunna se när jag skall jobba.
Skapa en vy för att kunna se vilka jag jobbar med.
Skapa en vy för att kunna få en inblick i företaget.

<strong>Sprintbacklog:</strong><br>
Skapa en modell.<br> 
Skapa flera controllers.<br>
Skapa flera repositories.<br>
Skapa en funktion som lägger till ett företag.<br>
Skapa en funktion som lägger till ett företags ledning.<br>
Skapa en funktion som lägger till ett företags avdelningar.<br>
Skapa en funktion som lägger till en avdelnings grupper.<br>
Skapa en funktion som lägger till (bjuder in) personal i företaget.<br>
Skapa en vy för att visa företaget.<br>
