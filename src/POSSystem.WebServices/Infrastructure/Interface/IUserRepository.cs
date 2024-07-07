using POSSystem.DataContext.DataContext;

namespace POSSystem.WebServices.Infrastructure.Interface;

public interface IUserRepository
{
	VwListdatastaff GetUser(string username, string password);

	List<VwListdatastaff> GetListStaff();

	//bool CreateStaff(InsertUpdateStaff insertUpdate, VwListdatastaff dataUser);

	//bool UpdateStaff(UpdateStaff insertUpdate, VwListdatastaff dataUser);

	bool DeleteStaff(int userId, VwListdatastaff dataUser);

	//List<VwRoleModuleList> GetModule();

	//List<ModuleList> GetModuleList(GetModuleList param);
}
