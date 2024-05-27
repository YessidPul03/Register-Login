using System;
using System.Collections.Generic;

namespace App_DVP.Models
{
    public partial class EntidadUsuario
    {
        public int Identificador { get; set; }
        public string? Usuario { get; set; }
        public string? Pass { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
