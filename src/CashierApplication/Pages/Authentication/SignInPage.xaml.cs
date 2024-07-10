using CashierApplication.Infrastructure;

namespace CashierApplication.Pages.Authentication;

public partial class SignInPage : ContentPage
{
	public SignInPage(AuthenticationViewModel authentication)
	{
		InitializeComponent();
		this.BindingContext = authentication;
	}

	protected override bool OnBackButtonPressed()
	{
		//Task.Run(async () => await this.Navigation.PushAsync(new LandingPage(), true));
		//return base.OnBackButtonPressed();

		Dispatcher.Dispatch(async () =>
		{
			await Shell.Current.GoToAsync($"//{nameof(LandingPage)}", true);
			//var leave = await DisplayAlert("Leave lobby?", "Are you sure you want to leave the lobby?", "Yes", "No");
			//if (leave)
			//{
			//	await Navigation.PushAsync(new LandingPage(), true);
			//}
		});

		return true;
	}

	private async void ButtonSignInAsync_Clicked(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(TextUsername.Text) && string.IsNullOrWhiteSpace(TextPassword.Text))
		{
			await DisplayAlert("Failed Login", "Please check your email and password.", "Close");
			return;
		}	

		if (TextUsername.Text.Equals("admin") && TextPassword.Text.Equals("admin"))
		{
			TextUsername.Text = string.Empty;
			TextPassword.Text = string.Empty;
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
		}
		else
			await DisplayAlert("Failed Login", "Please check your email and password.", "Close");
	}
}