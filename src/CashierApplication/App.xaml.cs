using CashierApplication.ViewModels;

namespace CashierApplication;

public partial class App : Application
{
	public static UserDetailViewModel userDetail;

	public App()
	{
		InitializeComponent();

		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(@"NjA1NkAzMjM2MkUzMTJFMzliSzVTQlJKN0NLVzNVOFVKSlErcVEzYW9PSkZ2dUhicHliVjkrMncxdHpRPQ==");

		MainPage = new AppShell();
	}
}
