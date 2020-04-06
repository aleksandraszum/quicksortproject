using System;
using System.IO;

namespace QuickSortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] table = null;
            StartMenu(table);
        }

        // C:\Users\X\source\repos\QuickSortApp\QuickSortApp\bin\Debug\examples\rawdata.txt


        static void StartMenu(string[] table)
        {
            string[] menuPosition = { "Read a file", "Display the table", "Sort the table", "Write sorted table to file", "Clean the table",  "Exit" };
            int currentPosition = 0;
            Console.Title = "Quick Sort Application";

            while (true)
            {
                ShowMenu(menuPosition, currentPosition);
                SelectingOptions(menuPosition, currentPosition,  table);
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

        static void SelectingOptions(string[] position, int currentPosition, string[] table)
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
            RunOptions(currentPosition, table);
        }

        static void RunOptions(int currentPosition, string[] table)
        {
            string[] strTable;
            float[] floatTable;


            switch (currentPosition)
            {
                case 0:
                    if (table == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Give a file-path");
                        string path = Console.ReadLine();
                        table = ReadTable(path);
                        Console.WriteLine("Data has been loaded! \nPress any key to return.");
                        Console.ReadKey();
                        StartMenu(table);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Data has been loaded! Clean the table to load a new file \nPress any key to return.");
                        Console.ReadKey();
                        StartMenu(table);
                        break;
                    }

                case 1:
                    Console.Clear();

                    if (DataTypeCheck(table) == true)
                    {
                        floatTable = DataTypeConversion(table);
                        Console.WriteLine("An array containing data from the loaded file:");
                        ShowTable(floatTable);
                        Console.ReadKey();
                        Console.WriteLine("Press any key to return.");
                        break;
                    }

                    else
                    {
                        strTable = table;
                        Console.WriteLine("An array containing data from the loaded file:");
                        ShowTable(strTable);
                        Console.ReadKey();
                        Console.WriteLine("Press any key to return.");
                        break;
                    }

                case 2: Console.Clear(); Console.WriteLine("Opcja sort table"); Console.ReadKey(); break;

                case 3: 
                    Console.Clear();

                    if (table == null)
                    {
                        Console.WriteLine("Table is empty - no data to write.\n Press any key to return.");
                        Console.ReadKey();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Give the path:");
                        string path2 = Console.ReadLine();
                        Console.WriteLine("Give the filename:");
                        string name = Console.ReadLine();
                        string fileName = path2 + "\\" + name + ".txt";

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
                            
                        Console.WriteLine("Data has been saved. \nPress any key to return.");
                        Console.ReadKey();
                        break;
}
                    

                case 4: 
                    Console.Clear();


                    if (table != null)
                    {
                        table = CleanTable();

                        if (DataTypeCheck(table) == true)
                        {
                            floatTable = CleanFloatTable();
                        }

                        else
                        {
                            strTable = CleanTable();
                        }
                    }

                    else
                    {
                        Console.WriteLine("You don't load the file, so table is empty.");
                    }

                    Console.WriteLine("The data has been cleaned.\nPress any key to return.");
                    Console.ReadKey();
                    StartMenu(table);
                    break;

                case 5: Environment.Exit(0); break;
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
                Console.WriteLine("Table is empty - you don't loaded data or clean the table! \nYou should read the data from a file!");
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
                Console.WriteLine("Table is empty - you don't loaded data or clean the table! \nYou should read the data from a file!");
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

            if (table != null)
            {
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
            }
            

            return condition;

        }

        static float[] DataTypeConversion(string[] table)
        {
            // conversion string table to float table if the data are numbers
            float[] floatTable = null;
            if (table != null)
            {           
                int len = table.Length;
                            floatTable = new float[len];
                            int i = 0;
                            foreach (string item in table)
                            {
                                floatTable[i] = Convert.ToInt32(item);
                                i++;
                            }
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
            string[] table = null;
            return table;
        }

        static float[] CleanFloatTable()
        {
            float[] table = null;
            return table;
        }

    }
}
