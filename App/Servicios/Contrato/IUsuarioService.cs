using Microsoft.EntityFrameworkCore;
using App_DVP.Models;

namespace App_DVP.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<EntidadPersona> GetPersona
        (
            string nombres,
            string apellidos,
            string numIdentificacion,
            string email,
            string tipoIdentificacion,
            string newPass
        );
        Task<EntidadPersona> SavePersona(EntidadPersona modelo);
        Task<EntidadUsuario> GetUsuario
        (
            string user,
            string pass
        );
        Task<EntidadUsuario> SaveUsuario(EntidadUsuario modelo);
    }
}
