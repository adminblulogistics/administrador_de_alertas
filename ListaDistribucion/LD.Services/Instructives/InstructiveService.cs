using LD.Services.Interfaces.Instructives;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LD.EntitiesLD;
using LD.Entities;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;

namespace LD.Services.Instructives
{
    public partial class InstructiveService: Common.BaseServiceApplication<LD.EntitiesLD.INSTRUCTIVE>,IInstructiveService
    {
        private readonly IRepositoryInstructive _repositoryInstructives;
        private readonly IHostingEnvironment _hostingEnvironment;
        public InstructiveService(IRepositoryInstructive repositoryInstructives, IHostingEnvironment hostingEnvironment)
        {
            _repositoryInstructives = repositoryInstructives;
            _hostingEnvironment = hostingEnvironment;
        }

        public List<INSTRUCTIVE> obtenerInstructivos(int? id = null, string tema = "", string descripcion = "", string compania = "", string roles = "", bool? estado = null)
        {
            return _repositoryInstructives.obtenerInstructivos(id, tema, descripcion, compania, roles, estado);
        }
        public INSTRUCTIVE obtenerInstructivoPorId(int id)
        {
            return _repositoryInstructives.obtenerInstructivoPorId(id);
        }
        public Respuesta insertarInstructivo(INSTRUCTIVE instructivo)
        {
            return _repositoryInstructives.insertarInstructivo(instructivo);
        }
        public Respuesta actualizarInstructivo(INSTRUCTIVE instructivo)
        {
            return _repositoryInstructives.actualizarInstructivo(instructivo);
        }
        public Respuesta saveInstructive(List<IFormFile> documentos, int idInstructivo, string tema, string descripcion, string companias, string roles, string fileInstructive, bool status)
        {
            Respuesta resp = new Respuesta();
            string ruta = "";
            if (documentos != null && documentos.Count() > 0)
            {
                foreach (var documento in documentos)
                {
                    string nombreArchivoFinal = "instructive_" + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "_" + new FileInfo(documento.FileName).Name;
                    nombreArchivoFinal = Regex.Replace(nombreArchivoFinal, @"[^a-zA-z0-9. ]+", "");
                    nombreArchivoFinal = Regex.Replace(nombreArchivoFinal, @"\s+", "");

                    var contentRootPath = _hostingEnvironment.WebRootPath;

                    string dirComplete = Path.Combine(contentRootPath, @"./documents/instructives/");
                    if (!Directory.Exists(dirComplete))
                    {
                        Directory.CreateDirectory(dirComplete);
                    }

                    ruta = Path.Combine(contentRootPath, @"./documents/instructives/", nombreArchivoFinal);

                    FileInfo fi1 = new FileInfo(ruta);

                    using (FileStream fs = fi1.Create())
                    {
                        documento.CopyTo(fs);
                    }

                    fileInstructive += nombreArchivoFinal + ";";
                }                
            }
            INSTRUCTIVE instructivo = new INSTRUCTIVE
            {
                ID_INSTRUCTIVE = idInstructivo,
                TOPIC = tema,
                DESCRIPTION = descripcion,
                COMPANIES = companias,
                ROLES = roles,
                ATTACHED = fileInstructive,
                IS_ACTIVE = status
            };

            if (idInstructivo == 0)
                resp = _repositoryInstructives.insertarInstructivo(instructivo);
            else
                resp = _repositoryInstructives.actualizarInstructivo(instructivo);

            return resp;
        }
        public (Byte[],string) VerArchivo(int idInstructivo, int item)
        {
            Respuesta respuesta = new Respuesta();
            INSTRUCTIVE instructivo = new INSTRUCTIVE();
            instructivo = _repositoryInstructives.obtenerInstructivoPorId(idInstructivo);

            string nombreArchivo = instructivo.ATTACHED;
            var arrArchivos = nombreArchivo.Split(';');
            nombreArchivo = arrArchivos[item];

            Byte[] archivo = null;
            var contentRootPath = _hostingEnvironment.WebRootPath;
            string pathFile = Path.Combine(contentRootPath, @"./documents/instructives/", nombreArchivo);

            archivo = System.IO.File.ReadAllBytes(pathFile);

            return (archivo, nombreArchivo);
        }
        public Respuesta EliminarArchivo(int idInstructivo, int item)
        {
            Respuesta respuesta = new Respuesta();
            string nuevoDatoArchivos = string.Empty;
            string nombreArchivo = string.Empty;
            INSTRUCTIVE instructivo = new INSTRUCTIVE();
            instructivo = _repositoryInstructives.obtenerInstructivoPorId(idInstructivo);

            nombreArchivo = instructivo.ATTACHED;
            var arrArchivos = nombreArchivo.Split(';');
            arrArchivos = arrArchivos.Where((source, index) => index != item).ToArray();
            nuevoDatoArchivos = string.Join(';', arrArchivos);
            nombreArchivo = arrArchivos[item];

            respuesta = _repositoryInstructives.actualizarInstructivoEliminarArchivo(idInstructivo, nuevoDatoArchivos);
            if (respuesta.ProcesoExitoso == true)
            {
                var contentRootPath = _hostingEnvironment.WebRootPath;
                string dirComplete = Path.Combine(contentRootPath, @"./documents/instructives/");
                string pathFile = Path.Combine(dirComplete, nombreArchivo);

                //BORRAMOS EL ARCHIVO FISICO
                if (System.IO.File.Exists(pathFile))
                {
                    System.IO.File.Delete(pathFile);
                }
            }
            return respuesta;
        }
    }
}
