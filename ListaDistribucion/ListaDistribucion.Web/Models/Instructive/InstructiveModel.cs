using LD.EntitiesLD;

namespace ListaDistribucion.Web.Models.Instructive
{
    public class InstructiveModel : BaseModel
    {
        public INSTRUCTIVE instructivo { get; set; }
        public List<INSTRUCTIVE> ListadoInstructivos { get; set; }
        public List<COMPANIES> ListadoCompanies { get; set; }
    }
}
