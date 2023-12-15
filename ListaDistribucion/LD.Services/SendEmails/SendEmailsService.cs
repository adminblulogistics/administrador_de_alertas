using LD.Entities;
using LD.Services.Interfaces.Parameters;
using LD.Services.Interfaces.SendEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.SendEmails
{
    public class SendEmailsService : ISendEmailsService
    {
        private readonly IParametersService _parametersService;
        public SendEmailsService(IParametersService parametersService)
        {
            _parametersService = parametersService;            
        }

        public  Respuesta EnviarCorreo(string asunto, string destinatarios, string body, List<string> adjuntos = null, string emailsCC = "")
        {
            //OBTENEMOS PARAMETROS DEL CORREO
            string serverSMTP = _parametersService.obtenerParametrosSistemaPorDescripcion("SMTP").VALUE;
            string emailSend = _parametersService.obtenerParametrosSistemaPorDescripcion("EmailEnvia").VALUE;
            string passMail = _parametersService.obtenerParametrosSistemaPorDescripcion("PassEmail").VALUE;
            string server = "";//_parametersService.obtenerParametrosSistemaPorDescripcion("UrlBluCotizador").VALUE;
            string copiaLog = _parametersService.obtenerParametrosSistemaPorDescripcion("EmailLog").VALUE;

            Respuesta respuesta = new Respuesta();

            //if (IsSendEmailDevelop())
            //{
            //    body = body + $"<p align=\'center\'>Este correo llegara a: {destinatarios}</p>";
            //    destinatarios = copiaLog;
            //    emailsCC = string.Empty;
            //    copiaLog = string.Empty;
            //}

            try
            {
                MailAddress from = new MailAddress(emailSend, String.Empty, System.Text.Encoding.UTF8);
                MailMessage mail = new MailMessage();

                mail.From = from;

                if (!string.IsNullOrEmpty(destinatarios))
                {
                    destinatarios = destinatarios.Replace(";", ",");
                    var arrDestinatarios = destinatarios.Split(",");
                    foreach (var correo in arrDestinatarios)
                    {
                        if (!string.IsNullOrEmpty(correo))
                            mail.To.Add(correo);
                    }
                }

                if (!string.IsNullOrEmpty(emailsCC))
                {
                    emailsCC = emailsCC.Replace(";", ",");
                    var arrDestinatariosCC = emailsCC.Split(",");
                    foreach (var correo in arrDestinatariosCC)
                    {
                        if (!string.IsNullOrEmpty(correo))
                            mail.CC.Add(correo);
                    }
                }

                if (!string.IsNullOrEmpty(copiaLog))
                {
                    copiaLog = copiaLog.Replace(";", ",");
                    var arrBcc = copiaLog.Split(",");

                    foreach (var Bcc in arrBcc)
                    {
                        if (!string.IsNullOrEmpty(Bcc))
                            mail.Bcc.Add(copiaLog);
                    }
                }

                if (adjuntos != null && adjuntos.Count() > 0)
                {
                    foreach (var rutaAdjunto in adjuntos)
                    {
                        if (!string.IsNullOrEmpty(rutaAdjunto))
                        {
                            Attachment data = new Attachment(rutaAdjunto, MediaTypeNames.Application.Octet);

                            ContentDisposition disposition = data.ContentDisposition;
                            disposition.CreationDate = System.IO.File.GetCreationTime(rutaAdjunto);
                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(rutaAdjunto);
                            disposition.ReadDate = System.IO.File.GetLastAccessTime(rutaAdjunto);

                            mail.Attachments.Add(data);
                        }
                    }
                }

                body = body.Replace("@urlServ", server);

                mail.Subject = asunto;
                mail.IsBodyHtml = true;
                mail.Body = body;

                SmtpClient client = new SmtpClient(serverSMTP);
                client.Port = 25;
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new System.Net.NetworkCredential(emailSend, passMail);
                client.Credentials = cred;
                client.Send(mail);

                respuesta.ProcesoExitoso = true;
            }
            catch (Exception e)
            {
                var error = e.Message;
                respuesta.MensajeRespuesta = e.Message;
                respuesta.ProcesoExitoso = false;
            }

            return respuesta;
        }
    }
}
