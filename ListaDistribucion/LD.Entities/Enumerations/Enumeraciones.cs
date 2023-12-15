using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Entities.Enumerations
{
    public class Enumeraciones
    {
        public enum Pais
        {
            Colombia = 1,
            Ecuador = 2,
            Mexico = 3
        }
        public enum ErroresLogin
        {
            tokenInvalido = 1,
            sesionNula = 2,
            usuarioNoImportado = 3,
            excepcionSistema = 4,
            sessionExpira = 5,
            usuarioSinRol = 6,
        }
        public enum PerfilesModulo
        {
            AA_Ejecutivo_de_cuenta = 182,
            AA_Comercial = 183,
            AA_Sales_Support = 184,
            AA_Lider_Operaciones = 185,
            AA_Administración = 186,
            AA_Supervisor = 187,
            Comercial = 144,
            SaleSupport = 147,
        }
    }
}
