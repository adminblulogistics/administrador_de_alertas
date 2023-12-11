using LD.Entities;
using LD.Integrations.Common.Interfaces;
using LD.Integrations.SaleForce;
using LD.Services.Interfaces.Integration;
using LD.Services.Interfaces.Users;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Integration
{
    public partial class IntegrationService: IIntegrationService
    {
        private readonly IIntegrationSalesForce _integrationSalesForce;
        private readonly IUserService _userService;
        public IntegrationService(IIntegrationSalesForce integrationSalesForce, IUserService userService)
        {
            _integrationSalesForce = integrationSalesForce;
            _userService = userService;
        }
        public Respuesta actualizarAliasSF(int idUsuario, string correo)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                respuesta = _integrationSalesForce.ConsultarUsuarioSF(correo);

                if (respuesta.ProcesoExitoso)
                {
                    var usuario = _userService.obtenerUsuarioLDPorID(idUsuario);

                    JObject jsonObj = JObject.Parse(respuesta.ObjetoRespuesta.ToString());
                    var registros = jsonObj["records"];
                    var totalRegistros = Convert.ToInt32(jsonObj["totalSize"]);
                    List<JToken> children = registros.Children().ToList();

                    if (totalRegistros > 0)
                    {
                        string aliasSF = string.Empty;
                        for (int i = 0; i < totalRegistros; i++)
                        {
                            aliasSF = registros[i]["Alias"].ToString();
                        }

                        usuario.ID_USER_SF = aliasSF;
                        respuesta = _userService.actualizarUsuario(usuario);
                    }

                }
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
                respuesta.ProcesoExitoso = false;
            }

            return respuesta;
        }
    }
}
