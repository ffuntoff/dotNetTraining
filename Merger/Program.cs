using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Merger
{
    class Program
    {

       private static void ReadIntegers(string AFileName, List<int> AIntegersList)
       {
           int FileInteger;
           using (StreamReader reader = File.OpenText(AFileName))
           {
               while (!reader.EndOfStream)
               {
                   if (!Int32.TryParse(reader.ReadLine(), out FileInteger))
                       continue;
                   AIntegersList.Add(FileInteger);
               }
           }
       }

        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error: Please pass two filenames as params");
                return;
            }

            string FilePath1 = args[0];
            if (!File.Exists(FilePath1))
            {
                Console.WriteLine("Error: '" + FilePath1 + "' doesn't exist");
                return;
            }

            string FilePath2 = args[1];
            if (!File.Exists(FilePath2))
            {
                Console.WriteLine("Error: '" + FilePath2 + "' doesn't exist");
                return;
            }

            List<int> IntegersList = new List<int>();
            ReadIntegers(FilePath1, IntegersList);
            ReadIntegers(FilePath2, IntegersList);
            IntegersList.Sort();
            File.WriteAllLines(args[2], IntegersList.Select(q => Convert.ToString(q)));
        }
    }
}
