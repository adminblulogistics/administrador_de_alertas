using LD.Entities;
using LD.Integrations.Common.Interfaces;
using LD.Repositories.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Integrations.SaleForce
{
    public class IntegrationSalesForce: IIntegrationSalesForce
    {
        private readonly ICustomRest _customRest;
        private readonly IRepositoryParameters _repositoryParameters;
        public IntegrationSalesForce(ICustomRest customRest, IRepositoryParameters repositoryParameters)
        {
            _customRest = customRest;
            _repositoryParameters = repositoryParameters;
        }
        public string authorization = "";
        public string urlService = "";

        #region Servicios

        public Respuesta GetToken()
        {

            Respuesta respuesta = new Respuesta();
            _customRest.setUrl(_repositoryParameters.obtenerParametrosSistemaPorDescripcion("UrlServicesSF").VALUE);
            string userName = _repositoryParameters.obtenerParametrosSistemaPorDescripcion("UserNameSF").VALUE;
            string passUser = _repositoryParameters.obtenerParametrosSistemaPorDescripcion("PassUserSF").VALUE;
            string customerKey = _repositoryParameters.obtenerParametrosSistemaPorDescripcion("CustomerKeySF").VALUE;
            string customerSecret = _repositoryParameters.obtenerParametrosSistemaPorDescripcion("CustomerSecret").VALUE;

            var mensaje = new Dictionary<string, string>
            {
                {"grant_type","password"},
                {"client_id",customerKey},
                {"client_secret",customerSecret},
                {"username",userName},
                {"password",passUser},
            };

            var resp = _customRest.putDataService("oauth2/token", mensaje, "application/x-www-form-urlencoded");
            respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            if (respuesta.ProcesoExitoso)
            {

                JObject jsonObj = JObject.Parse(respuesta.ObjetoRespuesta.ToString());
                string tokenType = (String)jsonObj["token_type"];
                string authToken = (String)jsonObj["access_token"];
                string serviceURL = (String)jsonObj["instance_url"];

                if (!string.IsNullOrEmpty(authToken))
                {
                    this.authorization = tokenType + " " + authToken;
                    this.urlService = serviceURL;
                    respuesta.ProcesoExitoso = true;
                }
            }

            return respuesta;
        }

        public Respuesta ConsultarSQLSF(string sql)
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                _customRest.setUrl(this.urlService + "/services/");
                string strSQL = sql;

                var resp = _customRest.putDataService("data/v53.0/queryAll/?q=" + strSQL, string.Empty, "application/json", authorization, "GET");
                respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            }

            return respuesta;
        }

        public Respuesta ConsultarClienteSF(string nombre = "", string identificacion = "", string pais = "")
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                _customRest.setUrl(this.urlService + "/services/");

                string strSQL = "select+id,+TaxID__c,+name,+phone,+BillingStreet,+BillingCity,+BillingCountry,+OwnerId,+Owner.FirstName,+Owner.LastName,+Owner.alias,+createddate,";
                strSQL += "(SELECT+id,+Name,+email,+Phone,+Title,+isDeleted+FROM+Contacts)";
                strSQL += "+from + Account";

                if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(identificacion))
                    strSQL = strSQL + "+where+";

                if (!string.IsNullOrEmpty(nombre))
                    strSQL = strSQL + "+name+like+'%" + nombre + "%'";

                if (!string.IsNullOrEmpty(identificacion))
                    strSQL = strSQL + "+TaxID__c+=+'" + identificacion + "'";

                //if (!string.IsNullOrEmpty(pais))
                //    strSQL = strSQL + "+AND+BillingCountry+=+'" + pais + "'";

                var resp = _customRest.putDataService("data/v53.0/queryAll/?q=" + strSQL, string.Empty, "application/json", authorization, "GET");
                respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            }

            return respuesta;
        }

        public Respuesta ConsultarUsuarioSF(string correo = "")
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                _customRest.setUrl(this.urlService + "/services/");
                string strSQL = "select+FirstName,+LastName,+Alias,+email+from+user+where+";

                if (!string.IsNullOrEmpty(correo))
                    strSQL = strSQL + "+email+=+'" + correo + "'";

                var resp = _customRest.putDataService("data/v53.0/query/?q=" + strSQL, string.Empty, "application/json", authorization, "GET");
                respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            }

            return respuesta;
        }

        public Respuesta ConsultarOportunidadesClienteSF(string idClienteSF = "", string nombreOportunidad = "")
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                _customRest.setUrl(this.urlService + "/services/");
                string strSQL = "select+Id,+name,+createddate,+CloseDate,+LastModifiedDate,+StageName,+AccountId,+Amount,+From_Date__c,+To_Date__c,+PortPairs__c,+quote_id__c+,Volume_Teus__c+from+opportunity+where+";

                if (!string.IsNullOrEmpty(idClienteSF))
                    strSQL = strSQL + "+AccountId+=+'" + idClienteSF + "'";

                if (!string.IsNullOrEmpty(nombreOportunidad))
                    strSQL = strSQL + "+AND+name+like+'%25" + nombreOportunidad.ToUpper() + "%25'";

                var resp = _customRest.putDataService("data/v53.0/query/?q=" + strSQL, string.Empty, "application/json", authorization, "GET");
                respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            }

            return respuesta;
        }

        public Respuesta ConsultarOportunidadSF(string idOportunidadSF = "")
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                _customRest.setUrl(this.urlService + "/services/");
                string strSQL = "select+Id,+name,+createddate,+CloseDate,+LastModifiedDate,+StageName,+AccountId,+Amount,+From_Date__c,+To_Date__c,+PortPairs__c,+quote_id__c,+Volume_Teus__c+from+opportunity+where+";

                if (!string.IsNullOrEmpty(idOportunidadSF))
                    strSQL = strSQL + "+Id+=+'" + idOportunidadSF + "'";

                var resp = _customRest.putDataService("data/v53.0/query/?q=" + strSQL, string.Empty, "application/json", authorization, "GET");
                respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            }

            return respuesta;
        }

        public Respuesta ActualizarOportunidad(string idOportunidad = "", string tipo = "", string idQuote = "", string motivoPerdida = "")
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();
            string resp = string.Empty;

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                _customRest.setUrl(this.urlService + "/services/");
                var mensaje = new object();

                if (tipo == "ProposalQuote")
                {
                    mensaje = new
                    {
                        //To_Date__c = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), // ES REQUERIDO PERO NO SE DEBE ENVIAR POR QUE SE LLENA EN SF
                        StageName = "Proposal/Quote",
                        Quote_ID__c = idQuote
                    };
                }

                if (tipo == "ClosedWon")
                {
                    mensaje = new
                    {
                        CloseDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        StageName = "Closed Won",
                        Quote_ID__c = idQuote
                    };
                }

                if (tipo == "ClosedLost")
                {
                    mensaje = new
                    {
                        CloseDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        StageName = "Closed Lost",
                        Quote_ID__c = idQuote,
                        LossReason__c = motivoPerdida
                    };
                }

                if (tipo == "Negotiation")
                {
                    mensaje = new
                    {
                        StageName = "Negotiation",
                        Quote_ID__c = idQuote
                    };
                }
                if (tipo == "Discovery")
                {
                    mensaje = new
                    {
                        StageName = "Discovery",
                        Quote_ID__c = idQuote
                    };
                }

                string jsonMensaje = JsonConvert.SerializeObject(mensaje);
                resp = _customRest.putDataService("data/v53.0/sobjects/Opportunity/" + idOportunidad + "?_HttpMethod=PATCH", jsonMensaje, "application/json", authorization, "POST");

                respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);

            }

            return respuesta;
        }

        public Respuesta VincularDocumento(string idOportunidad = "", string titulo = "", string pathFile = "", string versionData = "")
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaToken = new Respuesta();

            respuestaToken = this.GetToken();

            if (respuestaToken.ProcesoExitoso)
            {
                try
                {
                    _customRest.setUrl(this.urlService + "/services/");
                    var mensaje = new object();

                    mensaje = new
                    {
                        Title = titulo,
                        PathOnClient = pathFile,
                        VersionData = versionData
                    };

                    string jsonMensaje = JsonConvert.SerializeObject(mensaje);

                    var resp = _customRest.putDataService("data/v55.0/sobjects/ContentVersion", jsonMensaje, "application/json", authorization, "POST");
                    respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);
                    if (respuesta.ProcesoExitoso)
                    {
                        dynamic respJson = JsonConvert.DeserializeObject<dynamic>(respuesta.ObjetoRespuesta.ToString());
                        var idContentVersion = respJson["id"].Value;

                        var resp1 = _customRest.putDataService("data/v55.0/sobjects/ContentVersion/" + idContentVersion, "", "application/json", authorization, "GET");
                        Respuesta respuesta1 = JsonConvert.DeserializeObject<Respuesta>(resp1);
                        JObject jsonObj = JObject.Parse(respuesta1.ObjetoRespuesta.ToString());
                        dynamic respJson1 = JsonConvert.DeserializeObject<dynamic>(respuesta1.ObjetoRespuesta.ToString());
                        var idContentDocument = jsonObj["ContentDocumentId"].ToString();

                        mensaje = new
                        {
                            ContentDocumentId = idContentDocument,
                            LinkedEntityId = idOportunidad,
                            ShareType = "V"
                        };

                        string jsonMensaje1 = JsonConvert.SerializeObject(mensaje);
                        resp = _customRest.putDataService("data/v55.0/sobjects/ContentDocumentLink", jsonMensaje1, "application/json", authorization, "POST");
                        respuesta = JsonConvert.DeserializeObject<Respuesta>(resp);
                    }
                    else
                    {
                        respuesta.MensajeRespuesta += " - Error proceso ContentVersion SF";
                    }
                }
                catch (Exception e)
                {
                    respuesta.ProcesoExitoso = false;
                    respuesta.MensajeRespuesta += " - Error al enviar documento a SF";
                }

            }

            return respuesta;
        }


        #endregion
    }
}
