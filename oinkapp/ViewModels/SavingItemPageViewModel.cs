using System;
using oinkapp.Data;
using oinkapp.Model;
using Xamarin.Forms;

namespace oinkapp.ViewModels
{
    public class SavingItemPageViewModel : ViewModelBase
    {
        #region Variables

        private SavingDatabase savingDatabase;

        #endregion Variables

        #region Constructor

        public SavingItemPageViewModel(INavigation _navigation, int _Id)
        {
            navigationService = _navigation;
            Initialize(_Id);
        }

        #endregion Constructor

        #region Properties

        private Saving _Saving;

        public Saving Saving
        {
            get
            {
                return _Saving;
            }
            set
            {
                _Saving = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _SaveSavingCommand;

        public ActionCommand SaveSavingCommand
        {
            get
            {
                if (_SaveSavingCommand == null)
                {
                    _SaveSavingCommand = new ActionCommand(SaveSaving);
                }
                return _SaveSavingCommand;
            }
            set
            {
                _SaveSavingCommand = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _CancellCommand;

        public ActionCommand CancellCommand
        {
            get
            {
                if (_CancellCommand == null)
                {
                    _CancellCommand = new ActionCommand(async () => await navigationService.PopModalAsync());
                }
                return _CancellCommand;
            }
            set
            {
                _CancellCommand = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties

        #region Methods

        private async void Initialize(int _Id)
        {
            savingDatabase = new SavingDatabase();

            Saving = await savingDatabase.GetItemAsync(_Id);

            Title = "Mi ahorrro";
        }

        private async void SaveSaving()
        {
            if (string.IsNullOrEmpty(Saving?.Description.Trim()) && Saving.Quantity == 0)
            {
                await navigationService.PopModalAsync();
            }
            else if (string.IsNullOrEmpty(Saving?.Description.Trim()) || Saving.Quantity == 0)
            {
                if (string.IsNullOrEmpty(Saving?.Description.Trim()))
                {
                    var resultAlert = await App.Current.MainPage.DisplayAlert("Ahorro", "Campo de descripción no puede estar vacío", "Continuar", "Cancelar");
                    if (!resultAlert)
                    {
                        await navigationService.PopModalAsync();
                    }
                }
                else if (Saving.Quantity == 0)
                {
                    var resultAlert = await App.Current.MainPage.DisplayAlert("Ahorro", "Campo de cantidad no puede estar en cero", "Continuar", "Cancelar");
                    if (!resultAlert)
                    {
                        await navigationService.PopModalAsync();
                    }
                }
            }
            else
            {
                Saving.DateRegister = DateTime.Now;
                await savingDatabase.SaveItemAsync(Saving);
                await navigationService.PopModalAsync();
                MessagingCenter.Send(this, "GetData");
            }
        }

        #endregion Methods
    }
}
