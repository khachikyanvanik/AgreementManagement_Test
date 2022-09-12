using AgreementManagement.Application.Interfaces.Repositories;
using AgreementManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Persistance.Repositories
{
	internal class ProductRepository : BaseRepository<long, Product>, IProductRepository
	{
		public ProductRepository(AgreementManagementDbContext context)
			   : base(context)
		{
		}
	}
}
