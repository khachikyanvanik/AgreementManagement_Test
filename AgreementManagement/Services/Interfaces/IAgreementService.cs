using AgreementManagement.Models;

namespace AgreementManagement.Interfaces.Services
{
	public interface IAgreementService
	{
		Task CreateAgreementAsync(Guid userId, AgreementCreationViewModel model);
		Task UpdateAgreementAsync(Guid userId, AgreementUpdateViewModel model);
		Task RemoveAgreementAsync(int agreementId);
		Task<T> GetAgreementAsync<T>(int id);
		Task<DataTableCriteria<AgreementViewModel>> GetAgreementListAsync(DataTableCriteria<AgreementViewModel> criteria);
	}
}
