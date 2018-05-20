using System;
using System.Collections.Generic;
using oinkapp.ControlClass;
using Prism.Navigation;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class MasterDetailAhorro : MasterDetailPage,IMasterDetailPageOptions
    {
        public MasterDetailAhorro()
        {
            InitializeComponent();
            //masterAhorro.ListView.ItemSelected += ListView_ItemSelected;
        }

        public bool IsPresentedAfterNavigation { get { return false; }}

        //void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem is MasterPageItem item)
        //    {
        //        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        //        masterAhorro.ListView.SelectedItem = null;
        //        IsPresented = false;
        //    }
        //}
    }
}