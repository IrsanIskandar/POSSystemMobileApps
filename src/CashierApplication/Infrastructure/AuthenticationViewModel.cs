using CashierApplication.Pages;
using CashierApplication.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace CashierApplication.Infrastructure;

public partial class AuthenticationViewModel : BaseViewModel
{
	[ObservableProperty]
	private string _username;

	[ObservableProperty]
	private string _password;

	[RelayCommand]
	public async Task LoginAction()
	{
		if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
		{
			await Application.Current.MainPage.DisplayAlert("Failed Login", "Please check your email and password.", "Close");
			return;
		}
		
		if (Username.ToLower().Equals("admin") && Password.ToLower().Equals("admin"))
		{
			UserDetailViewModel userDetail = new UserDetailViewModel()
			{
				Userid = 1,
				Username = Username,
				Password = Password,
				Personalidentity = "8932746864578234",
				Firstname = "Irsan",
				Lastname = "Putra",
				Fulladdress = "Bekasi Jawa Barat",
				Mobilephone = "0812378645",
				Isactive = true,
				Isactivedesc = "Active",
				Isdeleted = false,
				Isdeleteddesc = "Account Active"
			};

			if (Preferences.ContainsKey(nameof(App.userDetail)))
			{
				Preferences.Remove(nameof(App.userDetail));
			}

			string usrDetailJson = JsonConvert.SerializeObject(userDetail);
			Preferences.Set(nameof(App.userDetail), usrDetailJson);
			App.userDetail = userDetail;

			Username = string.Empty;
			Password = string.Empty;
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
	}
}
