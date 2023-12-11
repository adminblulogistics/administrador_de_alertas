using LD.Entities.Dtos;
using LD.EntitiesGB;

namespace ListaDistribucion.Web.Models.Security
{
    public class SecurityModel : BaseModel
    {
        public List<GB_role> ListadoRoles { get; set; }
        public bool cambiarCompania { get; set; }
        public USERDto Usuario { get; set; }
    }
}
