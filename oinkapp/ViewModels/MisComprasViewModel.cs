using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class MisComprasViewModel : ViewModelBase
    {
        public DeseoItemDatabase _deseoItemDatabase;
        public AhorroItemDatabase _ahorroItemDatabase;

        public IFileHelper _fileHelper;
        INavigationService _navigationService;
        public MisComprasViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _deseoItemDatabase = new DeseoItemDatabase(_fileHelper.GetLocalFilePath("DeseoSQLite.db3"));
            _ahorroItemDatabase = new AhorroItemDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

            AgregarCompraCommand = new DelegateCommand(AgregarCompra);
            UpdateCompraCommand = new DelegateCommand(UpdateList);
            AgregarCantidadCommand = new DelegateCommand(AgregarCantidad);

            //CheckAndFill();
            UpdateList();

            Title = "Mis Compras";
        }

        async void AgregarCantidad()
        {
            AhorroItem ahorro = new AhorroItem();
            ahorro.EsCompra = true;
            ahorro.Cantidad = CantidadAAgregar;
            ahorro.NombreCompra = DeseoSelected.Descripcion;
            ahorro.FechaDeposito = DateTime.Now;
            await _ahorroItemDatabase.SaveItemAsync(ahorro);
            SetearAhorro();
        }

        async void AgregarCompra()
        {
            await _navigationService.NavigateAsync("AgregarCompra");
        }

        public DelegateCommand AgregarCompraCommand { get; private set; }
        public DelegateCommand UpdateCompraCommand { get; private set; }
        public DelegateCommand AgregarCantidadCommand { get; private set; }

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
            get
            {
                return _DeseoSelected;
            }
            set
            {
                SetProperty(ref _DeseoSelected, value);
                SetearAhorro();
            }
        }

        async void SetearAhorro()
        {
            if (_DeseoSelected != null)
            {
                IsVisible = true;
                var lista = await _ahorroItemDatabase.GetItemsAsync(DeseoSelected.Descripcion);
                AhorroSelected = new List<AhorroItem>(lista);
                var tA = lista.Sum(o => o.Cantidad);
                TotalAhorrado = tA;
                TotalFalta = DeseoSelected.Precio - TotalAhorrado;
            }
            else
            {
                IsVisible = false;
            }
        }

        private decimal _TotalAhorrado;
        public decimal TotalAhorrado
        {
            get => _TotalAhorrado;
            set => SetProperty(ref _TotalAhorrado, value);
        }
        private decimal _TotalFalta;
        public decimal TotalFalta
        {
            get => _TotalFalta;
            set => SetProperty(ref _TotalFalta, value);
        }

        private IList<AhorroItem> _AhorroSelected;
        public IList<AhorroItem> AhorroSelected
        {
            get => _AhorroSelected;
            set
            {
                SetProperty(ref _AhorroSelected, value);
            }
        }

        private IList<DeseoItem> _ListaCompras;
        public IList<DeseoItem> ListaCompras
        {
            get => _ListaCompras;
            set
            {
                SetProperty(ref _ListaCompras, value);
            }
        }

        private decimal _CantidadAAgregar;
        public decimal CantidadAAgregar
        {
            get => _CantidadAAgregar;
            set => SetProperty(ref _CantidadAAgregar, value);
        }

        private bool _IsVisible;
        public bool IsVisible
        {
            get => _IsVisible;
            set => SetProperty(ref _IsVisible, value);
        }
        void UpdateList()
        {
            IsBusy = true;
            var lista = _deseoItemDatabase.GetItemsAsync();
            ListaCompras = lista.Result;
            IsBusy = false;
        }
    }
}