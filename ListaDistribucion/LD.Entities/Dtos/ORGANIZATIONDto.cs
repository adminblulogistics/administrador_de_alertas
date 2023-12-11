using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Entities.Dtos
{
    public class ORGANIZATIONDto
    {
        public long ID { get; set; }
        public string NAME { get; set; }
        public string IDENTIFICACION { get; set; }
        public string COMERCIAL { get; set; }
        public int ID_COMERCIAL { get; set; }
        public List<string> SALESUPPORT { get; set; }
        public string EJECUTIVO { get; set; }
        public int ID_EJECUTIVO { get; set; }
    }
}
