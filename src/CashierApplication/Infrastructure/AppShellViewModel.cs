using CashierApplication.Pages.Authentication;
using CommunityToolkit.Mvvm.Input;

namespace CashierApplication.Infrastructure;

public partial class AppShellViewModel : BaseViewModel
{
	[RelayCommand]
	public async Task SignoutAction()
	{
		if (Preferences.ContainsKey(nameof(App.userDetail)))
		{
			Preferences.Remove(nameof(App.userDetail));
		}

		await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}");
	}
}
