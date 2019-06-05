using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using oinkapp.Views;
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
        INavigation _navigationService;
        public MisComprasViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _deseoItemDatabase = new DeseoItemDatabase(_fileHelper.GetLocalFilePath("DeseoSQLite.db3"));
            _ahorroItemDatabase = new AhorroItemDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

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
            await _navigationService.PushAsync(new AgregarCompraPage());
        }

        private ActionCommand _AgregarCompraCommand;

        public ActionCommand AgregarCompraCommand
        {
            get
            {
                if (_AgregarCompraCommand == null)
                {
                    _AgregarCompraCommand = new ActionCommand(AgregarCompra);
                }
                return _AgregarCompraCommand;
            }
            set
            {
                _AgregarCompraCommand = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _UpdateCompraCommand;

        public ActionCommand UpdateCompraCommand
        {
            get
            {
                if (_UpdateCompraCommand == null)
                {
                    _UpdateCompraCommand = new ActionCommand(UpdateList);
                }
                return _UpdateCompraCommand;
            }
            set
            {
                _UpdateCompraCommand = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _AgregarCantidadCommand;

        public ActionCommand AgregarCantidadCommand
        {
            get
            {
                if (_AgregarCantidadCommand == null)
                {
                    _AgregarCantidadCommand = new ActionCommand(AgregarCantidad);
                }
                return _AgregarCantidadCommand;
            }
            set { _AgregarCantidadCommand = value; }
        }

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
                _DeseoSelected = value;
                SetearAhorro();
                OnPropertyChanged();
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
            set
            {
                _TotalAhorrado = value;
                OnPropertyChanged();
            }
        }
        private decimal _TotalFalta;
        public decimal TotalFalta
        {
            get => _TotalFalta;
            set
            {
                _TotalFalta = value;
                OnPropertyChanged();
            }
        }

        private IList<AhorroItem> _AhorroSelected;
        public IList<AhorroItem> AhorroSelected
        {
            get => _AhorroSelected;
            set
            {
                _AhorroSelected = value;
                OnPropertyChanged();
            }
        }

        private IList<DeseoItem> _ListaCompras;
        public IList<DeseoItem> ListaCompras
        {
            get => _ListaCompras;
            set
            {
                _ListaCompras = value;
                OnPropertyChanged();
            }
        }

        private decimal _CantidadAAgregar;
        public decimal CantidadAAgregar
        {
            get => _CantidadAAgregar;
            set
            {
                _CantidadAAgregar = value;
                OnPropertyChanged();
            }
        }

        private bool _IsVisible;
        public bool IsVisible
        {
            get => _IsVisible;
            set
            {
                _IsVisible = value;
                OnPropertyChanged();
            }
        }
        async void UpdateList()
        {
            IsBusy = true;
            var lista = await _deseoItemDatabase.GetItemsAsync();
            ListaCompras = lista;
            IsBusy = false;
        }
    }
}