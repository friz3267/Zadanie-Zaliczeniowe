using System;

namespace ZgadnijLiczbe
{
    // DZIEDZICZENIE: 'StandardGame' przejmuje (dziedziczy) wszystkie właściwości po abstrakcyjnej klasie 'Game'.
    public class StandardGame : Game
    {
        // ENKAPSULACJA: Hermetyzacja specyficznej dla tego trybu zmiennej.
        private int _betLimit;

        // DZIEDZICZENIE: Przekazanie zmiennej 'diff' do konstruktora klasy bazowej ('base').
        public StandardGame(Difficulty diff, int betLimit) : base(diff)
        {
            _betLimit = betLimit;
        }

        // POLIMORFIZM: Nadpisanie (override) metody Play(). Tu znajduje się implementacja dla trybu standardowego.
        public override PlayerRecord Play()
        {
            _timer.Start();
            while (true)
            {
                if (_betLimit > 0 && _triesCount >= _betLimit)
                {
                    Console.WriteLine(Translator.Get("Przekroczono limit prób. Przegrana.", "Try limit exceeded. You lose."));
                    return null;
                }

                _triesCount++;
                Console.WriteLine($"\n{Translator.Get("Aktualna próba", "Current try")}: {_triesCount}");
                Console.Write($"{Translator.Get("Zgadnij liczbę", "Guess the number")} (1-{_maxRange}): ");
                
                if (!int.TryParse(Console.ReadLine(), out int guess)) continue;

                if (guess == _secretNumber)
                {
                    _timer.Stop();
                    Console.Write(Translator.Get("Trafiono! Podaj swoje imię: ", "Hit! Enter your name: "));
                    string name = Console.ReadLine();
                    return new PlayerRecord(name, _triesCount, _diff, _timer.Elapsed.TotalSeconds, false);
                }
                else
                {
                    PrintMessage(guess < _secretNumber); // Użycie metody z klasy bazowej
                }
            }
        }
    }
}