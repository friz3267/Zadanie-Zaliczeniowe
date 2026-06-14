using System;

namespace ZgadnijLiczbe
{
    class Program
    {
        static HallOfFame hof = new HallOfFame();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Translator.Get("=== ZGADNIJ LICZBĘ 2 ===", "=== GUESS THE NUMBER 2 ==="));
                Console.WriteLine($"1. {Translator.Get("Nowa Gra", "New Game")}");
                if (hof.HasRecords()) Console.WriteLine("2. Hall of Fame");
                Console.WriteLine($"3. {Translator.Get("Ustawienia", "Settings")}");
                Console.WriteLine($"4. {Translator.Get("Wyjście", "Exit")}");
                Console.Write($"{Translator.Get("Wybierz opcję", "Choose option")}: ");
                
                string choice = Console.ReadLine();

                if (choice == "1") StartGame();
                else if (choice == "2" && hof.HasRecords()) ShowHof();
                else if (choice == "3") SettingsMenu();
                else if (choice == "4") break;
            }
        }

        static void StartGame()
        {
            Console.Clear();
            Console.WriteLine($"1. {Translator.Get("Gra standardowa", "Standard Game")}");
            Console.WriteLine($"2. {Translator.Get("Nowa Gra Plus", "New Game Plus")}");
            Console.Write($"{Translator.Get("Wybierz tryb", "Choose mode")}: ");
            string mode = Console.ReadLine();
            
            Console.WriteLine($"\n1. {Translator.Get("Łatwy", "Easy")} (1-50)");
            Console.WriteLine($"2. {Translator.Get("Średni", "Medium")} (1-100)");
            Console.WriteLine($"3. {Translator.Get("Trudny", "Hard")} (1-250)");
            Console.Write($"{Translator.Get("Wybierz poziom trudności", "Choose difficulty")}: ");
            
            Difficulty diff = Difficulty.Easy;
            string diffChoice = Console.ReadLine();
            if (diffChoice == "2") diff = Difficulty.Medium;
            if (diffChoice == "3") diff = Difficulty.Hard;

            // POLIMORFIZM W AKCJI: Zmienna typu bazowego (Game) może przechowywać obiekt dowolnej 
            // klasy dziedziczącej (StandardGame lub PlusGame). Metoda Play() zachowa się odpowiednio do wyboru.
            Game game = null;

            if (mode == "1")
            {
                int bet = 0;
                if (Settings.AskForBet)
                {
                    Console.Write($"{Translator.Get("Podaj max prób (0 jeśli brak)", "Enter max tries (0 for none)")}: ");
                    int.TryParse(Console.ReadLine(), out bet);
                }
                game = new StandardGame(diff, bet);
            }
            else
            {
                game = new PlusGame(diff);
            }

            Console.Clear();
            PlayerRecord record = game.Play(); // <- To wywołanie to czysty polimorfizm
            if (record != null)
            {
                hof.AddRecord(record);
            }
        }

        static void ShowHof()
        {
            Console.Clear();
            Console.WriteLine(Translator.Get("Wybierz poziom trudności:", "Choose difficulty:"));
            Console.WriteLine($"1. {Translator.Get("Łatwy", "Easy")}");
            Console.WriteLine($"2. {Translator.Get("Średni", "Medium")}");
            Console.WriteLine($"3. {Translator.Get("Trudny", "Hard")}");
            Console.Write($"{Translator.Get("Opcja", "Option")}: ");
            
            Difficulty diff = Difficulty.Easy;
            string diffChoice = Console.ReadLine();
            if (diffChoice == "2") diff = Difficulty.Medium;
            if (diffChoice == "3") diff = Difficulty.Hard;

            hof.Show(diff);
            Console.WriteLine(Translator.Get("Naciśnij Enter, aby wrócić.", "Press Enter to return."));
            Console.ReadLine();
        }

        static void SettingsMenu()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(Translator.Get("=== USTAWIENIA ===", "=== SETTINGS ==="));
                Console.WriteLine($"{Translator.Get("Język", "Language")}: {Settings.CurrentLanguage}");
                Console.WriteLine($"{Translator.Get("Pytaj o zakład", "Ask for bet")}: {(Settings.AskForBet ? Translator.Get("Tak", "Yes") : Translator.Get("Nie", "No"))}");
                Console.WriteLine($"\n1. {Translator.Get("Zmień język (PL/EN)", "Change language (PL/EN)")}");
                Console.WriteLine($"2. {Translator.Get("Wyczyść Hall of Fame", "Clear Hall of Fame")}");
                Console.WriteLine($"3. {Translator.Get("Włącz/Wyłącz zakład", "Toggle bet")}");
                Console.WriteLine($"4. {Translator.Get("Powrót", "Back")}");
                Console.Write($"{Translator.Get("Wybierz opcję", "Choose option")}: ");

                string c = Console.ReadLine();
                if (c == "1") 
                {
                    Settings.CurrentLanguage = Settings.CurrentLanguage == Language.PL ? Language.EN : Language.PL;
                }
                else if (c == "2")
                {
                    Console.Write(Translator.Get("Na pewno? (t/n): ", "Are you sure? (y/n): "));
                    string ans = Console.ReadLine().ToLower();
                    if (ans == "t" || ans == "y") hof.Clear();
                }
                else if (c == "3") 
                {
                    Settings.AskForBet = !Settings.AskForBet;
                }
                else if (c == "4") 
                {
                    break;
                }
            }
        }
    }
}