# Zgadnij Liczbę 2 

Projekt zaliczeniowy z Podstaw Programowania / Programowania Obiektowego. Jest to sequel klasycznej gry "Zgadnij liczbę", wzbogacony o nowe mechaniki, tryby gry oraz w pełni zrealizowany w podejściu obiektowym (OOP) w języku C#.

## 🚀 Jak uruchomić grę?

1. Upewnij się, że masz zainstalowany **.NET SDK** (zalecana wersja 8.0 lub nowsza).
2. Otwórz terminal (lub wiersz poleceń) i przejdź do folderu z plikami projektu.
3. Wpisz polecenie, aby skompilować i uruchomić grę:
   ```bash
   dotnet run
🎮 Sterowanie
Gra obsługiwana jest wyłącznie za pomocą klawiatury.

Poruszanie się po menu odbywa się poprzez wpisanie odpowiedniej cyfry (np. 1, 2, 3) i wciśnięcie klawisza Enter.

Podczas rozgrywki gracz wpisuje swoje typy liczbowe (liczby całkowite) i zatwierdza je klawiszem Enter.

✨ Możliwości i funkcje gry
Gra oferuje rozbudowane opcje i mechaniki:

Trzy poziomy trudności:

Łatwy (losowanie z przedziału 1-50)

Średni (losowanie z przedziału 1-100)

Trudny (losowanie z przedziału 1-250)

Dwa tryby rozgrywki:

Gra standardowa: Klasyczne odgadywanie liczby.

Nowa Gra Plus: Co określoną liczbę prób (6, 7 lub 8 - w zależności od trudności) ukryta liczba zostaje przelosowana na nowo!

Tryb zakładu: W grze standardowej gracz może (jeśli opcja jest włączona w ustawieniach) zadeklarować maksymalną liczbę prób, w jakich odgadnie liczbę. Przekroczenie limitu oznacza przegraną.

Hall of Fame: Tabela najlepszych wyników, niezależna dla każdego poziomu trudności. Wyświetla TOP 5 graczy sortowanych na podstawie najmniejszej liczby prób, a w przypadku remisów - według czasu rozgrywki w sekundach. Wyniki z "Nowej Gry Plus" są specjalnie wyróżnione.

Ustawienia: Ekran, w którym gracz może na żywo:

Zmienić język gry (Polski / Angielski).

Wyczyścić tabelę rekordów (wymaga potwierdzenia).

Włączyć lub wyłączyć pytanie o zakład.

💻 Zastosowane zasady programowania obiektowego (OOP)
Projekt został podzielony na osobne pliki (jedna klasa na plik) i rygorystycznie przestrzega 4 głównych filarów OOP:

Abstrakcja: Użycie klasy abstrakcyjnej Game, która stanowi szkielet dla innych trybów.

Enkapsulacja: Ukrycie stanu klas (np. pól prywatnych _records, _secretNumber) i udostępnienie ich w kontrolowany sposób.

Dziedziczenie: Klasy StandardGame oraz PlusGame dziedziczą wspólną logikę po bazowej klasie Game.

Polimorfizm: Różne zachowanie metody Play() w zależności od tego, czy wywołana jest z instancji StandardGame czy PlusGame, przy użyciu referencji do klasy bazowej.
