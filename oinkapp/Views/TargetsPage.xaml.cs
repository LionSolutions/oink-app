using System;
using System.Collections.Generic;
using oinkapp.ViewModels;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class TargetsPage : ContentPage
    {
        public TargetsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new TargetsPageViewModel(Navigation);
        }
    }
}
