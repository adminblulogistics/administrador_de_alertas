using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Integrations.Common.Interfaces
{
    public interface ICustomRest
    {
        void setUrl(string url);
        string getDataService(string metodo, string parameters = "", string method = "GET", string contentType = "application/json", string authorization = "");
        string putDataService(string metodo, Dictionary<string, string> mensajeD, string contentType = "application/json", string authorization = "", string method = "POST");
        string putDataService(string metodo, string mensaje, string contentType = "application/json", string authorization = "", string method = "POST");
        Task<string> PostURI(Uri u, HttpContent c, string contentType, string authorization, string method = "POST", string typeSend = "SendAsync");

    }
}
