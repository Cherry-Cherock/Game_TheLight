using System.Collections.Generic;

namespace GameConfig
{
    public class ItemConfig
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int SubType { get; set; }
        public int UnlockType { get; set; }
        public int Round { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
        public int BuyPrice { get; set; }
        public int Number { get; set; }
        public List<int> Attributes { get; set; }
        public List<float> Talent { get; set; }
        public List<float> Teacher { get; set; }
        public int Sustain { get; set; }
        public string Target { get; set; }
    }
}
