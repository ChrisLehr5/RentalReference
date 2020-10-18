using Microsoft.EntityFrameworkCore;

namespace ReferenceReferralApp.Models
{
	public class ReferenceContext : DbContext
	{
		public ReferenceContext(DbContextOptions<ReferenceContext> options) : base(options)
		{ }
		public DbSet<Reference> References { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Reference>().HasData(
				new Reference
				{
					ID = 1,
					firstName = "Brett",
					lastName = "Maiki",
					email = "Brett@email,com"
				},
				new Reference
				{
					ID = 2,
					firstName = "Brad",
					lastName = "Maiki",
					email = "Brett@email,com"
				},
				new Reference
				{
					ID = 3,
					firstName = "Sally",
					lastName = "Maiki",
					email = "Brett@email,com"
				}
				);

		}
	}
}
