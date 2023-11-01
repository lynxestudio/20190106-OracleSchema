using System;
using System.Data;

namespace Samples.OraSchema
{
    internal static class Util
    {
        internal static void PrintDataTable(DataTable table)
        {
            Console.WriteLine();
            if (table.Rows.Count > 0)
            {
                var columns = table.Columns.Count;
                foreach (DataRow item in table.Rows)
                {
                    for (var i = 0; i < columns; i++)
                    {
                        Console.Write("\t| {0}\t", item[i].ToString());
                        if (i == (columns - 1))
                            Console.WriteLine();
                    }
                }
            }
            else
                Console.WriteLine("No data found.");
        }

        internal static string Prompt(string message)
        {
            string input = null;
            Console.Write("\t" + message);
            input = Console.ReadLine();
            return input;
        }
    }
}
