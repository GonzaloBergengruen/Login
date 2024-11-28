namespace Login
{
    public partial class ServiciosEjecutadosPage : ContentPage
    {
        public ServiciosEjecutadosPage()
        {
            InitializeComponent();
            BindingContext = new ServiciosEjecutadosViewModel();
        }

        private async void OnServicioTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var servicio = label.BindingContext as Servicio;

            if (servicio != null)
            {
                var detallesPage = new DetallesServicioPage(servicio, false);
                await Navigation.PushAsync(detallesPage);
            }
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}