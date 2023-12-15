using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Utilities.ExtensionMethods
{
    public static class Select2Extensions
    {
        public static IHtmlContent Select2(this IHtmlHelper helper, string id, IEnumerable<SelectListItem> selectList, string mensajeDefecto, bool requerido, bool multiple, string valorSeleccionado, int maxItemMultiple = 0, int minimumInputLength = 0)
        {
            StringBuilder sb = new StringBuilder();

            //DETERMINAMOS SI ES MULTIPLE CUANTOS  ITEMS PUEDE SELECCIONAR
            string maximumSelectionLength = "";
            if (multiple)
            {
                maximumSelectionLength = ",maximumSelectionLength:" + maxItemMultiple.ToString();
            }

            //DETERMINAMOS CON CUANTOS CARACTERES INICIA LA BUSQUEDA
            string strMinimumInputLength = "";
            if (minimumInputLength > 0)
            {
                strMinimumInputLength = ",minimumInputLength:" + minimumInputLength.ToString();
            }

            var scriptLoad = "<script>$(document).ready(function(){$('#" + id + "').select2({ placeholder: '" + mensajeDefecto + "', allowClear: true" + maximumSelectionLength + " " + strMinimumInputLength + " }).change(function(){if($(this).val() != ''){$(this).removeClass('invalid');$('#select2-' + $(this).attr('id') + '-container').parent().removeClass('invalid');}});});</script>";

            if (multiple == true)
                sb.Append("<select id = '" + id + "' multiple = 'multiple' name='" + id + "' class='form-control form-control-sm " + (requerido ? "required" : "") + "' style=''>");
            else
            {
                sb.Append("<select id = '" + id + "'  name='" + id + "' class='form-control form-control-sm " + (requerido ? "required" : "") + "' style='width:100%;'>");
                sb.Append("<option value=''>Seleccione uno...</option>");

            }

            if (selectList != null)
            {
                if (valorSeleccionado != null)
                {
                    foreach (var item in selectList)
                    {
                        bool seleccionado = false;
                        string[] valores;
                        valores = valorSeleccionado.Split(',');
                        foreach (var val in valores)
                        {
                            if (item.Value == val)
                            {
                                sb.Append("<option value='" + item.Value + "' selected='selected'>" + item.Text + "</option>");
                                seleccionado = true;
                            }

                        }
                        if (seleccionado == false)
                            sb.Append("<option value='" + item.Value + "'>" + item.Text + "</option>");
                    }
                }
                else
                {
                    foreach (var item in selectList)
                    { sb.Append("<option value='" + item.Value + "'>" + item.Text + "</option>"); }
                }
            }
            sb.Append("</select>");
            sb.Append(scriptLoad);

            return new HtmlString(sb.ToString());
        }

        public static IHtmlContent Select2(this IHtmlHelper helper, string id, string action, string mensajeDefecto, bool requerido, string valorSeleccionado, string textoSeleccionado, int minimumInputLength = 2, bool multiple = false, string param1 = "", string param2 = "")
        {
            StringBuilder sb = new StringBuilder();

            //DETERMINAMOS CON CUANTOS CARACTERES INICIA LA BUSQUEDA
            string strMinimumInputLength = "";
            if (minimumInputLength > 0)
            {
                strMinimumInputLength = ",minimumInputLength:" + minimumInputLength.ToString();
            }

            string textParam1 = "";
            if (!string.IsNullOrEmpty(param1))
            {
                textParam1 = "f1: $('#" + param1 + "').val(),";
            }

            string textParam2 = "";
            if (!string.IsNullOrEmpty(param2))
            {
                textParam2 = "f2: $('#" + param2 + "').val(),";
            }

            string strAjax = @"{
                                    url: pathToAction() + '/JsonData/" + action + @"',
                                    dataType: 'json',
                                    delay: 250,
                                    data: function(params) {
                                        if (params.term != '') {
                                            return {
                                                f: params.term,
                                                " + textParam1 + @"
                                                " + textParam2 + @"
                                                page: params.page
                                            };
                                        }
                                    },
                                    processResults: function(data) {
                                        return {
                                            results: $.map(data, function(item, i) {
                                                return {
                                                    text: item.text,
                                                    id: item.value                                                    
                                                }
                                            })
                                        };
                                    },
                                    cache: true
                               }";

            var scriptLoad = "<script>$(document).ready(function(){$('#" + id + "').select2({ placeholder: '" + mensajeDefecto + "', ajax: " + strAjax + ",allowClear: true" + strMinimumInputLength + " }).change(function(){if($(this).val() != ''){$(this).removeClass('invalid');$('#select2-' + $(this).attr('id') + '-container').parent().removeClass('invalid');}});});</script>";

            if (multiple == true)
                sb.Append("<select id = '" + id + "' multiple = 'multiple' name='" + id + "' class='form-control form-control-sm " + (requerido ? "required" : "") + "' style=''>");

            else
            {
                sb.Append("<select id = '" + id + "'  name='" + id + "' class='form-control form-control-sm " + (requerido ? "required" : "") + "' style='width:100%;'>");
                sb.Append("<option value=''>Seleccione uno...</option>");
            }

            //DETERMINAMOS SI HAY DATO SELECCIONADO PARA AGREGARLO AL SELECT
            if (!string.IsNullOrEmpty(valorSeleccionado) && !string.IsNullOrEmpty(textoSeleccionado))
                sb.Append("<option value='" + valorSeleccionado + "' selected='selected'>" + textoSeleccionado + "</option>");

            sb.Append("</select>");
            sb.Append(scriptLoad);



            return new HtmlString(sb.ToString());
        }
    }
}
