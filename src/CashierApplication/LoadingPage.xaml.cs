using CashierApplication.Pages;
using CashierApplication.Pages.Authentication;
using CashierApplication.Services;

namespace CashierApplication;

public partial class LoadingPage : ContentPage
{
	private readonly AuthenticationService _authenticationService;
	public LoadingPage(AuthenticationService authenticationService)
	{
		InitializeComponent();
		_authenticationService = authenticationService;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		if (await _authenticationService.IsAuthenticatedAsync())
		{
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
		else
		{
			//await Shell.Current.GoToAsync($"//{nameof(SignInPage)}");
			await Shell.Current.GoToAsync($"//{nameof(LandingPage)}");
		}
	}
}