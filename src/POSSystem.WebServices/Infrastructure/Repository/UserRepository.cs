using Microsoft.EntityFrameworkCore;
using POSSystem.DataContext.DataContext;
using POSSystem.DataContext.ViewModels;
using POSSystem.WebServices.Infrastructure.Interface;
using System.Text;

namespace POSSystem.WebServices.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
	private readonly PossystemContext _possystemContext;

	public UserRepository(PossystemContext possystemContext)
	{
		_possystemContext = possystemContext;
	}

	public List<VwListdatastaff> GetListStaff()
	{
		return _possystemContext.VwListdatastaffs.ToList();
	}

	public VwListdatastaff GetUser(string username, string password)
	{
		return _possystemContext.VwListdatastaffs.Where(w => w.Username == username && w.Password == password).SingleOrDefault();
	}

	public List<VwGetmodulelist> GetModule()
	{
		return _possystemContext.VwGetmodulelists.ToList();
	}

	public List<ModuleListViewModel> GetModuleList(int roleId)
	{
		List<ModuleListViewModel> listModul = new List<ModuleListViewModel>();
		List<VwGetmodulelist> dataParent = GetModule().Where(w => w.ParentId == null).Where(w => w.RoleId == roleId).ToList();
		foreach (var dataParentModul in dataParent)
		{
			ModuleListViewModel ModuleParent = new ModuleListViewModel();
			ModuleParent.ModuleId = dataParentModul.ModuleId;
			ModuleParent.ModuleName = dataParentModul.ModuleName;
			ModuleParent.ModuleIcon = dataParentModul.ModuleIcon;
			ModuleParent.ModuleDescription = dataParentModul.ModuleDescription;
			ModuleParent.ParentId = dataParentModul.ParentId;
			ModuleParent.RoleId = dataParentModul.RoleId;
			ModuleParent.RoleName = dataParentModul.RoleName;
			ModuleParent.Createdby = dataParentModul.Createdby;
			ModuleParent.CreatedDate = dataParentModul.CreatedDate;
			ModuleParent.ModifiedBy = dataParentModul.ModifiedBy;
			ModuleParent.ModifiedDate = dataParentModul.ModifiedDate;
			List<VwGetmodulelist> datachild1 = GetModule().Where(w => w.ParentId == ModuleParent.ModuleId).Where(w => w.RoleId == roleId).ToList();
			if (datachild1.Count > 0)
			{
				foreach (var child1 in datachild1)
				{
					ModuleListViewModel ModuleChild1 = new ModuleListViewModel();
					ModuleChild1.ModuleId = child1.ModuleId;
					ModuleChild1.ModuleName = child1.ModuleName;
					ModuleChild1.ModuleIcon = child1.ModuleIcon;
					ModuleChild1.ModuleDescription = child1.ModuleDescription;
					ModuleChild1.ParentId = child1.ParentId;
					ModuleChild1.RoleId = child1.RoleId;
					ModuleChild1.RoleName = child1.RoleName;
					ModuleChild1.Createdby = child1.Createdby;
					ModuleChild1.CreatedDate = child1.CreatedDate;
					ModuleChild1.ModifiedBy = child1.ModifiedBy;
					ModuleChild1.ModifiedDate = child1.ModifiedDate;

					ModuleParent.ChildModuleLists.Add(ModuleChild1);
				}
			}

			listModul.Add(ModuleParent);
		}

		return listModul;
	}

	public bool CreateStaff(UserDetailViewModel insertData, VwListdatastaff dataUser)
	{
		User getStaff = new User();
		byte[] baSalt = Encoding.ASCII.GetBytes(insertData.Username);
		string salt = Convert.ToBase64String(baSalt);
		string passwordHash = SandevLibrary.SecurityAlgorithm.AESAlgorithm.EncryptTextWithSalt(insertData.Password, salt);

		short getPermissionId = 0;

		getStaff.Username = insertData.Username.ToLower();
		getStaff.Emailaddress = insertData.Emailaddress;
		getStaff.Password = passwordHash;
		getStaff.Salt = salt;
		getStaff.Roleid = insertData.RoleId;
		getStaff.Createdby = dataUser.Userid.ToString();
		_possystemContext.Entry(getStaff).State = EntityState.Added;
		int resStaff = _possystemContext.SaveChanges();
		int getStaffId = getStaff.Id;
		if (resStaff >= 0 && getStaffId > 0)
		{
			Userdetail getStaffDetail = new Userdetail();
			getStaffDetail.Firstname = insertData.Firstname;
			getStaffDetail.Lastname = insertData.Lastname;
			getStaffDetail.Nikorpassport = insertData.Personalidentity;
			getStaffDetail.Userid = getStaffId;
			getStaffDetail.Fulladdress = insertData.Fulladdress;
			getStaffDetail.Genderid = insertData.Genderid;
			getStaffDetail.Mobilephone = insertData.Mobilephone;
			getStaffDetail.Createdby = dataUser.Userid.ToString();
			_possystemContext.Entry(getStaffDetail).State = EntityState.Added;

			int res = _possystemContext.SaveChanges();
			if (res >= 0)
				return true;
			else
				return false;
		}
		else
			return false;
	}

	public bool UpdateStaff(UserDetailViewModel updateData, VwListdatastaff dataUser)
	{
		var getStaff = _possystemContext.Users.Where(w => w.Id == updateData.Userid).SingleOrDefault();
		var getStaffDetail = _possystemContext.Userdetails.Where(w => w.Userid == getStaff.Id).FirstOrDefault();
		if (getStaff is not null && getStaffDetail is not null)
		{
			getStaff.Username = updateData.Username;
			getStaff.Emailaddress = updateData.Emailaddress;
			getStaff.Roleid = updateData.RoleId;

			getStaffDetail.Nikorpassport = updateData.Personalidentity;
			getStaffDetail.Firstname = updateData.Firstname;
			getStaffDetail.Lastname = updateData.Lastname;
			getStaffDetail.Fulladdress = updateData.Fulladdress;
			getStaffDetail.Mobilephone = updateData.Mobilephone;
			getStaffDetail.Modifyby = dataUser.Username;
			getStaffDetail.Modifydate = DateTime.Now;

			_possystemContext.Entry(getStaff).State = EntityState.Modified;
			_possystemContext.Entry(getStaffDetail).State = EntityState.Modified;

			int res = _possystemContext.SaveChanges();
			if (res >= 0)
				return true;
			else
				return false;
		}
		else
			return false;
	}

	public bool DeleteStaff(int userId, VwListdatastaff dataUser)
	{
		var getStaff = _possystemContext.Users.Where(w => w.Id == userId).SingleOrDefault();
		var getStaffDetail = _possystemContext.Userdetails.Where(w => w.Userid == getStaff.Id).FirstOrDefault();
		if (getStaff is not null && getStaffDetail is not null)
		{
			getStaff.Isactive = false;
			_possystemContext.Entry(getStaff).State = EntityState.Modified;

			getStaffDetail.Isdeleted = false;
			getStaffDetail.Modifyby = dataUser.Userid.ToString();
			getStaffDetail.Modifydate = DateTime.Now;
			_possystemContext.Entry(getStaffDetail).State = EntityState.Modified;

			int res = _possystemContext.SaveChanges();
			if (res >= 0)
				return true;
			else
				return false;
		}
		else
			return false;
	}
}
