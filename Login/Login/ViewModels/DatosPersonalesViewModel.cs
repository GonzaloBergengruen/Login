using System.Windows.Input;
using System.ComponentModel;
using Login.Modelos;

namespace Login.ViewModels
{
    public class DatosPersonalesViewModel : INotifyPropertyChanged
    {
        private Persona persona = new Persona();

        public string Nombre
        {
            get => persona.nombre;
            set { persona.nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }

        public string Id
        {
            get => persona.id;
            set { persona.id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Correo
        {
            get => persona.correo;
            set { persona.correo = value; OnPropertyChanged(nameof(Correo)); }
        }

        public string Telefono
        {
            get => persona.telefono;
            set { persona.telefono = value; OnPropertyChanged(nameof(Telefono)); }
        }

        //Datos originales para comparar
        private Persona personaOriginal = new Persona();

        public ICommand GuardarCommand { get; }

        public DatosPersonalesViewModel()
        {
            //Inicializar datos originales y actuales
            personaOriginal.nombre = Nombre = "Juan Pérez";
            personaOriginal.id = Id = "5.396.971-0";
            personaOriginal.correo = Correo = "juan.perez@example.com";
            personaOriginal.telefono = Telefono = "099123456";

            GuardarCommand = new Command(ConfirmarCambios);
        }

        private async void ConfirmarCambios()
        {
            //Detecta si hay cambios
            if (personaOriginal.nombre == Nombre && personaOriginal.id == Id && personaOriginal.correo == Correo && personaOriginal.telefono == Telefono)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "No hay cambios", "Ok");
            }
            else
            {
                //Crear el mensaje de comparación
                string mensaje = $"**Datos Originales:**\n" +
                                 $"- Nombre: {personaOriginal.nombre}\n" +
                                 $"- RUT/CI: {personaOriginal.id}\n" +
                                 $"- Correo: {personaOriginal.correo}\n" +
                                 $"- Teléfono: {personaOriginal.telefono}\n\n" +
                                 $"**Datos Modificados:**\n" +
                                 $"- Nombre: {Nombre}\n" +
                                 $"- RUT/CI: {Id}\n" +
                                 $"- Correo: {Correo}\n" +
                                 $"- Teléfono: {Telefono}";

                //Confirmar si se desean guardar los cambios
                bool confirmar = await Application.Current.MainPage.DisplayAlert(
                    "Confirmar Cambios",
                    mensaje,
                    "Guardar",
                    "Cancelar");

                if (confirmar)
                {
                    GuardarCambios();
                }
            }
        }

        private async void GuardarCambios()
        {
            //Simular el guardado de datos
            await Application.Current.MainPage.DisplayAlert("Éxito", "Los datos personales han sido actualizados.", "OK");

            //Actualizar los datos originales con los nuevos
            personaOriginal.nombre = Nombre;
            personaOriginal.id = Id;
            personaOriginal.correo = Correo;
            personaOriginal.telefono = Telefono;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
