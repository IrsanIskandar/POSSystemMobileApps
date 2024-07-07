namespace CashierApplication.ViewModels;

public class UserDetailViewModel
{
	public int? Userid { get; set; }

	public string? Username { get; set; }

	public string? Emailaddress { get; set; }

	public DateTime? Lastlogindate { get; set; }

	public bool? Isconfirmationaccount { get; set; }

	public string? Personalidentity { get; set; }

	public string? Firstname { get; set; }

	public string? Lastname { get; set; }

	public string? Fulladdress { get; set; }

	public int? Genderid { get; set; }

	public string? Gendername { get; set; }

	public string? Mobilephone { get; set; }

	public string? Password { get; set; }

	public string? Salt { get; set; }

	public bool? Isactive { get; set; }

	public string? Isactivedesc { get; set; }

	public bool? Isdeleted { get; set; }

	public string? Isdeleteddesc { get; set; }

	public string? Createdby { get; set; }

	public DateTime? Createddate { get; set; }

	public string? Modifiedby { get; set; }

	public DateTime? Modifieddate { get; set; }
}
