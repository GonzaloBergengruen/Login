using System.Collections.ObjectModel;

namespace Login
{
    public class ServiciosAsignadosViewModel
    {
        public ObservableCollection<Servicio> Servicios { get; set; }

        public ServiciosAsignadosViewModel()
        {
            Servicios = new ObservableCollection<Servicio>
            {
                new Servicio { Nombre = "Internet 100 Mbps", Detalle = "Servicio de internet con alta velocidad." },
                new Servicio { Nombre = "Televisión HD", Detalle = "Servicio de TV con canales en alta definición." }
            };
        }
    }
}
