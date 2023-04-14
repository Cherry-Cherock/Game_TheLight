namespace GameConfig
{
    public class ConversationConditionConfig
    {
        public int Id { get; set; }
        public int CharacterID { get; set; }
        public string ConversationName { get; set; }
        public bool Auto { get; set; }
        public int PlotProgress { get; set; }
        public int Amity { get; set; }
        public int Stress { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int PreProgress { get; set; }
        public string Site { get; set; }
    }
}
