namespace Login
{

	public partial class DetallesServicioPage : ContentPage
	{
		public DetallesServicioPage(Servicio servicio)
		{
			InitializeComponent();
			BindingContext = servicio;
		}

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}