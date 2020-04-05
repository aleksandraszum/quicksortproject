using System;
using System.IO;

namespace QuickSortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // default menu - Menu 1
            string[] table = null;
            StartMenu1(table);
        }

        // C:\Users\X\source\repos\QuickSortApp\QuickSortApp\bin\Debug\examples\rawdata.txt

        static void StartMenu1(string[] table)
        {
            string[] menuPosition = { "Read a file", "Exit"};
            int currentPosition = 0;
            int menuType = 1;
            Console.Title = "Quick Sort Application";

            while (true)
            {
                ShowMenu(menuPosition, currentPosition);
                SelectingOptions(menuPosition, currentPosition, menuType, table);
            }
        }

        static void StartMenu2(string[] table)
        {
            string[] menuPosition = { "Display table", "Sort table", "Write sorted table to file", "Clean table",  "Exit" };
            int currentPosition = 0;
            int menuType = 2;
            Console.Title = "Quick Sort Application";

            while (true)
            {
                ShowMenu(menuPosition, currentPosition);
                SelectingOptions(menuPosition, currentPosition, menuType, table);
            }

        }

        static void ShowMenu(string[] position, int currentPosition)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome to Quick Sort App. In this program you can \n" +
                "- read the data from file \n" +
                "- save the data into table \n" +
                "- sort the data \n" +
                "- clean the table \n" +
                "- save the sorted table to file");
            Console.WriteLine();

            for (int i = 0; i < position.Length; i++)
            {

                if (i == currentPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(position[i]);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }

                else
                {
                    Console.WriteLine(position[i]);
                }
            }
        }

        static void SelectingOptions(string[] position, int currentPosition, int menu, string[] table)
        {

            do
            {
                ConsoleKeyInfo buttom = Console.ReadKey();

                if (buttom.Key == ConsoleKey.UpArrow)
                {
                    currentPosition = (currentPosition > 0) ? currentPosition - 1 : position.Length - 1;
                    ShowMenu(position, currentPosition);
                }

                else if (buttom.Key == ConsoleKey.DownArrow)
                {
                    currentPosition = (currentPosition + 1) % position.Length;
                    ShowMenu(position, currentPosition);
                }

                else if (buttom.Key == ConsoleKey.Escape)
                {
                    currentPosition = position.Length - 1;
                    break;
                }

                else if (buttom.Key == ConsoleKey.Enter)
                {
                    break;
                }
                
            }
            while (true);
            RunOptions(currentPosition, menu, table);
        }

        static void RunOptions(int currentPosition, int menu, string[] table)
        {
            string[] strTable;
            float[] floatTable;


            if (menu == 1)
            {
                switch (currentPosition)
                {
                    case 0: Console.Clear();
                        Console.WriteLine("Give a file-path");
                        string path = Console.ReadLine();
                        table = ReadTable(path); 
                        Console.WriteLine("Data has been loaded! \nPress any key");                        
                        Console.ReadKey();
                        StartMenu2(table);
                        break;
                        
                    case 1: Environment.Exit(0); break;
                }
            }
           
            else
            {
                switch (currentPosition)
                {
                    case 0: 
                        Console.Clear();

                        if (DataTypeCheck(table) == true)
                        {
                            floatTable = DataTypeConversion(table);
                            Console.WriteLine("An array containing data from the loaded file:");
                            ShowTable(floatTable);
                            Console.ReadKey();
                            Console.WriteLine("Press any key");
                            break;
                        }

                        else
                        {
                            strTable = table;
                            Console.WriteLine("An array containing data from the loaded file:");
                            ShowTable(strTable);
                            Console.ReadKey();
                            Console.WriteLine("Press any key");
                            break;
                        }

                    case 1: Console.Clear(); Console.WriteLine("Opcja sort table"); Console.ReadKey(); break;

                    case 2: Console.Clear(); 
                        Console.WriteLine("Give the path:");
                        string path = Console.ReadLine();
                        Console.WriteLine("Give the filename:");
                        string name = Console.ReadLine();
                        string fileName = path + "\\" + name + ".txt";

                        if (DataTypeCheck(table) == true)
                        {
                            floatTable = DataTypeConversion(table);
                            WriteTable(fileName, floatTable);
                        }
                        else
                        {
                            strTable = table;
                            WriteTable(fileName, strTable);
                        }
                            
                        Console.WriteLine("Data has been saved. \nPress any key");
                        Console.ReadKey();
                        break;

                    case 3: 
                        Console.Clear();

                        if (DataTypeCheck(table) == true)
                        {
                            floatTable = CleanFloatTable();
                            Console.WriteLine("Show table function:");
                            ShowTable(floatTable);
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                        }

                        else
                        {
                            strTable = CleanTable();
                            Console.WriteLine("Show table function:");
                            ShowTable(strTable);
                            Console.WriteLine("Press any key");
                            Console.ReadKey();
                        }                            

                        StartMenu1(table);
                        break;

                    case 4: Environment.Exit(0); break;
                }
            }
            

        }
        static string[] ReadTable(string path)
        {
            // Reading data from a file

            while (File.Exists(path) == false)
            {
                Console.WriteLine("File not found! \nGive a correct file-path");
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
            return RawTable;
        }

        static void ShowTable(string[] table)
        {
            // displaying a table with text data
            int i = 0;

            if (table == null)
            {
                Console.WriteLine("Table is empty!");
            }

            else
            {
                foreach (string item in table)
                {
                    Console.WriteLine(item);
                    i++;
                }

            }

        }

        static void ShowTable(float[] table)
        {
            // displaying a table with numerical data
            int i = 0;

            if (table == null)
            {
                Console.WriteLine("Table is empty!");
            }

            else
            {
                foreach (float item in table)
                {
                 Console.WriteLine(item);
                    i++;
                }
            }

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

        static string[] CleanTable()
        {
            Console.WriteLine("The table has been cleaned.");
            string[] table = null;
            return table;
        }

        static float[] CleanFloatTable()
        {
            Console.WriteLine("The table has been cleaned.");
            float[] table = null;
            return table;
        }

    }
}
