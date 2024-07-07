namespace CashierApplication.Services;

public partial class AuthenticationService
{
    public AuthenticationService()
    {
        
    }

    public async Task<bool> IsAuthenticatedAsync()
	{
		await Task.Delay(6000);
		string usrDetailString = Preferences.Get(nameof(App.userDetail), "");

		if (string.IsNullOrEmpty(usrDetailString))
		{
			return false;
		}
		else
		{
			return true;
		}
		
	}
}
