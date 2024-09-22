namespace ErrorsType
{
    class Errors
    {

        //This class generate errors only if the number of errors are greater than 0
        public static string Modifier(string s, int errors, string charSet)
        {
            string stringModified = s;
            if(errors > 0) {
                for (int i = 0; i <= errors; i++)
                {
                    //Choose the error type
                    int errorType = new Random().Next(1, 4);
                    //delete character in random position
                    if(errorType == 1) {
                        stringModified = DeleteCharacter(stringModified, errors);
                    }
                    //add random character (from a proper alphabet) in random position
                    else if(errorType == 2) {
                        stringModified = AddRandomCharacter(stringModified, errors, charSet);
                    }
                    //swap near characters
                    else if(errorType == 3) {
                        stringModified = SwapCharacters(stringModified, errors);
                    }
                }
            }
            
            return stringModified;
        }

        public static string DeleteCharacter(string s, int probability)
        {
            Random rand = new Random();
            string newS = s;

            if(newS.Length == 0) return "";

            if(rand.Next() > probability)
            {
                //Select a random position
                int position = rand.Next(0, newS.Length);
                newS = newS[..position] + newS[(position+1)..];
            }
            return newS;
        }

        public static string SwapCharacters(string s, int probability)
        {
            Random rand = new Random();
            string newS = s;

            if(rand.Next() > probability)
            {
                int position = rand.Next(0, newS.Length);

                if(newS.Length < 2) return "";

                if(position == newS.Length -1) {
                    char currentChar = newS[position];
                    char prevChar = newS[position-1];
                    newS = newS[..(position-1)] + currentChar + prevChar;
                } else {
                    char currentChar = newS[position];
                    char nextChar = newS[position+1];
                    newS = newS[..position] + nextChar + currentChar + newS[(position + 2)..];
                }
            }
            return newS;
        }
        
        public static string AddRandomCharacter(string s, int probability, string charSet)
        {
            Random rand = new Random();
            string newS = s;
            string charSetWithNoSpaces = charSet.Replace(" ", "");

            if(newS.Length == 0) return "";

            if(rand.Next() > probability)
            {
                int position = rand.Next(0, newS.Length);
                newS = newS[..(position+1)] + charSetWithNoSpaces[rand.Next(0, charSetWithNoSpaces.Length)] + newS[(position+1)..];
            }
            return newS;
        }
    }
}