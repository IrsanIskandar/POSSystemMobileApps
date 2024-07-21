using Android.App;
using Android.Runtime;

namespace CashierApplication
{
	[Application]
	[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
	[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
	[assembly: UsesPermission(Manifest.Permission.AccessBackgroundLocation)]
	[assembly: UsesFeature("android.hardware.location", Required = true)]
	[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
	[assembly: UsesFeature("android.hardware.location.network", Required = false)]
	public class MainApplication : MauiApplication
	{
		public MainApplication(IntPtr handle, JniHandleOwnership ownership)
			: base(handle, ownership)
		{
		}

		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	}
}
