namespace CashierApplication.Pages;

public partial class MainPage : ContentPage
{
	private CancellationTokenSource _cancelTokenSource;
	private bool _isCheckingLocation;

	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);

		//Task.Run(async () => { await GetCurrentLocation(); });
		await GetCurrentLocation();
	}

	public async Task GetCurrentLocation()
	{
		try
		{
			_isCheckingLocation = true;

			Console.WriteLine($"Model: {DeviceInfo.Current.Model}");
			Console.WriteLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
			Console.WriteLine($"Name: {DeviceInfo.Current.Name}");
			Console.WriteLine($"OS Version: {DeviceInfo.Current.VersionString}");
			Console.WriteLine($"Idiom: {DeviceInfo.Current.Idiom}");
			Console.WriteLine($"Platform: {DeviceInfo.Current.Platform}");
			bool isVirtual = DeviceInfo.Current.DeviceType switch
			{
				DeviceType.Physical => false,
				DeviceType.Virtual => true,
				_ => false
			};

			Console.WriteLine($"Virtual device? {isVirtual}");

			var status = PermissionStatus.Unknown;
			status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
			//if (status == PermissionStatus.Granted)
			//	return;

			status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

			GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));

			_cancelTokenSource = new CancellationTokenSource();

			Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

			if (location != null)
				Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

			
		}
		// Catch one of the following exceptions:
		//   FeatureNotSupportedException
		//   FeatureNotEnabledException
		//   PermissionException
		catch (Exception ex)
		{
			// Unable to get location
		}
		finally
		{
			_isCheckingLocation = false;
		}
	}

	public void CancelRequest()
	{
		if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
			_cancelTokenSource.Cancel();
	}
}
