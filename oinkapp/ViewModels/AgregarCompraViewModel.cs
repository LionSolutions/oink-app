using System;
using oinkapp.Model;
using Prism.Commands;
using oinkapp.Data;
using oinkapp.Interfaces;
using Xamarin.Forms;
using Prism.Navigation;

namespace oinkapp.ViewModels
{
    public class AgregarCompraViewModel : ViewModelBase
    {
        DeseoItemDatabase _deseoItemDatabase;
        AhorroItemDatabase _ahorroItemDatabase;
        public IFileHelper _fileHelper;
        INavigationService _navigationService;
        public AgregarCompraViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _fileHelper = DependencyService.Get<IFileHelper>();

            _deseoItemDatabase = new DeseoItemDatabase(_fileHelper.GetLocalFilePath("DeseoSQLite.db3"));
            _ahorroItemDatabase = new AhorroItemDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

            GuardarDeseoCommand = new DelegateCommand(GuardarDeseo);
            Title = "Agregar compra";
        }

        async void GuardarDeseo()
        {
            DeseoCreado.FechaRegistro = DateTime.Now;
            var result = await _deseoItemDatabase.SaveItemAsync(DeseoCreado);

            _navigationService.NavigateAsync(new Uri("/MasterDetail/NavigationPage/MisCompras", UriKind.Absolute));
        }

        public DelegateCommand GuardarDeseoCommand { get; private set; }

        private DeseoItem _DeseoCreado;
        public DeseoItem DeseoCreado
        {
            get => _DeseoCreado ?? new DeseoItem();
            set => SetProperty(ref _DeseoCreado, value);
        }
    }
}
