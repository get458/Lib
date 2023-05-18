using Lib;

namespace LibTests
{
    
    public class UnitTest1
    {
        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To18With30MinutesConsultationTime_ShouldReturn14Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(15), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = { 60, 30, 10, 10, 40 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 30);

            Assert.Equal(14, test.Length);
        }
        
        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To14AndAHalfWith15MinutesConsultationTime_ShouldReturn20Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8), TimeSpan.FromHours(9), TimeSpan.FromHours(10), new TimeSpan(13, 30, 0), TimeSpan.FromHours(14),
                new TimeSpan(16, 50, 0), new TimeSpan(17, 20, 0) };
            int[] durations = { 5, 10, 10, 7, 40, 50, 5 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(14.5), 15);

            string[] expected = new string[] {"08:05-08:20", "08:20-08:35", "08:35-08:50", "09:10-09:25",
                "09:25-09:40", "09:40-09:55", "10:10-10:25", "10:25-10:40",
                "10:40-10:55", "10:55-11:10", "11:10-11:25", "11:25-11:40",
                "11:40-11:55", "11:55-12:10", "12:10-12:25", "12:25-12:40",
                "12:40-12:55", "12:55-13:10", "13:10-13:25", "13:37-13:52"};

            Assert.Equal(expected, test);
        }
        
    }
}