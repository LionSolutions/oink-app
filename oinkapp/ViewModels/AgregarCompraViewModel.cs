using oinkapp.Data;
using oinkapp.Model;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class AgregarCompraViewModel : ViewModelBase
    {
        #region Variables

        TargetDatabase targetDatabase;
        SavingDatabase ahorroItemDatabase;
        INavigation _navigationService;

        #endregion Variables

        #region Constructor

        public AgregarCompraViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
            Initialize();
        }

        #endregion Constructor

        #region Methods

        private void Initialize()
        {
            targetDatabase = new TargetDatabase();
            ahorroItemDatabase = new SavingDatabase();

            Title = "Agregar compra";
        }

        async void GuardarDeseo()
        {
            //DeseoCreado.FechaRegistro = DateTime.Now;
            _ = await targetDatabase.SaveItemAsync(DeseoCreado);

            await _navigationService.PopModalAsync();
        }

        #endregion Methods

        #region Properties

        private ActionCommand _GuardarDeseoCommand;

        public ActionCommand GuardarDeseoCommand
        {
            get
            {
                if (_GuardarDeseoCommand == null)
                {
                    _GuardarDeseoCommand = new ActionCommand(GuardarDeseo);
                };

                return _GuardarDeseoCommand;
            }
            set { _GuardarDeseoCommand = value; }
        }

        private Target _DeseoCreado;
        public Target DeseoCreado
        {
            get => _DeseoCreado ?? new Target();
            set
            {
                _DeseoCreado = value;
                OnPropertyChanged();
            }
        }
        #endregion Properties
    }
}