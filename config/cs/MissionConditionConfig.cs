using System.Collections.Generic;

namespace GameConfig
{
    public class MissionConditionConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int PreProgress { get; set; }
        public string Note { get; set; }
        public int TargetType { get; set; }
        public List<int> Target { get; set; }
        public List<int> Reward { get; set; }
        public List<int> Punish { get; set; }
    }
}
