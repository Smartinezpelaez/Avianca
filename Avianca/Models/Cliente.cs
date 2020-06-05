using System;
using System.Collections.Generic;

namespace Avianca.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipodocumento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}
