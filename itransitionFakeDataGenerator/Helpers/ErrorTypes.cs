namespace ErrorsType
{
    class Errors
    {
        private static Random _random = new Random();

        public static void SetSeed(int seed)
        {
            _random = new Random(seed);
        }

        public static string Modifier(string s, int errors, string charSet)
        {
            if (errors <= 0 || string.IsNullOrEmpty(s)) return s;

            string stringModified = s;
            for (int i = 0; i < errors; i++)
            {
                int errorType = _random.Next(1, 4);

                if (errorType == 1)
                {
                    stringModified = DeleteCharacter(stringModified);
                }
                else if (errorType == 2)
                {
                    stringModified = AddRandomCharacter(stringModified, charSet);
                }
                else if (errorType == 3)
                {
                    stringModified = SwapCharacters(stringModified);
                }
            }

            return stringModified;
        }

        public static string DeleteCharacter(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0) return s;

            int position = _random.Next(0, s.Length);
            return s[..position] + s[(position + 1)..];
        }

        public static string SwapCharacters(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2) return s;

            int position = _random.Next(0, s.Length - 1);

            char currentChar = s[position];
            char nextChar = s[position + 1];
            return s[..position] + nextChar + currentChar + s[(position + 2)..];
        }

        public static string AddRandomCharacter(string s, string charSet)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string charSetWithNoSpaces = charSet.Replace(" ", "");
            if (charSetWithNoSpaces.Length == 0) return s;

            int position = _random.Next(0, s.Length);
            char randomChar = charSetWithNoSpaces[_random.Next(0, charSetWithNoSpaces.Length)];
            return s[..(position + 1)] + randomChar + s[(position + 1)..];
        }
    }
}