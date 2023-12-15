using LD.EntitiesGB;

namespace ListaDistribucion.Web.Models
{
    public class HomeModel : BaseModel
    {
        public int errorCode { get; set; }
        public string urlLogin { get; set; }
        public string urlLogout { get; set; }
        public string systemException { get; set; }
        public List<GB_module> ListadoModulosPadres { get; set; }
        public List<GB_module> ListadoModulosHijos { get; set; }
    }
}
