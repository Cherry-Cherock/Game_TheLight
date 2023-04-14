using System.Collections.Generic;

namespace GameConfig
{
    public class BubbleTalkConditonConfig
    {
        public int ID { get; set; }
        public int TalkID { get; set; }
        public bool Condition { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int PreProgress { get; set; }
        public int PlotProgress { get; set; }
        public int Site { get; set; }
        public List<int> StudentID { get; set; }
    }
}
