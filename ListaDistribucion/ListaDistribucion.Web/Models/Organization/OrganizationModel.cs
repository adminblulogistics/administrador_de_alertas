using LD.Entities.Dtos;
using LD.EntitiesLD;

namespace ListaDistribucion.Web.Models.Organization
{
    public class OrganizationModel: BaseModel
    {
        public List<USERDto> ListaUsuariosComerciales { get; set; }
        public List<USERDto> ListaUsuariosSaleSupport { get; set; }
        public List<USERDto> ListaUsuariosEjecutivos { get; set; }
        public List<ORGANIZATIONDto> Listaorganizaciones { get; set; }
        public List<CONTACTS> ListadoContactos { get; set; }
        public List<ALARMS> ListAlarms { get; set; }
        public CONTACTS Contacto { get; set; }
        public ORGANIZATIONDto Organizacion { get; set; }
    }
}
