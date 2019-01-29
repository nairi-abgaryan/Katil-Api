using System.ComponentModel.DataAnnotations;

namespace Katil.Data.Model
{
	public class Role
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string RoleDescritption { get; set; }
	}
}
