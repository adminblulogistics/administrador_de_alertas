using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryInstructive
    {
        List<INSTRUCTIVE> obtenerInstructivos(int? id = null, string tema = "", string descripcion = "", string compania = "", string roles = "", bool? estado = null);
        INSTRUCTIVE obtenerInstructivoPorId(int id);
        Respuesta insertarInstructivo(INSTRUCTIVE instructivo);
        Respuesta actualizarInstructivo(INSTRUCTIVE instructivo);
        Respuesta actualizarInstructivoEliminarArchivo(int idInstructivo, string datoArchivos);
    }
}
