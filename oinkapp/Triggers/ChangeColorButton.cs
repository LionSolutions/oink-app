using Xamarin.Forms;

namespace oinkapp.Triggers
{
    public  class ChangeColorButton : TriggerAction<Button>
    {
        protected override void Invoke(Button btn)
        {
            btn.BackgroundColor = Color.DarkOrange;
            btn.Text = "Here we go!!!";
        }
    }
}