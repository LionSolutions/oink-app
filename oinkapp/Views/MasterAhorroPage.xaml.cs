using System;
using System.Collections.Generic;
using oinkapp.ControlClass;
using Xamarin.Forms;

namespace oinkapp.Views
{
    public partial class MasterAhorroPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterAhorroPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Ahorros",
                TargetType = typeof(ListaAhorroPage)
            });
            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "Pendientes",
            //    TargetType = typeof(PendientesPage)
            //});

            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "Resuelto",
            //    TargetType = typeof(ResueltoPage)
            //});

            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "En progreso",
            //    TargetType = typeof(ProgresoPage)
            //});

            //masterPageItems.Add(new MasterPageItem
            //{
            //    Title = "Configuracion",
            //    TargetType = typeof(ConfiguracionPage)
            //});

            listView.ItemsSource = masterPageItems;
        }
    }
}
