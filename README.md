# Personalsystem
<strong>Backlog:<br>
Personalsystem</strong><br>
Det skall finnas 4 typer av användare: Admin, Chefer, Arbetare och Sökande.
Systemet skall ha en enkel och tydlig grafisk design.

<strong>Admin:</strong><br>
En sökande blir admin när han skapar ett företag i systemet(för det företaget).<br>
Ett företag har följande struktur: Företagsnamn, Ledning, Avdelning 1, Avdelning1 Grupp1, Avdelning1 Grupp2……., Avdelning 2, Avdelning2 Grupp1……….<br>
Skall bjuda in befintlig personal till företaget i systemet.<br>
Skall kunna ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.<br>
Skall kunna vara owner och kunna lägga till fler admin.<br>
Skall kunna lägga ut nyheter. Bestämma vilka nyheter som ska vara interna eller externa.<br>
Återgå till sökande genom att tas bort från företaget.<br>

<strong>Chefer:</strong><br>
Skall kunna se olika ansökningar som ligger under sitt ansvarsområde.<br>
Skall behandla ansökningar genom att godkänna, avböja eller kalla till intervju.<br>
Vid avböjande eller kallande till intervju skall man komma till en ruta där hen kan komponera en förklaring eller inbjudan.<br> 
Vid godkännande skall ett meddelande skickas till den sökande där hen kan välja att ta platsen eller avstå.<br>
Skall kunna lägga ut arbetsscheman till avdelningar med fler grupper eller till enbart en grupp om denne grupps personal skall jobba på olika tider.<br>
Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).<br>
Skall kunna lägga ut nyheter.<br>
Bestämma vilka nyheter som ska vara interna eller externa.<br>
Återgå till sökande genom att tas bort från företaget.<br>

<strong>Sökande:</strong><br>
Skall kunna ladda upp CV samt konsultprofil till sin användarprofil.<br>
Skall söka lediga platser genom att klicka på en ”Sök den här tjänsten” knapp som låter användaren fylla i ett personligt brev till platsen.<br>
När användare skapar sitt konto skall man bli lagd i gruppen sökande.<br>
Skall kunna välja bland de företag som använder sig av systemet och se om det finns några vakanser. Existerar det vakanser skall dessa gå att söka via systemet.<br>

<strong>Arbetare:</strong><br>
Kunna se när hen skall jobba.<br>
Kunna se vilka hen jobbar med.<br>
Kunna få en inblick i företaget.<br>
Återgå till sökande genom att tas bort från företaget.<br>

<strong>Kategorisering:</strong><br>
Databas
Adminhantering
Cheferhantering
Sökandehantering
Arbetarhantering
GUI

<strong>Användar-historier<br>
Adminhantering:</strong><br>
Som användare vill jag kunna skapa ett företag i systemet (blir då admin).<br>
Som admin skall jag kunna skapa företagets ledning.<br>
Som admin skall jag kunna skapa företagets avdelningar.<br>
Som admin skall jag kunna skapa avdelningarnas grupper.<br>
Som admin skall jag kunna bjuda in redan befintlig personal till företaget.<br>
Som admin skall jag kunna ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.<br>
Som admin skall jag kunna vara owner och kunna lägga till fler admin.<br>
Som admin skall jag kunna lägga ut nyheter.<br>
Som admin skall jag kunna bestämma vilka nyheter som ska vara interna eller externa.<br>
Som admin skall jag kunna återgå till sökande genom att tas bort från företaget.<br>

<strong>Cheferhantering:</strong><br>
Som chef skall jag kunna se olika ansökningar som ligger under sitt ansvarsområde.<br>
Som chef skall jag kunna behandla ansökningar genom att godkänna.<br>
Som chef skall jag vid godkännande skicka ett meddelande till den sökande där hen kan välja att ta platsen eller avstå.<br>
Som chef skall jag kunna behandla ansökningar genom att avböja.<br>
Som chef skall jag vid avböjande komma till en ruta där chefen kan komponera en förklaring.<br> 
Som chef skall jag kunna behandla ansökningar genom att kalla till intervju.<br>
Som chef skall jag vid kallande till intervju komma till en ruta där chefen kan komponera en inbjudan.<br> 
Som chef skall jag kunna lägga ut arbetsscheman till avdelningar med flera grupper om gruppens personal skall jobba på olika tider. Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).<br>
Som chef skall jag kunna lägga ut arbetsscheman till avdelningar med enbart en grupp om denne grupps personal skall jobba på olika tider. Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).<br>
Som chef skall jag kunna lägga ut nyheter.<br>
Som chef skall jag kunna bestämma vilka nyheter som ska vara interna eller externa.<br>
Som chef skall jag kunna återgå till sökande genom att tas bort från företaget.<br>

<strong>Sökandehantering:</strong><br>
Som sökande skall jag kunna ladda upp CV till min användarprofil.<br>
Som sökande skall jag kunna ladda upp konsultprofil till min användarprofil.<br>
Som sökande skall jag kunna söka lediga platser genom att klicka på en ”Sök den här tjänsten” knapp som låter användaren fylla i ett personligt brev till platsen.<br>
Som användare skall jag automatiskt läggas till i gruppen sökande när jag skapar mitt konto.<br>
Som sökande skall jag kunna välja bland de företag som använder sig av systemet och se om det finns några vakanser.<br>
Som sökande skall jag kunna söka existerande vakanser.<br>

