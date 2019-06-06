using oinkapp.Data;
using oinkapp.Helpers;
using oinkapp.Interfaces;
using oinkapp.Model;
using oinkapp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class SavingsPageViewModel : ViewModelBase
    {
        #region Variables

        private SavingDatabase savingDatabase;
        private IFileHelper fileHelper;

        #endregion Variables

        #region Constructor

        public SavingsPageViewModel(INavigation _navigationService)
        {
            navigationService = _navigationService;
            Inicialize();
        }

        #endregion Constructor

        #region Methods

        private void Inicialize()
        {
            fileHelper = DependencyService.Get<IFileHelper>();
            savingDatabase = new SavingDatabase(fileHelper.GetLocalFilePath(KeysHelper.SavingDatabaseName));

            GetData();

            Title = "Mi alcancía";
            MessagingCenter.Subscribe<SavingItemPageViewModel>(this, "GetData", (sender) => GetData());
        }

        private async void GetData()
        {
            var savingsDb = await savingDatabase.GetItemsAsync();
            Savings = new ObservableCollection<Saving>(savingsDb.OrderByDescending(x => x.DateRegister));
            TotalSavings = Savings.Sum(x => x.Quantity);
        }

        async void CheckAndFill()
        {
            var elements = await savingDatabase.GetItemsAsync();
            if (!elements.Any())
            {
                await savingDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 100.00m,
                    DateRegister = DateTime.UtcNow,
                    Description = "Ahorro 1"
                });

                await savingDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 50,
                    DateRegister = new DateTime(2018, 01, 10),
                    Description = "Ahorro 2"
                });

                await savingDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 85,
                    DateRegister = new DateTime(2018, 01, 23),
                    Description = "Ahorro 3"
                });

                await savingDatabase.SaveItemAsync(new Saving
                {
                    Quantity = 115,
                    DateRegister = new DateTime(2018, 02, 07),
                    Description = "Ahorro 4"
                });
            }
        }

        private async void OpenNewAhorro(int _Id)
        {
            await navigationService.PushModalAsync(new SavingItemPage(_Id));
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

        private ActionCommandT<int> _OpenNewAhorroCommand;

        public ActionCommandT<int> OpenNewAhorroCommand
        {
            get
            {
                if (_OpenNewAhorroCommand == null)
                {
                    _OpenNewAhorroCommand = new ActionCommandT<int>(OpenNewAhorro);
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