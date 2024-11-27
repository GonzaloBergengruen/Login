namespace Login
{

    public partial class ServiciosAsignadosPage : ContentPage
    {
        public ServiciosAsignadosPage()
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
            string text = "";
            lista.Add("Servicio 1: Internet 100 Mbps");
            lista.Add("Servicio 2: Televisión HD");
            for (int i = 0; i < lista.Count; i++)
            {
                if (string.IsNullOrEmpty(text))
                {
                    text += lista[i];
                }
                else
                {
                    text += "\n\n" + lista[i];
                }
            }
            return text;
        }
    }
}