using LD.Integrations.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LD.Integrations.Common
{
    public class CustomRest : ICustomRest
    {
        public string url = "";

        public void setUrl(string url)
        {
            this.url = url;
        }

        //METODO PARA CONSUMIR UN SERVICIO REST
        public string getDataService(string metodo, string parameters = "", string method = "GET", string contentType = "application/json", string authorization = "")
        {

            this.url += metodo;

            if (!string.IsNullOrEmpty(parameters))
                this.url += "?" + parameters;

            var request = (HttpWebRequest)WebRequest.Create(this.url);

            request.Method = method;
            request.ContentType = contentType;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            if (!string.IsNullOrEmpty(authorization))
            {
                request.Headers.Add("Authorization", authorization);
            }

            if (string.IsNullOrEmpty(authorization))
            {
                using (Stream stream = request.GetRequestStream())
                {
                    byte[] content = ASCIIEncoding.ASCII.GetBytes(parameters);
                    stream.Write(content, 0, content.Length);
                }
            }

            string responseBody = string.Empty;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                responseBody = objReader.ReadToEnd();
                            }
                        }
                    }
                }

                var mensaje = new
                {
                    CodRespuesta = "OK",
                    Id = 0,
                    MensajeRespuesta = "Success",
                    ProcesoExitoso = true,
                    ObjetoRespuesta = responseBody
                };

                string jsonMensaje = JsonSerializer.Serialize(mensaje);
                responseBody = jsonMensaje;
            }
            catch (WebException ex)
            {
                var mensaje = new
                {
                    CodRespuesta = "CatchExceptionService-integrationGet",
                    Id = 0,
                    MensajeRespuesta = ex.Message + "-" + ex.InnerException,
                    ProcesoExitoso = false,
                    ObjetoRespuesta = new object()
                };

                string jsonMensaje = JsonSerializer.Serialize(mensaje);
                responseBody = jsonMensaje;
            }
            return responseBody;
        }

        //METODO PARA CONSUMIR UN SERVICIO ENVIANDO OBJETOS CON VALORES CLAVE VALOR - DICTIONARY
        public string putDataService(string metodo, Dictionary<string, string> mensajeD, string contentType = "application/json", string authorization = "", string method = "POST")
        {
            var response = string.Empty;

            Uri u = new Uri(this.url + metodo);

            HttpContent c = new FormUrlEncodedContent(mensajeD);
            var t = Task.Run(() => this.PostURI(u, c, contentType, authorization, method, "PostAsync"));
            t.Wait();
            response = t.Result;

            return response;
        }

        //METODO PARA CONSUMIR UN SERVICIO ENVIANDO OBJETOS SERIALIZADOS
        public string putDataService(string metodo, string mensaje, string contentType = "application/json", string authorization = "", string method = "POST")
        {
            var response = string.Empty;

            Uri u = new Uri(this.url + metodo);

            HttpContent c = new StringContent(mensaje, Encoding.UTF8, contentType);
            var t = Task.Run(() => this.PostURI(u, c, contentType, authorization, method));
            t.Wait();
            response = t.Result;
            return response;
        }

        public async Task<string> PostURI(Uri u, HttpContent c, string contentType, string authorization, string method = "POST", string typeSend = "SendAsync")
        {

            var response = string.Empty;
            try
            {

                HttpClientHandler handler = new HttpClientHandler();
                using (var client = new HttpClient(handler))
                {
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = (method == "POST" ? HttpMethod.Post : (method == "PUT" ? HttpMethod.Put : (method == "PATCH" ? HttpMethod.Patch : HttpMethod.Get))),
                        RequestUri = u,
                        Content = c,
                    };

                    request.Headers.Add("Accept", contentType);

                    if (!string.IsNullOrEmpty(authorization))
                        request.Headers.Add("Authorization", authorization);

                    CancellationToken token = new CancellationToken();
                    await Task.Delay(TimeSpan.FromSeconds(4), token).ConfigureAwait(false);

                    HttpResponseMessage result = new HttpResponseMessage();
                    if (typeSend == "PostAsync")
                        result = await client.PostAsync(u, c);
                    else if (typeSend == "SendAsync")
                        result = await client.SendAsync(request, token).ConfigureAwait(false);

                    if (result.IsSuccessStatusCode)
                    {
                        var jsonStringResponse = await result.Content.ReadAsStringAsync();
                        var mensaje = new
                        {
                            CodRespuesta = result.StatusCode.ToString(),
                            Id = 0,
                            MensajeRespuesta = result.ReasonPhrase.ToString() + "-" + result.RequestMessage.ToString(),
                            ProcesoExitoso = true,
                            ObjetoRespuesta = jsonStringResponse
                        };

                        string jsonMensaje = JsonSerializer.Serialize(mensaje);
                        response = jsonMensaje;
                    }
                    else
                    {
                        var jsonStringResponse = await result.Content.ReadAsStringAsync();
                        var mensaje = new
                        {
                            CodRespuesta = result.StatusCode.ToString(),
                            Id = 0,
                            MensajeRespuesta = result.ReasonPhrase.ToString() + "-" + result.RequestMessage.ToString(),
                            ProcesoExitoso = false,
                            ObjetoRespuesta = jsonStringResponse
                        };

                        string jsonMensaje = JsonSerializer.Serialize(mensaje);
                        response = jsonMensaje;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                var mensaje = new
                {
                    CodRespuesta = "CatchHttpRequestException-integrationPut - " + u.ToString(),
                    Id = 0,
                    MensajeRespuesta = e.Message + "-" + e.InnerException,
                    ProcesoExitoso = false,
                    ObjetoRespuesta = new Object()
                };

                string jsonMensaje = JsonSerializer.Serialize(mensaje);
                response = jsonMensaje;
            }
            catch (Exception e)
            {
                var mensaje = new
                {
                    CodRespuesta = "CatchException-integrationPut - " + u.ToString(),
                    Id = 0,
                    MensajeRespuesta = e.Message + "-" + e.InnerException,
                    ProcesoExitoso = false,
                    ObjetoRespuesta = new Object()
                };

                string jsonMensaje = JsonSerializer.Serialize(mensaje);
                response = jsonMensaje;
            }

            return response;
        }
    }
}
