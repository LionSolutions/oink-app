using oinkapp.Data;
using oinkapp.Helpers;
using oinkapp.Interfaces;
using oinkapp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class SavingsPageViewModel : ViewModelBase
    {
        #region Variables

        private SavingDataBase _ahorroDatabase;
        private IFileHelper _fileHelper;

        #endregion Variables

        #region Constructor

        public SavingsPageViewModel(INavigation _navigationService)
        {
            navigationService = _navigationService;
            Inicialize();
        }

        #endregion Constructor

        #region Methods

        private async void Inicialize()
        {
            _fileHelper = DependencyService.Get<IFileHelper>();
            _ahorroDatabase = new SavingDataBase(_fileHelper.GetLocalFilePath(KeysHelper.SavingDatabaseName));

            Savings = new ObservableCollection<Saving>(await _ahorroDatabase.GetItemsAsync());
            TotalSavings = Savings.Sum(x => x.Quantity);

            Title = "Mi alcancía";
        }

        async void CheckAndFill()
        {
            var elements = await _ahorroDatabase.GetItemsAsync();
            if (!elements.Any())
            {
                await _ahorroDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 100.00m,
                    DateRegister = DateTime.UtcNow,
                    Description = "Ahorro 1"
                });

                await _ahorroDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 50,
                    DateRegister = new DateTime(2018, 01, 10),
                    Description = "Ahorro 2"
                });

                await _ahorroDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 85,
                    DateRegister = new DateTime(2018, 01, 23),
                    Description = "Ahorro 3"
                });

                await _ahorroDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 115,
                    DateRegister = new DateTime(2018, 02, 07),
                    Description = "Ahorro 4"
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

        private ObservableCollection<Saving> _Savings;
        public ObservableCollection<Saving> Savings
        {
            get => _Savings;
            set
            {
                _Savings = value;
                OnPropertyChanged();
            }
        }

        private decimal _TotalSavings;
        public decimal TotalSavings
        {
            get => _TotalSavings;
            set
            {
                _TotalSavings = value;
                OnPropertyChanged();
            }
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