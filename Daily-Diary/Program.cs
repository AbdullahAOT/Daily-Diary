namespace Daily_Diary
{
    public class Program
    {
        static void Main(string[] args)
        {
            DailyDiary();
        }
        public static void DailyDiary()
        {
            Console.WriteLine("Welcome to daily diary application");
            DailyDiary diary = new DailyDiary();
            diary.DailyDiaryModerator();
        }
    }
}
