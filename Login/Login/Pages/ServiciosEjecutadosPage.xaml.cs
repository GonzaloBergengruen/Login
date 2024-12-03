using Login.ViewModels;

namespace Login
{
    public partial class ServiciosEjecutadosPage : ContentPage
    {
        public ServiciosEjecutadosPage()
        {
            InitializeComponent();
            BindingContext = new ServiciosEjecutadosViewModel();
        }

        //Va a la pagina de detalles de un servicio
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

        //Regresa al menu principal
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}