namespace Login
{
    public partial class ServiciosEjecutadosPage : ContentPage
    {
        public ServiciosEjecutadosPage()
        {
            InitializeComponent();
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}