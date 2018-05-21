using System;
using oinkapp.Data;
using oinkapp.Interfaces;
using Xamarin.Forms;
using oinkapp.Model;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;

namespace oinkapp.ViewModels
{
    public class MisComprasViewModel : ViewModelBase
    {

        public DeseoItemDatabase _deseoItemDatabase;
        public IFileHelper _fileHelper;
        INavigationService _navigationService;
        public MisComprasViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();
            _deseoItemDatabase = new DeseoItemDatabase(_fileHelper.GetLocalFilePath("DeseoSQLite.db3"));

            AgregarCompraCommand = new DelegateCommand(AgregarCompra);

            CheckAndFill();
            UpdateList();

            Title = "Mis Compras";
        }

        async void AgregarCompra()
        {
            await _navigationService.NavigateAsync("AgregarCompra");
        }

        public DelegateCommand AgregarCompraCommand { get; private set; }

        async void CheckAndFill()
        {
            var elements = await _deseoItemDatabase.GetItemsAsync();
            if (!elements.Any())
            {
                DeseoItem deseo = new DeseoItem();
                deseo.Descripcion = "XBOX";
                deseo.FechaRegistro = DateTime.Now;
                deseo.FechaMeta = DateTime.Now;
                deseo.Precio = 4500;
                await _deseoItemDatabase.SaveItemAsync(deseo);

                DeseoItem deseo1 = new DeseoItem();
                deseo1.Descripcion = "MINI DRON";
                deseo1.FechaRegistro = DateTime.Now;
                deseo1.FechaMeta = DateTime.Now;
                deseo1.Precio = 725;
                await _deseoItemDatabase.SaveItemAsync(deseo1);
            }
        }

        private DeseoItem _DeseoSelected;
        public DeseoItem DeseoSelected
        {
            get => _DeseoSelected;
            set
            {
                SetProperty(ref _DeseoSelected, value);
            }
        }

        private IList<DeseoItem> _ListaCompras;
        public IList<DeseoItem> ListaCompras
        {
            get => _ListaCompras;
            set => SetProperty(ref _ListaCompras, value);
        }

        async void UpdateList()
        {
            var lista = await _deseoItemDatabase.GetItemsAsync();
            ListaCompras = lista;
        }
    }
}