using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class DailyDiary
    {
        public string filePath;
        public DailyDiary()
        {
            filePath = Path.Combine(Environment.CurrentDirectory, "Diary.txt");
        }
        public void DailyDiaryModerator()
        {
            string doAnotherOperation = "yes";
            while (doAnotherOperation == "yes")
            {
                Console.WriteLine("If you want to read the Diary, enter read.\n" +
                "If you want to add entries, enter add.\n" +
                "If you want delete specific entries, enter delete.\n" +
                "if you want to count the number of lines in the diary, enter count.");
                string userOperation = Console.ReadLine();
                while (userOperation.ToLower() != "read" && userOperation.ToLower() != "add"
                    && userOperation.ToLower() != "delete" && userOperation.ToLower() != "count")
                {
                    Console.WriteLine("Please enter a valid type of operation: ");
                    userOperation = Console.ReadLine();
                }
                if (userOperation.ToLower() == "read")
                {
                    Console.WriteLine($"This is the diary content:\n{ReadDailyDiary()}");
                }
                else if (userOperation.ToLower() == "add")
                {
                    Console.WriteLine("Please enter the date of entry: ");
                    string date = Console.ReadLine();
                    Console.WriteLine("Please enter the content of entry: ");
                    string content = Console.ReadLine();
                    Entry entry = new Entry(date, content);
                    Console.WriteLine($"This is the updated diary content:\n{AddToDailyDiary(entry.dateOfEntry, entry.contentOfEntry)}");
                }
                else if (userOperation.ToLower() == "delete")
                {
                    Console.WriteLine("Please enter the date of entry to delete: ");
                    string date = Console.ReadLine();
                    Console.WriteLine($"This is the updated diary content:\n{DeleteEntry(date)}");
                }
                else
                {
                    Console.WriteLine($"This is the total number of lines in the diary: {LinesCount()}");
                }
                Console.WriteLine("do you want to do another operation on the diary? please enter yes or no only.");
                doAnotherOperation = Console.ReadLine();
            }
        }
        public string ReadDailyDiary()
        {
            string contentToRead = File.ReadAllText(filePath);
            return contentToRead;
        }
        public string AddToDailyDiary(string date, string content)
        {
            File.AppendAllText(filePath, $"\n{date}");
            File.AppendAllText(filePath, $"\n{content}");
            File.AppendAllText(filePath, "\n------------------------------");
            return ReadDailyDiary();
        }
        public string DeleteEntry(string date)
        {
            List<string> ListOfLines = File.ReadAllLines(filePath).ToList();
            bool entryFound = false;
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < ListOfLines.Count; i++)
            {
                if (ListOfLines[i] == date)
                {
                    entryFound = true;
                    startIndex = i;
                }
                if (entryFound && ListOfLines[i] == "------------------------------")
                {
                    endIndex = i;
                    break;
                }
            }
            if (entryFound)
            {
                ListOfLines.RemoveRange(startIndex, endIndex - startIndex + 1);
            }
            string content = string.Join(Environment.NewLine, ListOfLines);
            File.WriteAllText(filePath, content);
            return ReadDailyDiary();
        }
        public int LinesCount()
        {
            string[] arrayOfLines = File.ReadAllLines(filePath);
            return arrayOfLines.Length;
        }
        public void setFilePath(string filePath)
        {
            this.filePath = Path.Combine(Environment.CurrentDirectory, filePath);
        }
    }
}
