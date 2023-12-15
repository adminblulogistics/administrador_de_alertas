using LD.Entities;
using LD.EntitiesLD;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Instructives
{
    public interface IInstructiveService
    {
        List<INSTRUCTIVE> obtenerInstructivos(int? id = null, string tema = "", string descripcion = "", string compania = "", string roles = "", bool? estado = null);
        INSTRUCTIVE obtenerInstructivoPorId(int id);
        Respuesta insertarInstructivo(INSTRUCTIVE instructivo);
        Respuesta actualizarInstructivo(INSTRUCTIVE instructivo);
        Respuesta saveInstructive(List<IFormFile> documentos, int idInstructivo, string tema, string descripcion, string companias, string roles, string fileInstructive, bool status);
        (Byte[], string) VerArchivo(int idInstructivo, int item);
        Respuesta EliminarArchivo(int idInstructivo, int item);
    }
}
