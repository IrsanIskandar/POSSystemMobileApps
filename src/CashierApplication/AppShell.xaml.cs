﻿using CashierApplication.Infrastructure;
using CashierApplication.Pages;
using CashierApplication.Pages.Authentication;

namespace CashierApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();

		Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
		Routing.RegisterRoute(nameof(LandingPage), typeof(LandingPage));
		Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(AdminDashboard), typeof(AdminDashboard));
		Routing.RegisterRoute(nameof(StaffDashboard), typeof(StaffDashboard));
	}
}