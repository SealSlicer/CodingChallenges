using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    using CodingChallenges.Strings;
    using CodingChallenges.Trees;

    class Program
    {
         
        static void Main(string[] args)
        {
            var test = "pie  is  a     delicious   food       awesome";

//            MakeLinesProblem.MakeLines(test, 4);

            new TreeTests().TestBst();
        }

        static void WriteWithComma(int value)
        {
            Console.Write(value.ToString()+',');
        }
    }
}
