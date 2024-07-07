using CashierApplication.Infrastructure;
using CashierApplication.Pages.Authentication;
using CashierApplication.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace CashierApplication
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			MauiAppBuilder builder = MauiApp.CreateBuilder();

			builder.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.UseSkiaSharp()
				.ConfigureSyncfusionCore()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("Blantick-Script.ttf", "BlantickScript");
					fonts.AddFont("Hello-Samosa.ttf", "HelloSamosa");
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
