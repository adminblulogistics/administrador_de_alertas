using LD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.SendEmails
{
    public interface ISendEmailsService
    {
        Respuesta EnviarCorreo(string asunto, string destinatarios, string body, List<string> adjuntos = null, string emailsCC = "");
    }
}
