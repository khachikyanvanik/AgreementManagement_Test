
using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AgreementManagement.Persistance.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IAgreementRepository, AgreementRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductGroupRepository, ProductGroupRepository>();

			return services;
		}

		public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<AgreementManagementDbContext>(optionBuilder =>
			{
				optionBuilder.UseSqlServer(
					connectionString ?? throw new ArgumentException("Connection string is null"));
			});

			return services;
		}
	}
}
