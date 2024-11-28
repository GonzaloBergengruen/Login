using System.Windows.Input;
using System.ComponentModel;


namespace Login
{
    public class DatosPersonalesViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _id;
        private string _correo;
        private string _telefono;

        public string Nombre
        {
            get => _nombre;
            set { _nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }

        public string Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(Id));}
        }

        public string Correo
        {
            get => _correo;
            set { _correo = value; OnPropertyChanged(nameof(Correo)); }
        }

        public string Telefono
        {
            get => _telefono;
            set { _telefono = value; OnPropertyChanged(nameof(Telefono)); }
        }

        // Datos originales para comparar
        private string _nombreOriginal;
        private string _idOriginal;
        private string _correoOriginal;
        private string _telefonoOriginal;

        public ICommand GuardarCommand { get; }

        public DatosPersonalesViewModel()
        {
            // Inicializar datos originales y actuales
            _nombreOriginal = Nombre = "Juan Pérez";
            _idOriginal = Id = "5.396.971-0";
            _correoOriginal = Correo = "juan.perez@example.com";
            _telefonoOriginal = Telefono = "099123456";

            GuardarCommand = new Command(ConfirmarCambios);
        }

        private async void ConfirmarCambios()
        {
            if (_nombreOriginal == Nombre && _idOriginal == Id && _correoOriginal == Correo && _telefonoOriginal == Telefono)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "No hay cambios", "Ok");
            }
            else
            {
                // Crear el mensaje de comparación
                string mensaje = $"**Datos Originales:**\n" +
                                 $"- Nombre: {_nombreOriginal}\n" +
                                 $"- RUT/CI: {_idOriginal}\n" +
                                 $"- Correo: {_correoOriginal}\n" +
                                 $"- Teléfono: {_telefonoOriginal}\n\n" +
                                 $"**Datos Modificados:**\n" +
                                 $"- Nombre: {Nombre}\n" +
                                 $"- RUT/CI: {Id}\n" +
                                 $"- Correo: {Correo}\n" +
                                 $"- Teléfono: {Telefono}";

                // Confirmar si se desean guardar los cambios
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
            // Simular el guardado de datos
            await Application.Current.MainPage.DisplayAlert("Éxito", "Los datos personales han sido actualizados.", "OK");

            // Actualizar los datos originales con los nuevos
            _nombreOriginal = Nombre;
            _idOriginal = Id;
            _correoOriginal = Correo;
            _telefonoOriginal = Telefono;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
