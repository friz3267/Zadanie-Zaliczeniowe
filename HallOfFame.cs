using System;
using System.Collections.Generic;
using System.Linq;

namespace ZgadnijLiczbe
{
    public class HallOfFame
    {
        // ENKAPSULACJA: Lista przechowująca rekordy jest prywatna. 
        // Nie pozwalamy nikomu z zewnątrz bezczelnie w niej grzebać.
        // Modyfikacja listy jest możliwa tylko poprzez publiczne metody tej klasy (AddRecord, Clear).
        private List<PlayerRecord> _records = new List<PlayerRecord>();

        public void AddRecord(PlayerRecord record)
        {
            _records.Add(record);
        }

        public void Clear()
        {
            _records.Clear();
        }

        public bool HasRecords()
        {
            return _records.Count > 0;
        }

        public void Show(Difficulty diff)
        {
            var top5 = _records
                .Where(r => r.GameDifficulty == diff)
                .OrderBy(r => r.Tries)
                .ThenBy(r => r.DurationSeconds) // Sortowanie przy remisach próbowych rozstrzygane na podstawie czasu
                .Take(5)
                .ToList();

            Console.WriteLine("\n--- HALL OF FAME ---");
            foreach (var r in top5)
            {
                string plusStar = r.IsPlusMode ? Translator.Get("[NOWA GRA PLUS]", "[NEW GAME PLUS]") : "";
                string triesTxt = Translator.Get("Próby", "Tries");
                string timeTxt = Translator.Get("Czas", "Time");
                Console.WriteLine($"{r.Name} {plusStar} | {triesTxt}: {r.Tries} | {timeTxt}: {r.DurationSeconds:F2}s");
            }
            Console.WriteLine("--------------------\n");
        }
    }
}