namespace Login
{

    public partial class ServiciosAsignadosPage : ContentPage
    {
        public ServiciosAsignadosPage()
        {
            InitializeComponent();
        }
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}