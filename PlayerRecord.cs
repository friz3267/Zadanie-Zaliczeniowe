namespace ZgadnijLiczbe
{
    public class PlayerRecord
    {
        public string Name { get; private set; }
        public int Tries { get; private set; }
        public Difficulty GameDifficulty { get; private set; }
        public double DurationSeconds { get; private set; }
        public bool IsPlusMode { get; private set; }

        public PlayerRecord(string name, int tries, Difficulty diff, double duration, bool isPlus)
        {
            Name = name;
            Tries = tries;
            GameDifficulty = diff;
            DurationSeconds = duration;
            IsPlusMode = isPlus;
        }
    }
}
