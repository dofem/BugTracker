using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Bug
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        [ForeignKey("ChannelId")]
        public int ChannelId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        //Navigation Properties
        public Channel Channel { get; set; }  
        public User User { get; set; }
    }
}
