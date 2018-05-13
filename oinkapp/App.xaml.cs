using System;
using Prism;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using oinkapp.ViewModels;
using oinkapp.Views;
using Prism.Ioc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace oinkapp
{
	public partial class App : PrismApplication
	{
		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync("http://www.erecap_forms/NavigationPage/Acceso");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<AccesoView, AccesoViewModel>("Acceso");
		}
	}
}
