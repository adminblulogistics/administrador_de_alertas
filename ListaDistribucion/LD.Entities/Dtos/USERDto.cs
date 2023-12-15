using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Entities.Dtos
{
    public class USERDto
    {
        public int ID_USER { get; set; }
        public string ID_USER_SF { get; set; }
        public string ID_USER_CW { get; set; }
        public string USERNAME { get; set; }
        public string DOCUMENT_NUMBER { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string POSITION { get; set; }
        public string EMAIL { get; set; }
        public bool? IS_ACTIVE { get; set; }
        public string BRANCH { get; set; }
        public long? ID_COMPANY { get; set; }
        public string COMPANY_NAME { get; set; }
        public bool? CHANGE_COUNTRY { get; set; }
        public int? DEFAULT_ROL { get; set; }
    }
}
