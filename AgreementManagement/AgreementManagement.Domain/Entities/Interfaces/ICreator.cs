using AgreementManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Domain.Entities.Interfaces
{
	public interface ICreator
    {
        public Guid CreatedByUserId { get; set; }

        public DateTime CreateDate { get; set; }

        public void SetCreator(Guid userId)
        {
            CreatedByUserId = userId;
            CreateDate = Constants.CurrentTime;
        }
    }
}
