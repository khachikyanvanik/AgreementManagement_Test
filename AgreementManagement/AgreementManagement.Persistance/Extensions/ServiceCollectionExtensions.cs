
using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Persistance.Repositories;
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
	}
}
