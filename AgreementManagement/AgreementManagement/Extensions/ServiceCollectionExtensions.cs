using AgreementManagement.Interfaces.Services;
using AgreementManagement.Services;

namespace AgreementManagement.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IAgreementService, AgreementService>();
			services.AddScoped<IProductService, ProductService>();

			return services;
		}
	}
}
