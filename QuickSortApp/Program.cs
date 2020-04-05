using System;
using System.IO;

namespace QuickSortApp
{
    class Program
    {
        static void Main(string[] args)
        {


          /*  Console.WriteLine("Give a file-path");
            string path = Console.ReadLine();
            Console.WriteLine(path);
            string[] myTable = ReadTable(path);
            ShowTable(myTable);
            Console.WriteLine(myTable);
            string[] strTable = new string [myTable.Length];
            float[] floatTable = new float [myTable.Length];            
            
            if (DataTypeCheck(myTable) == true)
            {
                floatTable = DataTypeConversion(myTable);
            }
            else
            {
                strTable = myTable;
            }

            Console.WriteLine("Give a file-path");
            string mypath = Console.ReadLine();
            Console.WriteLine(mypath);
            WriteTable(mypath, floatTable); */
        }

        // C:\Users\X\source\repos\QuickSortApp\QuickSortApp\bin\Debug\rawdata.txt
        static string[] ReadTable(string path)
        {
            // Reading data from a file
            while (File.Exists(path) == false)
            {
                Console.WriteLine("File not found");
                Console.WriteLine("Give a correct file-path");
                path = Console.ReadLine();
            }

            StreamReader sr = new StreamReader(path);
            string[] RawTable = new string[1];
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                RawTable[0] = RawTable[0] + line;
            }

            string[] StringSeparators = new string[] { " " };
            string Data = RawTable[0];
            RawTable = Data.Split(StringSeparators, StringSplitOptions.None);

            sr.Close();
            Console.WriteLine(RawTable);
            return RawTable;
        }

        static void ShowTable(string[] Table)
        {
            // displaying a table with text data
            int i = 0;
            foreach (string item in Table)
            {
                Console.WriteLine(item);
                i++;
            }
            Console.WriteLine(Table);

        }

        static void ShowTable(float[] Table)
        {
            // displaying a table with numerical data
            int i = 0;
            foreach (float item in Table)
            {
                Console.WriteLine(item);
                i++;
            }
            Console.WriteLine(Table);

        }

        static bool DataTypeCheck(string[] table)
        {
            // true - if the data in tables are numbers
            // false - if the data in tables are string

            float result;
            bool condition = true;

            foreach (string value in table)
            {                    
                condition = true;

                try
                {
                    result = Convert.ToInt32(value);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("jestem w catch");
                    condition = false;
                }
                if (condition == false)
                {
                    break;
                }
            }

            return condition;

        }

        static float[] DataTypeConversion(string[] table)
        {
            // conversion string table to float table if the data are numbers
            int len = table.Length;
            float[] floatTable = new float[len];
            int i = 0;
            foreach (string item in table)
            {
                floatTable[i] = Convert.ToInt32(item);
                i++;
            }
            return floatTable;
        }

        static void WriteTable(string name, string[] table)
        {
            // writing to a sorted array file
            using (StreamWriter writer = new StreamWriter(name))
            {
                int i = 0;
                foreach (string item in table)
                {
                    writer.Write(table[i] + " ");
                    i += 1;
                }
                
            }
        }

        static void WriteTable(string name, float[] table)
        {
            // writing to a sorted array file
            using (StreamWriter writer = new StreamWriter(name))
            {
                int i = 0;
                foreach (float item in table)
                {
                    writer.Write(table[i] + " ");
                    i += 1;
                }

            }

        }

        //static string[] CleanTable(string[] table)
       // {
       // }
    }
}
