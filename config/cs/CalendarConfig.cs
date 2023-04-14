using System.Collections.Generic;

namespace GameConfig
{
    public class CalendarConfig
    {
        public int Id { get; set; }
        public int Date { get; set; }
        public List<int> EventsID { get; set; }
        public int Score { get; set; }
        public int Stress { get; set; }
        public int StressGame { get; set; }
        public int StudyGame { get; set; }
    }
}
