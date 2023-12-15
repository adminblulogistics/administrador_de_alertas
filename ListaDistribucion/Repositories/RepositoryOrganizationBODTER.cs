using LD.DataGB;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public partial class RepositoryOrganizationBODTER : IRepositoryOrganizationBODTER
    {
        private readonly GB_GLOBALContext _dbContext;
        public RepositoryOrganizationBODTER(GB_GLOBALContext dbContext)
        {
            _dbContext = dbContext;
        }        
    }
}
