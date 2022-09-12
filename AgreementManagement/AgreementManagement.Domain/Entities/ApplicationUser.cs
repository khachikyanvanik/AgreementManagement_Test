using Microsoft.AspNetCore.Identity;

namespace AgreementManagement.Domain.Entities
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public virtual ICollection<Agreement> Agreements { get; set; }

		public class CustomIdentityRole : IdentityRole<Guid> { }
	}
}
