using LD.Entities.Dtos;
using LD.EntitiesGB;
using LD.EntitiesLD;

namespace ListaDistribucion.Web.Models.Users
{
    public class UserModel : BaseModel
    {
        public GB_user usuario { get; set; }
        public USERDto usuarioDto { get; set; }
        public List<USERDto> ListadoUsuariosLD { get; set; }
        public List<GB_user> ListadoUsuariosGB { get; set; }
        public List<COMPANIES> Companias { get; set; }
        public List<GB_role> ListadoRoles { get; set; }
        public List<GB_userRole> ListadoAsignacionesRol { get; set; }
    }
}
