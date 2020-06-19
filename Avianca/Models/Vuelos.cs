using System;
using System.Collections.Generic;

namespace Avianca.Models
{
    public partial class Vuelos
    {
        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime? FechayHoraSalida { get; set; }       
        public string Clase { get; set; }
        public int Precio { get; set; }
        public string Status { get; set; }


        // public DateTime? FechaReserva { get; set; }
    }
}
