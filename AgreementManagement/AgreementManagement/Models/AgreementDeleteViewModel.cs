using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgreementManagement.Models
{
    public class AgreementDeleteViewModel
	{
        public int ProductGroupId { get; set; }

        public int ProductId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public long NewPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
