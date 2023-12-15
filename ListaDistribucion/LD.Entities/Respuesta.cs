namespace LD.Entities
{
    public class Respuesta
    {
        public string CodRespuesta { get; set; }
        public long Id { get; set; }
        public string MensajeRespuesta { get; set; }
        public Boolean ProcesoExitoso { get; set; }
        public Object ObjetoRespuesta { get; set; }
    }
}