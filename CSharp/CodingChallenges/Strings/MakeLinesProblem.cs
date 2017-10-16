namespace CodingChallenges.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MakeLinesProblem
    {
        public static List<string> MakeLines(string input, int lineLength)
        {
            List<string> lines = new List<string>();

            var startOfLine = 0;
            while (startOfLine < input.Length)
            {
                var endGuess = startOfLine + lineLength;
                var prevSpace = FindPreviousSpace(input, endGuess);
                var nextSpace = FindNextSpace(input, endGuess);
              //  var remainingWordLength = nextSpace - Math.Max(prevSpace, startOfLine);
                var nextNonSpace = FindNextNonSpace(input, endGuess);

                if (endGuess >= input.Length)
                {
                    endGuess = input.Length;
                }
                else if (input[endGuess] == ' ')// || nextNonSpace > endGuess + 1)
                {
                    endGuess = nextNonSpace;
                }
                else if (prevSpace > startOfLine && nextSpace > endGuess + 1)
                {
                    endGuess = prevSpace + 1;
                }
            
                lines.Add(input.Substring(startOfLine, endGuess - startOfLine));
                startOfLine = endGuess;

                Console.WriteLine(lines.Last());
            }

            return lines;
        }

        private static int FindNextSpace(string input, int endGuess)
        {
            do
            {
                endGuess++;
            }
            while (endGuess < input.Length && input[endGuess] != ' ');
            return endGuess;
        }

        private static int FindPreviousSpace(string input, int endGuess)
        {
            do
            {
                endGuess--;
            }
            while (endGuess >= input.Length || (endGuess >= 0 && input[endGuess] != ' '));
            return endGuess;
        }

        private static int FindNextNonSpace(string input, int endGuess)
        {
            do
            {
                endGuess++;
            }
            while (endGuess < input.Length && input[endGuess] == ' ');
            return endGuess;
        }
    }
}