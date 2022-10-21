namespace BugTracker.Models
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public string Name { get; set; }
        //Navigation Properties
        public ICollection<Bug> Bugs { get; set; }  
    }
}
