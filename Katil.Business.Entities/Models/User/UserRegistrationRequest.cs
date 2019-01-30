using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Katil.Business.Entities.Models.User
{
    public class UserRegistrationsRequest
    {
        [StringLength(100)]
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
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

        public int? RoleId { get; set; }

        public bool? IsActive { get; set; }
    }
}
