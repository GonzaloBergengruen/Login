using System.Collections.ObjectModel;

namespace Login.ViewModels
{
    public class ServiciosEjecutadosViewModel
    {
        public ObservableCollection<Servicio> Servicios { get; set; }

        public ServiciosEjecutadosViewModel()
        {
            Servicios = new ObservableCollection<Servicio>
            {
                new Servicio { Nombre = "Hola", Detalle = "Texto de ejemplo" },
                new Servicio { Nombre = "Algo", Detalle = "Nose" }
            };
        }
    }
}