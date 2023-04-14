using System.Collections.Generic;

namespace GameConfig
{
    public class SkillConfig
    {
        public int Id { get; set; }
        public int SkillType { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int TargetType { get; set; }
        public List<int> Target { get; set; }
        public string Icon { get; set; }
    }
}
