using System;

namespace ZgadnijLiczbe
{
    public class StandardGame : Game
    {
        private int _betLimit;

        public StandardGame(Difficulty diff, int betLimit) : base(diff)
        {
            _betLimit = betLimit;
        }

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
                    PrintMessage(guess < _secretNumber);
                }
            }
        }
    }
}
