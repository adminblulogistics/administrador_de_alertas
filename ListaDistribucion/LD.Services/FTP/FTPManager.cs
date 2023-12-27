using FluentFTP;
using LD.Entities;
using LD.Entities.xmlCargoWise;
using LD.Services.Interfaces.FTP;
using LD.Services.Interfaces.Parameters;
using LD.Utilities.xml;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.FTP
{
    public class FTPManager : IFTPManager
    {
        private readonly IConfiguration _config;
        private readonly IParametersService _parametersService;
        public FTPManager(IConfiguration config, IParametersService parametersService)
        { 
            _config = config;
            _parametersService = parametersService;
        }
        public Respuesta obtenerListaArchivos(string nombre)
        {
            Respuesta respuesta = new Respuesta();
            List<UniversalInterchange> archivos = new List<UniversalInterchange>();
            try
            {
                var ftpClient = configuration().Item1;
                var carpetaLeerCol = configuration().Item2;
                ftpClient.Connect();

                foreach (FtpListItem item in ftpClient.GetListing(carpetaLeerCol))
                {
                    var contentArchivo = string.Empty;
                    if (item.Type == FtpObjectType.File && item.FullName.Contains(nombre))
                    {
                        Files file= new Files();
                        Stream fileData = ftpClient.OpenRead($"{carpetaLeerCol}/{item.Name}");
                        using (StreamReader sr = new StreamReader(fileData))
                        {
                            contentArchivo = sr.ReadToEnd();
                            UniversalInterchange XmlToObject = XMLUtilities.convertXMLtoObject<UniversalInterchange>(contentArchivo);
                            if(XmlToObject != null)
                                archivos.Add(XmlToObject);
                        }
                    }
                }
                ftpClient.Disconnect();
                if (archivos.Any())
                {
                    respuesta.ProcesoExitoso = true;
                    respuesta.ObjetoRespuesta = archivos;
                }
            } 
            catch (Exception ex)
            {
                respuesta.ProcesoExitoso = false;
                respuesta.ObjetoRespuesta = new List<UniversalInterchange>();
                respuesta.MensajeRespuesta = ex.Message;
            }
            return respuesta;
        }
        private (FtpClient,string) configuration()
        {
            var ftpServer = _parametersService.obtenerParametrosSistemaPorDescripcion("FtpServer").VALUE;
            var ftpUserName = _parametersService.obtenerParametrosSistemaPorDescripcion("FtpUserName").VALUE;
            var ftpUserPass = _parametersService.obtenerParametrosSistemaPorDescripcion("FtpUserPass").VALUE;
            var carpetaLeerCol = _parametersService.obtenerParametrosSistemaPorDescripcion("CarpetaLeerCol").VALUE;
            return (new FtpClient(ftpServer, ftpUserName, ftpUserPass),carpetaLeerCol);
        }
    }
}
