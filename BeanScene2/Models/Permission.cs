using System.ComponentModel.DataAnnotations;

namespace BeanScene2.Models
{
    public class Permission
    {
        [Key]
        [Display(Name = "Permission ID")]

        public int PermissionId { get; set; }
        [Display(Name = "Can Read")]

        public string CanRead { get; set; }
        [Display(Name = "Can Create")]

        public string CanCreate { get; set; }
        [Display(Name = "Can Update")]

        public string CanUpdate { get; set; }
        [Display(Name = "Can Delete")]

        public string CanDelete { get; set; }

        //Relationships
        public List<User>? Users { get; set; }
    }
}
