using ConsoleTables;

namespace rps
{
    class HelpTable
    {
        public static string getTable(string[] args, Rules rules)
        {
            string[] a = new string[args.Length + 1];
            args.CopyTo(a, 1);
            ConsoleTable consoleTable = new ConsoleTable(a);
            consoleTable.Options.EnableCount = false;
            
            for (int i = 0; i < args.Length; i++)
            {
                string[] row = new string[args.Length + 1];
                row[0] = args[i];
                for (int j = 0; j < args.Length; j++)
                {
                    row[j + 1] = rules.GetGameResult(i, j).ToString();
                }
                consoleTable.AddRow(row);
            }
            return consoleTable.ToString();
        }  
    }
}
