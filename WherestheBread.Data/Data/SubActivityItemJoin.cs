namespace WheresTheBread.Data.Data
{
    public class SubActivityItemJoin
    {
        public int SubActivityId { get; set; }
        public SubActivity SubActivity { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
