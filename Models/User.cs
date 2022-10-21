using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class User
    {   
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        //Navigation Properties
        
       // public ICollection<Bug> Bugs { get; set; }

    }
}
