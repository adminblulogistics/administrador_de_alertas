using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Utilities
{
    public static class GeneralUtilities
    {
        /// <summary>
        /// Permite convertir un valor string en Boleano
        /// </summary>
        /// <param name="valor">valor a convertir</param>
        /// <returns></returns>
        public static bool ConvertBoolean(string valor)
        {
            var convert = Boolean.TryParse(valor, out bool result);
            if(!convert)
                return false;
            return result;
        }
    }
}
