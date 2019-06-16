using oinkapp.Data;
using oinkapp.Helpers;
using oinkapp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace oinkapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InicializeData();
            MainPage = new BurgerMenuPage();
        }

        private async void InicializeData()
        {
            try
            {
                SavingDatabase savingDatabase = new SavingDatabase();
                TargetDatabase targetDatabase = new TargetDatabase();

                await savingDatabase.RestoreDatabase();
                await targetDatabase.RestoreDatabase();

                var savings = DummyDataHelper.GetDummySaving();
                var targets = DummyDataHelper.GetDummyTarget();

                await savingDatabase.AddSavings(savings);
                await targetDatabase.AddTargets(targets);
            }
            catch (System.Exception ex)
            {
                var message = ex.Message;
            }
        }
    }
}