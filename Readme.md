## Informacje podstawowe

Celem niniejszej aplikacji było zapoznanie się z techniką tworzenia API sieciowego w środowisku .NET, z zastosowaniem podstawowego uwierzytelniania użytkowników.

Aplikacja obsługuje uproszczone zarządzanie ramówkami radiowymi lub telewizyjnymi, z możliwością przygotowania ramówki cyklicznej - tygodniowej, oraz ramówek specjalnych, na konkretną datę.

Powyższa aplikacja nie zawiera autoryzacji. Jeśli chcesz zapoznać się z wersją rozszerzoną o autoryzację przy użyciu OpenIdDict, przejdź pod adres: https://github.com/michael112/RamowkiWithOpenIddictAuth

## Wymagania techniczne

Aplikacja działa w środowisku .NET Core w wersji 2.0. SDK niezbędne do uruchomienia aplikacji można pobrać pod adresem: https://www.microsoft.com/net/download

## Obsługa aplikacji

1. Wprowadzenie do systemu nowej audycji.

Zapytanie HTTP POST pod adres /api/programme.

Przykładowa zawartość JSON:

```javascript
{
	"Title": "Przykładowa audycja 1",
	"Description": "Opis audycji"
}
```

Pole Description jest opcjonalne.

2. Edycja istniejącej audycji.

Zapytanie HTTP PUT pod adres /api/programme/{programmeID}, gdzie za {programmeID} podajemy odpowiedni identyfikator.

Przykładowa zawartość JSON - jak w pkt. 1.

3. Usuwanie audycji.

Zapytanie HTTP DELETE pod adres /api/programme/{programmeID}, gdzie za {programmeID} podajemy odpowiedni identyfikator.

Zapytanie nie oczekuje JSON-a w zawartości.

4. Wyświetlanie listy wszystkich audycji w systemie.

Zapytanie HTTP GET pod adres /api/programme. Wymagane konto użytkownika z dowolnymi uprawnieniami.

Zapytanie nie oczekuje JSON-a w zawartości.

5. Wyświetlanie audycji o określonym identyfikatorze.

Zapytanie HTTP GET pod adres /api/programme, gdzie za {programmeID} podajemy odpowiedni identyfikator.

Zapytanie nie oczekuje JSON-a w zawartości.

6. Jednoczesne wprowadzenie do systemu programu oraz jego pozycji w ramówce.

Zapytanie HTTP POST pod adres /api/schedule. Wymagane konto administratorskie.

Przykładowa zawartość JSON (jeśli ma zostać przypisany do ramówki specjalnej na konkretną datę):

```javascript
{
	"Programme": {
		"Title": "sample title",
		"Description": "sample description"
	},
	"Day": {
		"Date": "15-11-2016",
	}
	"BeginTime": {
		"Hours": 17,
		"Minutes": 0
	}
}
```

lub (przypisanie do ramówki cyklicznej na dany dzień tygodnia):

```javascript
{
	"Programme": {
		"Title": "sample title",
		"Description": "sample description"
	},
	"Day": {
		"WeekDay": 2,
	}
	"BeginTime": {
		"Hours": 17,
		"Minutes": 0
	}
}
```

Dni tygodnia numerujemy w sposób następujący:

0 - niedziela

1 - poniedziałek

...

6 - sobota

7 - niedziela

8 - poniedziałek

itp... (reszta z dzielenia nr dnia przez 7)

7. Wprowadzenie do systemu informacji o przypisaniu istniejącego programu do dnia i godziny w ramówce.

Zapytanie HTTP POST pod adres /api/schedule/?programme={programmeID}, gdzie za {programmeID} podajemy odpowiedni identyfikator.

Przykładowa zawartość JSON (jeśli ma zostać przypisany do ramówki specjalnej na konkretną datę):

```javascript
{
	"Day": {
		"Date": "15-11-2016",
	}
	"BeginTime": {
		"Hours": 17,
		"Minutes": 0
	}
}
```

lub (przypisanie do ramówki cyklicznej na dany dzień tygodnia):

```javascript
{
	"Day": {
		"WeekDay": 2,
	}
	"BeginTime": {
		"Hours": 17,
		"Minutes": 0
	}
}
```

Dni tygodnia numerujemy jak wyżej.

8. Przypisanie do istniejącej pozycji w ramówce innej audycji istniejącej w systemie.

Zapytanie HTTP PUT pod adres /api/schedule/{scheduleID}?programme={programmeID}, gdzie za {scheduleID} podajemy identyfikator pozycji w ramówce, a za {programmeID} - identyfikator programu, który ma zostać do niej przypisany.

Zapytanie NIE MOŻE zawierać JSON-a.

9. Edycja informacji o pozycji ramówkowej (dzień, godzina).

Zapytanie HTTP PUT pod adres /api/schedule/{scheduleID}, gdzie za {scheduleID} podajemy identyfikator pozycji w ramówce. Wymagane konto administratorskie.

Przykładowa zawartość JSON (jeśli ma zostać przypisany do ramówki specjalnej na konkretną datę):

```javascript
{
	"Day": {
		"Date": "15-11-2016",
	}
	"BeginTime": {
		"Hours": 17,
		"Minutes": 0
	}
}
```

lub (przypisanie do ramówki cyklicznej na dany dzień tygodnia):

```javascript
{
	"Day": {
		"WeekDay": 2,
	}
	"BeginTime": {
		"Hours": 17,
		"Minutes": 0
	}
}
```

10. Usuwanie pozycji ramówkowej (bez usunięcia samej audycji!).

Zapytanie HTTP DELETE pod adres /api/schedule/{scheduleID}, gdzie za {scheduleID} podajemy identyfikator pozycji w ramówce.

Zapytanie nie oczekuje JSON-a w zawartości.

11. Wyszukanie informacji o pozycji ramówkowej na podstawie jej identyfikatora.

Zapytanie HTTP GET pod adres /api/schedule/{scheduleID}, gdzie za {scheduleID} podajemy identyfikator pozycji w ramówce.

Zapytanie nie oczekuje JSON-a w zawartości.

12. Wyszukanie listy pozycji ramówkowych na dany dzień tygodnia.

Zapytanie HTTP GET pod adres /api/schedule?date=<date>, gdzie <date> jest datą w formacie <dd-mm-yyyy>.

Zapytanie nie oczekuje JSON-a w zawartości.

13. Wyszukanie listy pozycji ramówkowych na daną datę (jeżeli brak, zostaną wyszukane programy na dzień tygodnia, w jaki przypada dana data).

Zapytanie HTTP GET pod adres /api/schedule?day=<dayNumber>, gdzie <dayNumber> jest numerem dnia tygodnia wg opisu wyżej.

Zapytanie nie oczekuje JSON-a w zawartości.

## Uruchamianie aplikacji

Proszę wpisać do konsoli:

dotnet run

Można też skorzystać z IDE, np. JetBrains Rider czy MS Visual Studio.