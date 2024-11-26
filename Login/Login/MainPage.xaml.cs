using System.Text;
using System.Text.RegularExpressions;

namespace Login
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string userType = UserTypePicker.SelectedItem?.ToString();
            string user = UserEntry.Text;
            string password = PasswordEntry.Text;
            Aviso.Text = "";

            if (string.IsNullOrWhiteSpace(userType) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                Aviso.Text = "Todos los campos son obligatorios";
                return;
            }

            // Validar según el tipo de usuario
            if (userType == "Proveedor")
            {
                if (!ValidateRUT(user))
                {
                    Aviso.Text = "Todos los campos son obligatorios";
                    return;
                }
            }
            else if (userType == "Personal")
            {
                if (!ValidateCedula(user))
                {
                    Aviso.Text = "Todos los campos son obligatorios";
                    return;
                }
            }

            // Enviar credenciales al servidor
            //bool loginSuccess = await AuthenticateUser(userType, user, password);

            //if (loginSuccess)
            //{
            //    await DisplayAlert("Éxito", "Inicio de sesión exitoso.", "OK");
            //    // Navegar a la siguiente página
            //}
            //else
            //{
            //    await DisplayAlert("Error", "Credenciales incorrectas.", "OK");
            //}
        }

        // Validación de RUT (Uruguay)
        private bool ValidateRUT(string rut)
        {
            // Remover cualquier separador
            rut = rut.Replace(".", "").Replace("-", "");

            // Verificar que sea solo numérico y que tenga entre 7 y 12 dígitos
            if (!Regex.IsMatch(rut, @"^\d{7,12}$"))
                return false;

            // Calcular el dígito verificador (DV)
            return ValidateRUTChecksum(rut);
        }

        private bool ValidateRUTChecksum(string rut)
        {
            // Separar el número base y el dígito verificador
            string baseNumber = rut.Substring(0, rut.Length - 1);
            int givenDV = int.Parse(rut.Substring(rut.Length - 1));

            int[] weights = { 2, 9, 8, 7, 6, 3, 4 }; // Pesos según el estándar
            int sum = 0;
            int weightIndex = weights.Length - 1;

            // Aplicar el cálculo de módulo 11
            for (int i = baseNumber.Length - 1; i >= 0; i--)
            {
                sum += (baseNumber[i] - '0') * weights[weightIndex];
                weightIndex = (weightIndex - 1 + weights.Length) % weights.Length;
            }

            int remainder = sum % 11;
            int calculatedDV = remainder == 0 ? 0 : 11 - remainder;

            return calculatedDV == givenDV;
        }


        // Validación de Cédula
        private bool ValidateCedula(string cedula)
        {
            // Remover cualquier separador
            cedula = cedula.Replace(".", "").Replace("-", "");

            // Verificar que sea numérica y tenga entre 6 y 8 dígitos
            if (!Regex.IsMatch(cedula, @"^\d{6,8}$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Autenticación contra un cliente externo (ejemplo de API)
        //private async Task<bool> AuthenticateUser(string userType, string user, string password)
        //{
        //    try
        //    {
        //        var client = new HttpClient();
        //        var requestContent = new StringContent(JsonConvert.SerializeObject(new
        //        {
        //            UserType = userType,
        //            Username = user,
        //            Password = password
        //        }), Encoding.UTF8, "application/json");

        //        var response = await client.PostAsync("https://api.tu-servidor.com/auth/login", requestContent);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Procesar respuesta del servidor
        //            var result = await response.Content.ReadAsStringAsync();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Error de conexión: {ex.Message}", "OK");
        //        return false;
        //    }
        //}

    }

}
