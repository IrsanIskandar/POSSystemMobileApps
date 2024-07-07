using Microsoft.EntityFrameworkCore;
using POSSystem.DataContext.DataContext;
using POSSystem.WebServices.Infrastructure.Interface;

namespace POSSystem.WebServices.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
	private readonly PossystemContext _possystemContext;

	public UserRepository(PossystemContext possystemContext)
	{
		_possystemContext = possystemContext;
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

	public List<VwListdatastaff> GetListStaff()
	{
		return _possystemContext.VwListdatastaffs.ToList();
	}

	public VwListdatastaff GetUser(string username, string password)
	{
		return _possystemContext.VwListdatastaffs.Where(w => w.Username == username && w.Password == password).SingleOrDefault();
	}
}
