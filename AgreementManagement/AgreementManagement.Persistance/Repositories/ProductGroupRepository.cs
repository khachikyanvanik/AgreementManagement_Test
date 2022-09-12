using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Persistance.Repositories
{
	internal class ProductGroupRepository : BaseRepository<long, ProductGroup>, IProductGroupRepository
	{
		public ProductGroupRepository(AgreementManagementDbContext context)
			   : base(context)
		{
		}
	}
}
