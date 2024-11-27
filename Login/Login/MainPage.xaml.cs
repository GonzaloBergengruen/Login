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
                    Aviso.Text = "RUT invalido";
                    return;
                }
            }
            else if (userType == "Personal")
            {
                if (!ValidateCedula(user))
                {
                    Aviso.Text = "Cedula invalida";
                    return;
                }
            }

            bool loginSuccess = true;
            if (loginSuccess)
            {
                await Navigation.PushAsync(new MenuPage());
            }

            // Enviar credenciales al servidor
            //bool loginSuccess = await AuthenticateUser(userType, user, password);

            //if (loginSuccess)
            //{
            //    await DisplayAlert("Éxito", "Inicio de sesión exitoso.", "OK");
            //    //Navegar a la siguiente página
            //}
            //else
            //{
            //    await DisplayAlert("Error", "Credenciales incorrectas.", "OK");
            //}
        }

        // Validación de RUT (Uruguay)
        private bool ValidateRUT(string rut)
        {
            // Eliminar puntos y guiones si están presentes
            rut = rut.Replace(".", "").Replace("-", "");

            // Verificar que sea numérico y tenga entre 7 y 12 dígitos
            if (!Regex.IsMatch(rut, @"^\d{7,12}$"))
                return false;

            // Calcular el dígito verificador (DV)
            return ValidateRUTChecksum(rut);
        }

        private bool ValidateRUTChecksum(string rut)
        {
            // Separar el número base y el dígito verificador
            string baseNumber = rut.Substring(0, rut.Length - 1); // El número sin el DV
            int givenDV = int.Parse(rut.Substring(rut.Length - 1)); // El dígito verificador

            int[] weights = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4 }; // Pesos según el estándar de Uruguay
            int sum = 0;
            int weightIndex = 0;

            // Aplicar el cálculo de módulo 11
            for (int i = baseNumber.Length - 1; i >= 0; i--)
            {
                sum += (baseNumber[i] - '0') * weights[weightIndex];
                weightIndex = (weightIndex + 1) % weights.Length;
            }

            int remainder = sum % 11;
            int calculatedDV;

            if (remainder == 0)
                calculatedDV = 0;
            else if (remainder == 1)
                calculatedDV = 1;
            else
                calculatedDV = 11 - remainder;

            // Comparar el DV calculado con el DV dado
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
