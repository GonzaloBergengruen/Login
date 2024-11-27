namespace Login
{
    public partial class DatosPersonalesPage : ContentPage
    {
        public DatosPersonalesPage()
        {
            InitializeComponent();
            Nombre.Text = "Nombre: Juan Pérez";
            Id.Text = "RUT: 211111110014";
            Correo.Text = "Correo: juan.perez@example.com";
        }
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}