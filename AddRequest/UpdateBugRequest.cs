using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.AddRequest
{
    public class UpdateBugRequest
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        [ForeignKey("ChannelId")]
        public int ChannelId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
