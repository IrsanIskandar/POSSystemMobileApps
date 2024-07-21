using CashierApplication.Infrastructure;
using CashierApplication.Pages.Authentication;
using CashierApplication.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;
using The49.Maui.BottomSheet;

namespace CashierApplication
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			MauiAppBuilder builder = MauiApp.CreateBuilder();

			builder.UseMauiApp<App>()
				.UseSkiaSharp()
				.UseBottomSheet()
				.ConfigureSyncfusionCore()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("Blantick-Script.ttf", "BlantickScript");
					fonts.AddFont("Hello-Samosa.ttf", "HelloSamosa");
					fonts.AddFont("fa-solid-900.ttf", "Fa");
					fonts.AddFont("fa-brands-400.ttf", "Fab");
					fonts.AddFont("fa-duotone-900.ttf", "Fad");
					fonts.AddFont("fa-regular-400.ttf", "Far");
					fonts.AddFont("fa-sharp-regular-400.ttf", "Fas");
					fonts.AddFont("fa-thin-100.ttf", "Fat");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			// Pages
			builder.Services.AddSingleton<LoadingPage>();
			builder.Services.AddSingleton<SignInPage>();

			// Service And Model
			builder.Services.AddSingleton<AuthenticationService>();
			builder.Services.AddSingleton<AuthenticationViewModel>();
			builder.Services.AddSingleton<AppShellViewModel>();

			return builder.Build();
		}
	}
}
