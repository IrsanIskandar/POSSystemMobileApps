namespace CashierApplication.Pages.Authentication;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
	}

	private async void ButtonToLoginPage_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(SignInPage)}");
	}
}