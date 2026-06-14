using System;
using System.Diagnostics;

namespace ZgadnijLiczbe
{
    // ABSTRAKCJA: Klasa 'Game' jest abstrakcyjna. Działa jako ogólny wzorzec,
    // ukrywając wspólne mechanizmy gry. Nie można stworzyć obiektu samej "Gry",
    // trzeba stworzyć konkretny tryb (StandardGame lub PlusGame).
    public abstract class Game
    {
        // ENKAPSULACJA: Zmienne są ukryte (protected) przed resztą programu, 
        // dostęp do nich mają tylko klasy dziedziczące po 'Game'.
        protected Difficulty _diff;
        protected int _secretNumber;
        protected int _triesCount;
        protected int _maxRange;
        protected Stopwatch _timer;
        protected Random _rng;

        public Game(Difficulty difficulty)
        {
            _diff = difficulty;
            _rng = new Random();
            _timer = new Stopwatch();
            _triesCount = 0;
            
            if (_diff == Difficulty.Easy) _maxRange = 50;
            else if (_diff == Difficulty.Medium) _maxRange = 100;
            else _maxRange = 250;

            GenerateNumber();
        }

        // ENKAPSULACJA: Metoda pomocnicza ukrywająca mechanizm losowania.
        protected void GenerateNumber()
        {
            _secretNumber = _rng.Next(1, _maxRange + 1);
        }

        // ABSTRAKCJA / POLIMORFIZM: Deklaracja metody abstrakcyjnej. 
        // Każda gra musi mieć metodę Play(), ale każda zrealizuje ją po swojemu.
        public abstract PlayerRecord Play();

        // ENKAPSULACJA: Ukrycie mechaniki wypisywania losowych wiadomości.
        protected void PrintMessage(bool tooSmall)
        {
            string[] smallPl = { "Liczba jest za mała!", "Zbyt niska wartość!", "Podnieś trochę!", "Celuj wyżej!", "Zdecydowanie za mało!" };
            string[] smallEn = { "Number is too small!", "Too low!", "Raise it a bit!", "Aim higher!", "Way too small!" };
            
            string[] bigPl = { "Liczba jest za duża!", "Zbyt wysoka wartość!", "Obniż trochę!", "Celuj niżej!", "Zdecydowanie za dużo!" };
            string[] bigEn = { "Number is too big!", "Too high!", "Lower it a bit!", "Aim lower!", "Way too big!" };

            int index = _rng.Next(5);

            if (tooSmall)
                Console.WriteLine(Translator.Get(smallPl[index], smallEn[index]));
            else
                Console.WriteLine(Translator.Get(bigPl[index], bigEn[index]));
        }
    }
}