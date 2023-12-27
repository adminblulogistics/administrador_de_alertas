using LD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.FTP
{
    public interface IFTPManager
    {
        Respuesta obtenerListaArchivos(string nombre);
    }
}
