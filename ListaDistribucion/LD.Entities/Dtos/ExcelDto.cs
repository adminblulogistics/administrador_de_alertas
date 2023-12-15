using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Entities.Dtos
{
    public class ExcelDto
    {
        public int REGISTRO_NUMBER { get; set; }
        public string ID_ORGANIZATION { get; set; }
        public string NAME_CONTACT { get; set; }
        public string EMAIL_CONTACT { get; set; }
        public string PHONE_CONTACT { get; set; }
        public string ID_EJECUTIVO { get; set; }
        public string ALARMS { get; set; }
        public string LUNES { get; set; }
        public string MARTES { get; set; }
        public string MIERCOLES { get; set; }
        public string JUEVES { get; set; }
        public string VIERNES { get; set; }
        public string SABADO { get; set; }
        public string DOMINGO { get; set; }
        public bool PROCESAR { get; set; }
    }
}
