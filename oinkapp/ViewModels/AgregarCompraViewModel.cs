using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using System;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class AgregarCompraViewModel : ViewModelBase
    {
        #region Variables

        TargetDatabase _TargetDatabase;
        SavingDatabase _ahorroItemDatabase;
        public IFileHelper _fileHelper;
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
            //_navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _TargetDatabase = new TargetDatabase(_fileHelper.GetLocalFilePath("DeseoSQLite.db3"));
            _ahorroItemDatabase = new SavingDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

            Title = "Agregar compra";
        }

        async void GuardarDeseo()
        {
            //DeseoCreado.FechaRegistro = DateTime.Now;
            _ = await _TargetDatabase.SaveItemAsync(DeseoCreado);

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