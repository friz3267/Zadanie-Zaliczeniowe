namespace ZgadnijLiczbe
{
    public static class Translator
    {
        public static string Get(string textPl, string textEn)
        {
            return Settings.CurrentLanguage == Language.PL ? textPl : textEn;
        }
    }
}