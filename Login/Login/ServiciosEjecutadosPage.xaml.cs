namespace Login
{
    public partial class ServiciosEjecutadosPage : ContentPage
    {
        public ServiciosEjecutadosPage()
        {
            InitializeComponent();
            Lista.Text = GetLista();
        }

        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private string GetLista()
        {
            var lista = new List<string>();
            string texto = "";
            lista.Add("Nolose");
            lista.Add("Cosa");
            for (int i = 0; i < lista.Count; i++)
            {
                if (string.IsNullOrEmpty(texto))
                {
                    texto += lista[i];
                }
                else
                {
                    texto += "\n\n" + lista[i];
                }
            }
            return texto;
        }
    }
}