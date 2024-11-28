namespace Login
{
    public partial class DatosPersonalesPage : ContentPage
    {
        public DatosPersonalesPage()
        {
            InitializeComponent();
            BindingContext = new DatosPersonalesViewModel();
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}