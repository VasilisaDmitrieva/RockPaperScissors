using System;
using System.Linq;

namespace rps
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 != 1)
            {
                Console.WriteLine("Error: Wrong number of arguments. Should be more than three and odd number.");
                return;
            }

            if (args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Error: Arguments must have different values.");
                return;
            }

            Random random = new Random();

            HashGenerate hashGenerate = new HashGenerate();
            int move = random.Next(args.Length);
            Console.WriteLine("HMAC: " + hashGenerate.hmac(args[move]));

            Rules rules = new Rules(args.Length);
            while (true)
            {
                Console.WriteLine("Available moves:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine((i + 1) + " - " + args[i]);
                }
                Console.WriteLine("0 - exit");
                Console.WriteLine("? - help");

                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "0":
                        return;
                    case "?":
                        Console.WriteLine(HelpTable.getTable(args, rules));
                        break;
                }

                try
                {
                    int x = Int32.Parse(ans) - 1;

                    if (x >= 0 && x < args.Length) {
                        Console.WriteLine("Your move: " + args[x]);
                        Console.WriteLine("Computer move: " + args[move]);

                        Console.WriteLine("Game result: " + rules.GetGameResult(x, move));
                        Console.WriteLine("HMAC key: " + hashGenerate.getKey());
                    }
                    return;
                }
                catch (FormatException)
                {
                    // ignored
                }
                Console.WriteLine("Input string is invalid.");
            }
        }   
    }
}
