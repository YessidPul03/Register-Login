using System;
using System.Collections.Generic;

namespace App_DVP.Models
{
    public partial class EntidadPersona
    {
        public int Identificador { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? Email { get; set; }
        public string? TipoIdentificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string IdentificacíonCompleta { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string NuevaContrasena { get; set; } = null!;
    }
}
