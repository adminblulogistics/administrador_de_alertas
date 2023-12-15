using LD.DataLD;
using LD.Entities;
using LD.Entities.Dtos;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public partial class RepositoryUserLD : IRepositoryUserLD
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryUserLD (ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorID(int? id)
        {
            ADDITIONAL_USER_INFORMATION usuario = _dbContext.ADDITIONAL_USER_INFORMATION.Include(i=>i.ID_COMPANYNavigation).Where(w=>w.ID_USER_BLU == id).FirstOrDefault();
            return usuario;
        }
        public ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorAlisasSF(string aliasSaleF)
        {
            ADDITIONAL_USER_INFORMATION usuario = _dbContext.ADDITIONAL_USER_INFORMATION.Include(i => i.ID_COMPANYNavigation).Where(w => w.ID_USER_SF == aliasSaleF).FirstOrDefault();
            return usuario;
        }
        public List<ADDITIONAL_USER_INFORMATION> obtenerUsuariosLD()
        {
            List<ADDITIONAL_USER_INFORMATION> usuarios = _dbContext.ADDITIONAL_USER_INFORMATION.Include(i => i.ID_COMPANYNavigation).ToList();
            return usuarios;
        }
        public Respuesta insertarUsuario(ADDITIONAL_USER_INFORMATION usuario)
        {
            Respuesta respuesta = new Respuesta();

            _dbContext.ADDITIONAL_USER_INFORMATION.Add(usuario);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;

            return respuesta;
        }
        public Respuesta actualizarUsuario(ADDITIONAL_USER_INFORMATION usuario) 
        {
            Respuesta respuesta = new Respuesta();

            ADDITIONAL_USER_INFORMATION usuarioActualizar = _dbContext.ADDITIONAL_USER_INFORMATION.Where(x => x.ID_USER_BLU == usuario.ID_USER).FirstOrDefault();
            usuarioActualizar.CHANGE_COUNTRY = usuario.CHANGE_COUNTRY;
            usuarioActualizar.POSITION = usuario.POSITION;
            usuarioActualizar.BRANCH = usuario.BRANCH;
            usuarioActualizar.ID_USER_SF = usuario.ID_USER_SF;
            usuarioActualizar.ID_USER_CW = usuario.ID_USER_CW;
            usuarioActualizar.ID_COMPANY = usuario.ID_COMPANY;

            _dbContext.SaveChanges();
            respuesta.ProcesoExitoso = true;

            return respuesta;
        }
        public Respuesta actualizarRolDefecto(USERDto usuario)
        {
            Respuesta respuesta = new Respuesta();

            ADDITIONAL_USER_INFORMATION usuarioActualizar = _dbContext.ADDITIONAL_USER_INFORMATION.Where(x => x.ID_USER == usuario.ID_USER).FirstOrDefault();

            usuarioActualizar.DEFAULT_ROL = usuario.DEFAULT_ROL;
            _dbContext.SaveChanges();
            respuesta.ProcesoExitoso = true;

            return respuesta;
        }
    }
}
