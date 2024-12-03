using Login.ViewModels;

namespace Login
{
    public partial class DatosPersonalesPage : ContentPage
    {
        public DatosPersonalesPage()
        {
            InitializeComponent();
            BindingContext = new DatosPersonalesViewModel();
        }

        //Regresa al menu principal
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}