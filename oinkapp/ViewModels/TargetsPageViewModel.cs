using System.Collections.Generic;
using oinkapp.Data;
using oinkapp.Model;
using oinkapp.Views;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class TargetsPageViewModel : ViewModelBase
    {
        #region Variables

        public TargetDatabase targetDatabase;
        public SavingDatabase savingDatabase;

        #endregion Variables

        #region Constructor

        public TargetsPageViewModel(INavigation _navigationService)
        {
            navigationService = _navigationService;
            Inicialize();
        }

        #endregion Constructor

        #region Methods

        private void Inicialize()
        {
            targetDatabase = new TargetDatabase();
            savingDatabase = new SavingDatabase();

            Title = "Mis Compras";
        }

        #endregion Methods

        #region Properties

        private ActionCommand _AgregarCompraCommand;

        public ActionCommand AgregarCompraCommand
        {
            get
            {
                if (_AgregarCompraCommand == null)
                {
                    _AgregarCompraCommand = new ActionCommand(
                        async () => await navigationService.PushModalAsync(new AgregarCompraPage())
                        );
                }
                return _AgregarCompraCommand;
            }
            set
            {
                _AgregarCompraCommand = value;
                OnPropertyChanged();
            }
        }

        private decimal _TargetTotal;
        public decimal TargetTotal
        {
            get => _TargetTotal;
            set
            {
                _TargetTotal = value;
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

        private IList<Saving> _AhorroSelected;
        public IList<Saving> AhorroSelected
        {
            get => _AhorroSelected;
            set
            {
                _AhorroSelected = value;
                OnPropertyChanged();
            }
        }

        private IList<Target> _ListaCompras;
        public IList<Target> ListaCompras
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

        #endregion Properties
    }
}