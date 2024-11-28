namespace Login
{

    public partial class ServiciosAsignadosPage : ContentPage
    {
        public ServiciosAsignadosPage()
        {
            InitializeComponent();
            BindingContext = new ServiciosAsignadosViewModel();
        }

        private async void OnServicioTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var servicio = label.BindingContext as Servicio;

            if (servicio != null)
            {
                var detallesPage = new DetallesServicioPage(servicio);
                detallesPage.ServicioRechazado += OnServicioRechazado;
                await Navigation.PushAsync(detallesPage);
            }
        }

        private void OnServicioRechazado(Servicio servicio)
        {
            var viewModel = BindingContext as ServiciosAsignadosViewModel;
            if (viewModel != null && servicio != null)
            {
                viewModel.Servicios.Remove(servicio);
            }
            Navigation.PopAsync();
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}