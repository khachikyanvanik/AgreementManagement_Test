using AgreementManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Persistance
{
	public class AgreementManagementDbContext : IdentityDbContext
    {
        public AgreementManagementDbContext()
        {
        }

        public AgreementManagementDbContext(DbContextOptions<AgreementManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agreement> Agreements { get; set; } = null!;

		public virtual DbSet<Product> Products { get; set; } = null!;

		public virtual DbSet<ProductGroup> ProductGroups { get; set; } = null!;

#if DEBUG

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
