using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace puzzles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CoderByte puzzles");

            //runAndTestUsername();
            //runAndTestUsernameRegex();

            //runAndTestBracketPairing();

            runAndTestUnion();


        }

        private static void runAndTestUnion()
        {
            FindUnion(["1,2,3,4,5,6", "4,2,7,8,9"]);
        }

        private static void runAndTestBracketPairing()
        {
            foreach (string combo in bracketPairing(3))
                Console.WriteLine(combo);
            foreach (string combo in bracketPairing(4))
                Console.WriteLine(combo);
        }

        private static List<string> bracketPairing(int pairs)
        {
            // param - number of open-close bracket pairs 
            // return - string array of pairs
            Console.WriteLine($"pairs: {pairs}");

            List<string> combinations = new List<string> { "(" };
            int x = 0;
            bool continueIterating = true;
            while (continueIterating)
            {
                combinations = assessNextBracket(pairs, combinations, x);
                x++;
                if (x >= combinations.Count)
                    continueIterating = false;
            }

            Console.WriteLine($"Number of combinations: {combinations.Count}");
            return combinations;
        }

        private static List<string> assessNextBracket(int pairs, List<string> combinations, int currentIndex)
        {
            string v = combinations[currentIndex];
            int openBrackets = pairs - v.Split('(').Length + 1;
            int closeBrackets = pairs - v.Split(')').Length + 1;
            char lastChar = v[v.Length - 1];

            while (openBrackets > 0 || closeBrackets > 0)
            {
                Console.WriteLine($"number of brackets: open:{openBrackets} close:{closeBrackets}");

                if (lastChar == '(')
                {
                    if (openBrackets > 0)
                    {
                        combinations.Add(v + ')');

                        lastChar = '(';
                        v = v + lastChar;
                        openBrackets--;
                    }
                    else
                    {
                        lastChar = ')';
                        v = v + lastChar;
                        closeBrackets--;
                    }
                    //Console.WriteLine($"number of brackets: open:{openBrackets} close:{closeBrackets}");
                }
                else
                {
                    if (openBrackets == closeBrackets)
                    {
                        lastChar = '(';
                        v = v + lastChar;
                        openBrackets--;
                    }
                    else
                    {
                        if (openBrackets > 0)
                            combinations.Add(v + '(');

                        lastChar = ')';
                        v = v + lastChar;
                        closeBrackets--;


                    }
                    //Console.WriteLine($"number of brackets: open:{openBrackets} close:{closeBrackets}");

                }

                //Console.WriteLine($"number of brackets: open:{openBrackets} close:{closeBrackets}");

            }
            combinations[currentIndex] = v;
            return combinations;

        }

        private static void runAndTestUsernameRegex()
        {
            Console.WriteLine(usernameCheckRegex("Sebastian"));
            Console.WriteLine(usernameCheckRegex("Sebastian_Crac3423f34rfg2"));
            Console.WriteLine(usernameCheckRegex("_ebastian_Crustac3423f34rfg34ean2"));
            Console.WriteLine(usernameCheckRegex("%ebastian_Crustac34rfg34ean2"));
            Console.WriteLine(usernameCheckRegex("-ebastian_Crustac$3423f34rfg34ean2"));
            Console.WriteLine(usernameCheckRegex("pom"));
            Console.WriteLine(usernameCheckRegex("pomm"));
            Console.WriteLine(usernameCheckRegex("_pomm"));
            Console.WriteLine(usernameCheckRegex("pom_m"));
            Console.WriteLine(usernameCheckRegex("pom_m_"));
        }

        private static void runAndTestUsername()
        {
            Console.WriteLine(usernameCheck("Sebastian_Crustacean2"));
        }

        private static bool usernameCheckRegex(string v)
        {
            Console.WriteLine("Username Check Regex");

            Console.WriteLine($"processing {v}");
            //string pattern = "[a-zA-Z0-9][A-Za-z0-9_]{2,23}[a-zA-Z0-9]";
            return Regex.IsMatch(v, "^[A-Za-z0-9_]{4,25}$") && !v.StartsWith('_') && !v.EndsWith('_');
        }

        private static bool usernameCheck(string sampleString)
        {
            Console.WriteLine("Username check function");

            int length = sampleString.Length;

            // Rule 1: between 4 and 45 characters long
            if (length < 4 || length > 25)
            {
                Console.WriteLine("fail rule 1");
                return false;
            }

            //Rule 2: must not start with underscore
            if (sampleString.StartsWith('_'))
            {
                Console.WriteLine("fail rule 2");
                return false;
            }

            //Rule 3: must contain only letters, numbers or underscores
            foreach (char c in sampleString)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    Console.WriteLine($"fail rule 3: {c}");
                    return false;
                }
            }

            //Rule 4: must not start with underscore
            if (sampleString.EndsWith('_'))
            {
                Console.WriteLine("fail rule 4");
                return false;
            }

            return true;

        }
    }
}
