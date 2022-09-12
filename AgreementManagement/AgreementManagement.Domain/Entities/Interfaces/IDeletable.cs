using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Domain.Entities.Interfaces
{
	internal interface IDeletable
	{
		public bool IsDeleted { get; set; }

		public void Delete()
		{
			IsDeleted = true;
		}
	}
}
