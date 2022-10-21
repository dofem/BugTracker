using BugTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.DTO
{
    public class BugDto
    {
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
        
        public User User { get; set; }
    }
}
