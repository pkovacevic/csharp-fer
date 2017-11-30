# Context

Connection string preko konstruktora - 1 bod
Dobro opisane relacije u kontekstu 
- Definirani primarni ključevi - 1 bod
- Definirana obavezna polja - 1 bod
- Definirana many to many veza - 1 bod

# TodoAplikacija

Dependency Injection dobro postavljen - 1 bod
Logiranje svih grešaka u bazu u tablicu “ErrorLogs” - 1 bod
Connection string definiran u konfiguraciji i pravilno se šalje DbContextu - 1 bod

Samo autorizirani korisnici imaju pristup Todo operacijama - 1 bod

Ispravan prikaz aktivnih TodoStavki - 2 boda
- Ispravan prikaz dana do roka - 1 bod
- Koristi se TodoViewModel i IndexViewModel - 1 bod
- Mark as completed radi - 1 bod
- Prikazuju se samo stavke trenutno ulogiranog korisnika - 2 boda
	
Ispravan prikaz završenih TodoStavki - 2 boda
- Remove from completed radi - 1 boda
- Koristi se CompletedViewModel i TodoViewModel - 1 boda
- Isti partial view za završene i aktivne stavke - 2 boda

Dodavanje novog Todoa radi - 2 boda
- Dodavanje labela radi - 3 boda
- Koristi se AddViewModel ili varijacija na temu (ovisi o odabranoj strategiji) -  1 bod
- Ispravna validacija - 2 boda

Aplikacija ne radi istoimene labele u bazi - 3 boda

