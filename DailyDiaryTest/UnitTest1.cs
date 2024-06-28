using System.Runtime.CompilerServices;
using Xunit;
using Daily_Diary;
namespace DailyDiaryTest
{
    public class UnitTest1
    {
        [Fact]
        public void ReadDailyDiaryTest()
        {
            DailyDiary diary = new DailyDiary();
            diary.setFilePath("Test.txt");
            string expectedValue = "This is a Test File";
            string actualValue = diary.ReadDailyDiary();
            Assert.Equal(expectedValue, actualValue);
        }
        [Fact]
        public void AddEntryTest()
        {
            DailyDiary diary2 = new DailyDiary();
            diary2.setFilePath("Test2.txt");
            string fileTextAfterAdd = diary2.AddToDailyDiary("13/10/2001", "This is my birthday");
            string[] arrayToCompare = File.ReadAllLines(diary2.filePath);
            Assert.Equal(4, arrayToCompare.Length);
        }
    }
}