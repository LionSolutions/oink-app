using System;
using System.Collections.Generic;
using oinkapp.ControlClass;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class MasterDetailAhorro : MasterDetailPage
    {
        public MasterDetailAhorro()
        {
            InitializeComponent();
            masterAhorro.ListView.ItemSelected += ListView_ItemSelected;
        }

        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterPageItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterAhorro.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}