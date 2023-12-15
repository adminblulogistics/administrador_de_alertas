using LD.EntitiesCotizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryUserCOT
    {
        USERS_APPS obtenerUsuarioCOTPorID(int idUser);
        USERS_APPS obtenerUsuarioCOTPorSF(string UserSF);
    }
}
