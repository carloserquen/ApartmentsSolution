using System.Text;
using System.IO;
using System;

namespace UploadData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the file name to convert aws format: ");
            string FileName = Console.ReadLine();
            Console.WriteLine("Write file's path: ");
            string FilePath = Console.ReadLine();

            int CounterIndex = 0;
            int CounterLine = 0;
            string Line;

            StreamReader file = new StreamReader(@FilePath + '\\' + FileName + ".json");
            String[] NewWrite = new String[36000];

            while ((Line = file.ReadLine()) != null)
            {
                if (Line == "[" || Line == "]") CounterLine = 0;
                else
                {
                    if (Line.Trim() == "{")
                    {
                        NewWrite[CounterLine] = "{ \"index\" : { \"_index\": \"" + FileName + "\", \"_id\" : \"" + CounterIndex + "\" } }";
                        CounterIndex++;
                        CounterLine++;
                        NewWrite[CounterLine] = Line.Trim();
                    }
                    else
                    {
                        if (Line.Trim() == "},")
                        {
                            NewWrite[CounterLine] = NewWrite[CounterLine] + "}";
                            CounterLine++;
                        }
                        else NewWrite[CounterLine] = NewWrite[CounterLine] + Line;
                    }
                }
            }

            file.Close();

            string path = @FilePath + "\\" + "bulk_" + FileName + "_1.json";
            File.AppendAllLines(path, NewWrite, Encoding.UTF8);
        }
    }
}
