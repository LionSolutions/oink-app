using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class ListaAhorroPageViewModel : ViewModelBase
    {
        #region Variables

        public AhorroItemDatabase _ahorroDatabase;
        public IFileHelper _fileHelper;
        INavigation navigationService;

        #endregion Variables

        #region Constructor

        public ListaAhorroPageViewModel(INavigation _navigationService)
        {
            navigationService = _navigationService;
            Inicialize();
        }

        #endregion Constructor

        #region Methods

        private void Inicialize()
        {
            _fileHelper = DependencyService.Get<IFileHelper>();
            _ahorroDatabase = new AhorroItemDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

            UpdateLista();
            Title = "Mi alcancía";

            CheckAndFill();
        }

        async void AgregarNuevo()
        {
            var cantidad = new AhorroItem()
            {
                Cantidad = CantidadAgregar,
                FechaDeposito = DateTime.Now
            };
            await _ahorroDatabase.SaveItemAsync(cantidad);

            UpdateLista();
            CantidadAgregar = 0;
        }

        async void UpdateLista()
        {
            var lista = await _ahorroDatabase.GetItemsAsync();
            ListaAhorros = lista.OrderByDescending(ele => ele.FechaDeposito).ToList();
            AhorroTotal = ListaAhorros.Sum(ah => ah.Cantidad);
        }

        async void CheckAndFill()
        {
            var elements = await _ahorroDatabase.GetItemsAsync();
            if (!elements.Any())
            {
                await _ahorroDatabase.SaveItemAsync(new AhorroItem
                {
                    Cantidad = 100,
                    FechaDeposito = new DateTime(2018, 01, 02),
                    NombreCompra = "Ahorro 1"
                });

                await _ahorroDatabase.SaveItemAsync(new AhorroItem
                {
                    Cantidad = 50,
                    FechaDeposito = new DateTime(2018, 01, 10),
                    NombreCompra = "Ahorro 2"
                });

                await _ahorroDatabase.SaveItemAsync(new AhorroItem
                {
                    Cantidad = 85,
                    FechaDeposito = new DateTime(2018, 01, 23),
                    NombreCompra = "Ahorro 3"
                });

                await _ahorroDatabase.SaveItemAsync(new AhorroItem
                {
                    Cantidad = 115,
                    FechaDeposito = new DateTime(2018, 02, 07),
                    NombreCompra = "Ahorro 4"
                });
            }
        }

        private void OpenNewAhorro()
        {
            //todo: Create a new page for add new value
            //navigationService.PopAsync()
        }

        #endregion Methods

        #region Properties

        private IList<AhorroItem> _ListaAhorros;
        public IList<AhorroItem> ListaAhorros
        {
            get => _ListaAhorros;
            set
            {
                _ListaAhorros = value;
                OnPropertyChanged();
            }
        }

        private decimal _AhorroTotal;
        public decimal AhorroTotal
        {
            get => _AhorroTotal;
            set
            {
                _AhorroTotal = value;
                OnPropertyChanged();
            }
        }
        private decimal _CantidadAgregar;
        public decimal CantidadAgregar
        {
            get => _CantidadAgregar;
            set
            {
                _CantidadAgregar = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _AgregarNuevoCommand;

        public ActionCommand AgregarNuevoCommand
        {
            get
            {
                if (_AgregarNuevoCommand == null)
                {
                    _AgregarNuevoCommand = new ActionCommand(AgregarNuevo);
                }
                return _AgregarNuevoCommand;
            }
            set { _AgregarNuevoCommand = value; }
        }

        private ActionCommand _OpenNewAhorroCommand;

        public ActionCommand OpenNewAhorroCommand
        {
            get
            {
                if (_OpenNewAhorroCommand == null)
                {
                    _OpenNewAhorroCommand = new ActionCommand(OpenNewAhorro);
                }
                return _OpenNewAhorroCommand;
            }
            set
            {
                _OpenNewAhorroCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}