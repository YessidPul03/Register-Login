using Microsoft.EntityFrameworkCore;
using App_DVP.Models;
using App_DVP.Servicios.Contrato;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualBasic;

namespace App_DVP.Servicios.Implementación
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DVPContext _dbContext;

        public UsuarioService(DVPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EntidadPersona> GetPersona(
            string nombres,
            string apellidos,
            string numIdentificacion,
            string email,
            string tipoIdentificacion,
            string newPass)
        {
            EntidadPersona usuarioFound = await _dbContext.EntidadPersonas.Where(u => u.Email == email && u.NumeroIdentificacion == numIdentificacion)
                .FirstOrDefaultAsync();

            return usuarioFound;

            //throw new NotImplementedException();
        }

        public async Task<EntidadPersona> SavePersona(EntidadPersona modelo)
        {
            _dbContext.EntidadPersonas.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;

            //throw new NotImplementedException();
        }

        public async Task<EntidadUsuario> GetUsuario(string user, string pass)
        {
            EntidadUsuario usuarioFound = await _dbContext.EntidadUsuarios.Where(u => u.Usuario == user && u.Pass == pass)
                .FirstOrDefaultAsync();

            return usuarioFound;
        
            //throw new NotImplementedException();
        }

        public async Task<EntidadUsuario> SaveUsuario(EntidadUsuario modelo)
        {
            var personaRegistrada = _dbContext.EntidadPersonas.ToList();
            var usuarioRegistrado = personaRegistrada.Select(item => new EntidadUsuario
            {
                Usuario = item.Email,
                Pass = item.NuevaContrasena
            }).ToList();

            _dbContext.EntidadUsuarios.AddRange(usuarioRegistrado);
            await _dbContext.SaveChangesAsync();
            return modelo;
        
            //throw new NotImplementedException();
        }
    }
}
