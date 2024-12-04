using Login.Modelos;
using Login.ViewModels;

namespace Login
{
    public partial class ServiciosAsignadosPage : ContentPage
    {
        public ServiciosAsignadosPage()
        {
            InitializeComponent();
            BindingContext = new ServiciosAsignadosViewModel();
        }

        //Ve los detalles de un sevicio
        private async void OnServicioTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var servicio = label.BindingContext as Servicio;

            if (servicio != null)
            {
                var detallesPage = new DetallesServicioPage(servicio, true);
                detallesPage.ServicioRechazado += OnServicioRechazado;
                await Navigation.PushAsync(detallesPage);
            }
        }

        //Elimina un servicio de la lista si este fue rechazado
        private void OnServicioRechazado(Servicio servicio)
        {
            var viewModel = BindingContext as ServiciosAsignadosViewModel;
            if (viewModel != null && servicio != null)
            {
                viewModel.Servicios.Remove(servicio);
            }
            Navigation.PopAsync();
        }

        //Vuelve al menu principal
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}