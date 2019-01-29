using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katil.Data.Model
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        
        [StringLength(15)]
        public string Phone { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public bool? IsActive { get; set; }
    }
}
