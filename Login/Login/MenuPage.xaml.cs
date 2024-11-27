namespace Login
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void OnVerDatosPersonalesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatosPersonalesPage());
        }

        private async void OnServiciosAsignadosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciosAsignadosPage());
        }

        private async void OnServiciosEjecutadosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciosEjecutadosPage());
        }

        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            //Algo para avisar a la DB que esta cuenta no esta vinculada aca
            await Navigation.PopAsync();
        }
    }
}