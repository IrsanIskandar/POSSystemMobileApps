using POSSystem.DataContext.DataContext;
using POSSystem.DataContext.ViewModels;

namespace POSSystem.WebServices.Infrastructure.Interface;

public interface IUserRepository
{
	VwListdatastaff GetUser(string username, string password);

	List<VwListdatastaff> GetListStaff();

	bool CreateStaff(UserDetailViewModel insertUpdate, VwListdatastaff dataUser);

	bool UpdateStaff(UserDetailViewModel insertUpdate, VwListdatastaff dataUser);

	bool DeleteStaff(int userId, VwListdatastaff dataUser);

	List<VwGetmodulelist> GetModule();

	List<ModuleListViewModel> GetModuleList(int roleId);
}
