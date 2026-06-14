using System;

namespace ZgadnijLiczbe
{
    // DZIEDZICZENIE: Podobnie jak 'StandardGame', ten tryb dziedziczy po 'Game'.
    public class PlusGame : Game
    {
        private int _reshuffleLimit;

        public PlusGame(Difficulty diff) : base(diff)
        {
            if (_diff == Difficulty.Easy) _reshuffleLimit = 6;
            else if (_diff == Difficulty.Medium) _reshuffleLimit = 7;
            else _reshuffleLimit = 8;
        }

        // POLIMORFIZM: Nadpisujemy tę samą metodę Play(), co w StandardGame, 
        // ale program wykonuje tu inną logikę (mechanika Nowej Gry Plus z przelosowaniem).
        public override PlayerRecord Play()
        {
            _timer.Start();
            while (true)
            {
                if (_triesCount > 0 && _triesCount % _reshuffleLimit == 0)
                {
                    Console.WriteLine(Translator.Get("UWAGA! Nastąpiło przelosowanie ukrytej liczby!", "WARNING! The secret number has been reshuffled!"));
                    GenerateNumber();
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
                    return new PlayerRecord(name, _triesCount, _diff, _timer.Elapsed.TotalSeconds, true);
                }
                else
                {
                    PrintMessage(guess < _secretNumber);
                }
            }
        }
    }
}