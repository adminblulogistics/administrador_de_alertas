using LD.DataCotizador;
using LD.EntitiesCotizador;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public class RepositoryUserCOT : IRepositoryUserCOT
    {
        private readonly BPCotizadorContext _dbContext;
        public RepositoryUserCOT(BPCotizadorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public USERS_APPS obtenerUsuarioCOTPorID(int idUser)
        {
            USERS_APPS user = _dbContext.USERS_APPS.Where(x => x.ID_USER == idUser).FirstOrDefault();
            return user;
        }
        public USERS_APPS obtenerUsuarioCOTPorSF(string UserSF)
        {
            USERS_APPS user = _dbContext.USERS_APPS.Where(x => x.ID_USER_SF == UserSF).FirstOrDefault();
            return user;
        }
    }
}
