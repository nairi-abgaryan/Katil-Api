using System;
using System.ComponentModel.DataAnnotations;
using Katil.Business.Entities.Models.Base;
using Katil.Common.Utilities;

namespace Katil.Business.Entities.Models.User
{
    public abstract class UserRegistrationResponse : CommonResponse
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(250)]
        [Required]
        public string Password { get; set; }

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        
        [StringLength(15)]
        public string Phone { get; set; }

        public bool? IsActive { get; set; }
    }
}
