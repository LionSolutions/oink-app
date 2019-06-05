using oinkapp.Data;
using oinkapp.Interfaces;
using oinkapp.Model;
using oinkapp.Views;
using System;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class AgregarCompraViewModel : ViewModelBase
    {
        #region Variables

        DeseoItemDatabase _deseoItemDatabase;
        AhorroItemDatabase _ahorroItemDatabase;
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

        private void Initialize()
        {
            //_navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _deseoItemDatabase = new DeseoItemDatabase(_fileHelper.GetLocalFilePath("DeseoSQLite.db3"));
            _ahorroItemDatabase = new AhorroItemDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

            Title = "Agregar compra";
        }

        async void GuardarDeseo()
        {
            DeseoCreado.FechaRegistro = DateTime.Now;
            _ = await _deseoItemDatabase.SaveItemAsync(DeseoCreado);

            await _navigationService.PopModalAsync();        }

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

        private DeseoItem _DeseoCreado;
        public DeseoItem DeseoCreado
        {
            get => _DeseoCreado ?? new DeseoItem();
            set
            {
                _DeseoCreado = value;
                OnPropertyChanged();
            }
        }
        #endregion Properties
    }
}