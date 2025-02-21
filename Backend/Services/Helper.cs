namespace Backend.Services
{
    public static class Helper
    {
        public static string CapitalizeAllFirstLetters(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // Deljenje teksta na reči
            var words = text.Split(' ');

            // Kapitalizacija svake reči
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            // Spajanje reči nazad u tekst
            return string.Join(" ", words);
        }
        public static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // Pretvaramo ceo tekst u mala slova
            text = text.ToLower();

            // Kapitalizujemo prvo slovo rečenice
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        public static string ToLowerCase(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;
            return name.ToLower();
        }

        public static string CapitalizeFirstLetterAfterPunctuation(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = text.ToLower();

            char[] result = text.ToCharArray();
            bool capitalizeNext = true;

            for (int i = 0; i < result.Length; i++)
            {
                if (capitalizeNext && Char.IsLetter(result[i]))
                {
                    result[i] = Char.ToUpper(result[i]);
                    capitalizeNext = false;
                }

                else if (result[i] == '.' || result[i] == '?')
                {
                    capitalizeNext = true;
                }
            }

            return new string(result);
        }
    }
}


