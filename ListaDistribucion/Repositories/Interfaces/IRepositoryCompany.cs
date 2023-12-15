using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryCompany
    {
        List<COMPANIES> obtenerCompanias();
        COMPANIES obtenerCompaniasPorId(int id = 0);
    }
}
