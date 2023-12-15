using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Utilities
{
    public static class GeneralUtilities
    {
        public static bool ConvertBoolean(string valor)
        {
            var convert = Boolean.TryParse(valor, out bool result);
            if(!convert)
                return false;
            return result;
        }
    }
}
