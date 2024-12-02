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
			if(Type == true)
			{
				RechazarBoton.IsVisible = true;
			} else
			{
				RechazarBoton.IsVisible = false;
			}
		}

		public async void OnRechazarServicioClicked(object sender, EventArgs e)
		{
			bool confirm = await DisplayAlert("Confirmar", "¿Desea rechazar este servicio?", "Si", "No");
			if (confirm)
			{
				ServicioRechazado?.Invoke(_servicio);
			}
		}

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}