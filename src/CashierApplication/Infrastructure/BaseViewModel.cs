using CommunityToolkit.Mvvm.ComponentModel;

namespace CashierApplication.Infrastructure;

public partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	private bool _IsBusy;

	[ObservableProperty]
	private string _Title;
}
