using Login.Modelos;
using System.Windows.Input;

namespace Login.ViewModels
{
    public class DetallesServicioViewModel
    {
        public Servicio Servicio { get; set; }
        public ICommand RechazarServicioCommand { get; }
        public event Action<Servicio> ServicioRechazado;

        public DetallesServicioViewModel(Servicio servicio)
        {
            Servicio = servicio;
            RechazarServicioCommand = new Command(() =>
            {
                ServicioRechazado?.Invoke(Servicio);
            });
        }
    }
}
