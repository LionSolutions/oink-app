using System;
using oinkapp.Data;
using oinkapp.Interfaces;
using System.Linq;
using oinkapp.Model;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using Prism.Commands;

namespace oinkapp.ViewModels
{
    public class ListaAhorroPageViewModel : ViewModelBase
    {
        public AhorroItemDatabase _ahorroDatabase;
        public IFileHelper _fileHelper;
        public ListaAhorroPageViewModel()
        {
            _fileHelper = DependencyService.Get<IFileHelper>();
            var t = _fileHelper.GetLocalFilePath("TodoSQLite.db3");
            _ahorroDatabase = new AhorroItemDatabase(_fileHelper.GetLocalFilePath("AhorroSQLite.db3"));

            UpdateLista();
            Title = "Mi alcancía";

            AgregarNuevoCommand = new DelegateCommand(AgregarNuevo);
        }

        void AgregarNuevo()
        {
            var cantidad = new AhorroItem()
            {
                Cantidad = CantidadAgregar,
                FechaDeposito = DateTime.Now
            };
            _ahorroDatabase.SaveItemAsync(cantidad);

            UpdateLista();
            CantidadAgregar = 0;
        }

        async void UpdateLista()
        {
            var lista = await _ahorroDatabase.GetItemsAsync();
            ListaAhorros = lista.OrderByDescending(ele => ele.FechaDeposito).ToList();
            AhorroTotal = ListaAhorros.Sum(ah => ah.Cantidad);
        }

        private IList<AhorroItem> _ListaAhorros;
        public IList<AhorroItem> ListaAhorros
        {
            get => _ListaAhorros;
            set => SetProperty(ref _ListaAhorros, value);
        }

        private decimal _AhorroTotal;
        public decimal AhorroTotal
        {
            get => _AhorroTotal;
            set => SetProperty(ref _AhorroTotal, value);
        }
        private decimal _CantidadAgregar;
        public decimal CantidadAgregar
        {
            get => _CantidadAgregar;
            set => SetProperty(ref _CantidadAgregar, value);
        }

        public DelegateCommand AgregarNuevoCommand { get; private set; }

        async void CheckAndFill()
        {
            var elements = await _ahorroDatabase.GetItemsAsync();
            if (!elements.Any())
            {
                AhorroItem ahorro = new AhorroItem();
                ahorro.Cantidad = 100;
                ahorro.FechaDeposito = new DateTime(2018, 01, 02);
                await _ahorroDatabase.SaveItemAsync(ahorro);

                AhorroItem ahorro1 = new AhorroItem();
                ahorro1.Cantidad = 50;
                ahorro1.FechaDeposito = new DateTime(2018, 01, 10);
                await _ahorroDatabase.SaveItemAsync(ahorro1);

                AhorroItem ahorro2 = new AhorroItem();
                ahorro2.Cantidad = 85;
                ahorro2.FechaDeposito = new DateTime(2018, 01, 23);
                await _ahorroDatabase.SaveItemAsync(ahorro2);

                AhorroItem ahorro3 = new AhorroItem();
                ahorro3.Cantidad = 115;
                ahorro3.FechaDeposito = new DateTime(2018, 02, 07);
                await _ahorroDatabase.SaveItemAsync(ahorro3);
            }
        }

    }
}
