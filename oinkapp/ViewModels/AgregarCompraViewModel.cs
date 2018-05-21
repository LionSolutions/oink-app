using System;
using oinkapp.Model;
using Prism.Commands;
using oinkapp.Data;
using oinkapp.Interfaces;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class AgregarCompraViewModel : ViewModelBase
    {
        DeseoItemDatabase _deseoItemDatabase;
        AhorroItemDatabase _ahorroItemDatabase;
        public IFileHelper _fileHelper;
        public AgregarCompraViewModel()
        {
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
            //if (result > 0)
            //{
            //    AhorroItem ahorro = new AhorroItem();
            //    ahorro.EsCompra = true;
            //    ahorro.NombreCompra = DeseoCreado.Descripcion;
            //    await _ahorroItemDatabase.SaveItemAsync(ahorro);
            //}
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
