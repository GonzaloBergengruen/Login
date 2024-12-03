namespace Login
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        //Va a la pagina de datos personales
        private async void OnVerDatosPersonalesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatosPersonalesPage());
        }

        //Va a la pagina de servicios asignados
        private async void OnServiciosAsignadosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciosAsignadosPage());
        }

        //Va a la pagina de servicios ejecutados
        private async void OnServiciosEjecutadosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciosEjecutadosPage());
        }

        //Cierra la sesion y vuelve a la pagina principal
        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            //Algo para avisar a la DB que esta cuenta no esta vinculada aca
            await Navigation.PopAsync();
        }
    }
}