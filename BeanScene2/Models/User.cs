using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanScene2.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Display(Name = "User Name")]

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? ProfilePicture { get; set; }


        //Relationship

        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permission? Permission { get; set; }


        
    }
}
