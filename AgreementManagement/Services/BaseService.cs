using AgreementManagement.Persistance;
using AutoMapper;

namespace AgreementManagement.Services
{
	public abstract class BaseService
    {
        protected IMapper Mapper;

        public BaseService(
            IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
