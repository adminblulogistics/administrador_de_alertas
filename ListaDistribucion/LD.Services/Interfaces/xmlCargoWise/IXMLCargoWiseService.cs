using LD.Entities.xmlCargoWise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.xmlCargoWise
{
    public interface IXMLCargoWiseService
    {
        Consol ConvertInfoConsol(UniversalInterchange InfoConsol, string paisCompania);
    }
}
