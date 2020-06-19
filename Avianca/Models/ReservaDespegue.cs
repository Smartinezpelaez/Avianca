using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avianca.Models
{
    public class ReservaDespegue
    {
        public int ID { get; set; }
        public int IDReservaDespegue { get; set; }
        public string Pista { get; set; }
        public string Clima { get; set; }
        public string Aeropuerto { get; set; }
        public DateTime? FechayHora { get; set; }
    }
}