<strong>Arbetarehantering:</strong><br>
Som arbetare skall jag kunna se när jag skall jobba.<br>
Som arbetare skall jag kunna se vilka jag jobbar med.<br>
Som arbetare skall jag kunna få en inblick i företaget.<br>
Som arbetare skall jag kunna återgå till sökande genom att tas bort från företaget.<br>

<strong>Prioritering</strong><br>
1 Databas 2 Admin- 3 Chefer- 4 Sökande- 5 Arbetarhantering 6 GUI<br>
Vad är viktigt för kunden?<br>
Vilka beroenden finns det?<br>
Vilka delar är tekniskt viktiga?<br>
Hur komplext är kravet?<br>

<strong>Workitems</strong><br>
<strike>Skapa en modell.</strike><br> 
<strike>Skapa en controller för modeller.</strike><br>
<strike>Skapa en repository.</strike><br>
<strike>Skapa en vy för att visa en startmeny-modell.</strike><br>
<strike>Skapa en funktion som lägger till ett företag.</strike><br>
<strike>Skapa en funktion som lägger till ett företags ledning.</strike><br>
<strike>Skapa en funktion som lägger till ett företags avdelningar.</strike><br>
<strike>Skapa en funktion som lägger till en avdelnings grupper.</strike><br>
<strike>Skapa en funktion som lägger till (bjuder in) personal i företaget.</strike><br>
<strike>Skapa en vy för att visa företaget.</strike><br>
Skapa en funktion som kan ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.<br>
Skapa en funktion som kan lägga till fler admin.<br>
Skapa en funktion som kan ta bort admin (owner).<br>
Skapa en funktion som kan lägga ut nyheter.<br>
Skapa en funktion som kan lägga till vilka nyheter som ska vara interna eller externa.<br>
Skapa en funktion som kan ta bort användaren från företaget.<br>
Skapa en vy som visar olika ansökningar som ligger under ett ansvarsområde.<br>
Skapa en vy för att visa ansökningar.<br>
Skapa en funktion som kan godkänna en ansökning och skicka ett meddelande till den sökande där hen kan välja att ta platsen eller avstå.<br>
Skapa en funktion som kan avböja en ansökning och komma till en ruta där man kan komponera en förklaring och skicka denna till den sökande.<br>
Skapa en funktion som kan kalla till intervju och komma till en ruta där man kan komponera en inbjudan och skicka denna till den sökande.<br>
Skapa en funktion som lägger ut arbetsscheman till avdelningar med flera grupper om gruppens personal skall jobba på olika tider.<br>
Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).<br>
Skapa en funktion som lägger ut arbetsschema till avdelningar med enbart en grupp om gruppens personal skall jobba på olika tider.<br>
<strike>Skapa en vy för arbetsscheman.</strike><br>
Skapa en funktion för att kunna ladda upp CV till min användarprofil.<br>
Skapa en funktion för att kunna ladda upp konsultprofil till min användarprofil.<br>
Skapa en funktion för att söka lediga platser genom att klicka på en ”Sök den här tjänsten” knapp som låter användaren fylla i ett personligt brev till platsen.<br>
<strike>Skapa en funktion för att automatiskt läggas till i gruppen sökande när jag skapar mitt konto.</strike><br>
Skapa en funktion för att kunna välja bland de företag som använder sig av systemet och se om det finns några vakanser.<br>
Skapa en funktion för att kunna söka existerande vakanser.<br>
<strike>Skapa en vy för att kunna se vakanser.</strike><br>
<strike>Skapa en vy för att kunna se när jag skall jobba.</strike><br>
Skapa en vy för att kunna se vilka jag jobbar med.<br>
Skapa en vy för att kunna få en inblick i företaget.<br>

<strong>Sprintbacklog:</strong><br>
<strong>Durim</strong><br>
Skapa en funktion som lägger ut arbetsscheman till avdelningar med flera grupper om gruppens personal skall jobba på olika tider.<br>
Arbetsscheman tas fram enbart om arbetstiden avviker från en fast arbetsperiod varje dag (8-17).<br>
Skapa en funktion som lägger ut arbetsschema till avdelningar med enbart en grupp om gruppens personal skall jobba på olika tider.<br>
Skapa viewmodel till chef.<br>
Snygga till arbetstider view<br><br>
<strong>Peter</strong><br>
Skapa en funktion som kan ändra roll på andra användare(kopplade till företaget) till chef eller arbetare.<br>
Skapa en funktion som kan lägga till fler admin.<br>
Skapa en funktion som kan ta bort admin (owner).<br>
Skapa en funktion som kan godkänna en ansökning och skicka ett meddelande till den sökande där hen kan välja att ta platsen eller avstå.<br>
Skapa en funktion som kan avböja en ansökning och komma till en ruta där man kan komponera en förklaring och skicka denna till den sökande.<br>
Skapa en funktion som kan kalla till intervju och komma till en ruta där man kan komponera en inbjudan och skicka denna till den sökande.<br>
Som admin, chef eller arbetare skall jag kunna återgå till sökande genom att tas bort från företaget.<br><br>
<strong>Christoffer</strong><br>
Skapa en vy som visar olika ansökningar som ligger under ett ansvarsområde.<br>
Skapa en vy för att visa ansökningar.<br>
Som admin och chef skall jag kunna lägga ut nyheter.<br>
Som admin skall jag kunna bestämma vilka nyheter som ska vara interna eller externa.<br>
