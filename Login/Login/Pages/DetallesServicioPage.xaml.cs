using Login.Modelos;

namespace Login
{
    public partial class DetallesServicioPage : ContentPage
    {
        public event Action<Servicio> ServicioRechazado;
        private Servicio _servicio;

        public DetallesServicioPage(Servicio servicio, bool Type)
        {
            InitializeComponent();
            _servicio = servicio;
            BindingContext = _servicio;
            //Verifica en que pagina esta
            if (Type == true)
            {
                RechazarBoton.IsVisible = true;  //Si esta en ServiciosAsignadosPage.xaml.cs muestra el boton de rechazar servicio
            }
            else
            {
                RechazarBoton.IsVisible = false;  //Si esta en ServiciosEjecutadosPage.xaml.cs oculta el boton de rechazar servicio
            }
        }

        //Rechaza el servicio
        public async void OnRechazarServicioClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirmar", "¿Desea rechazar este servicio?", "Si", "No");
            if (confirm)
            {
                ServicioRechazado?.Invoke(_servicio);
            }
        }

        //Vuelve a la pagina de servicios asignados/ejecutados
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}