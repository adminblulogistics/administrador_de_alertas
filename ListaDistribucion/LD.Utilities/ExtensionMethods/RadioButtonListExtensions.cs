using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LD.Utilities.ExtensionMethods
{
    public static class RadioButtonListExtensions
    {
        public enum TipoLista
        {
            SiNo = 1,
            MascFem = 2,
            ActInact = 3,
            RespuestaLower = 4,
            BoolToInt = 5,
        }

        public static IHtmlContent RadioButtonList(this IHtmlHelper helper, string id, List<string[]> itemsList, bool required, string value, string htmlSeparated = " ", string onclick = "", string name = "", string cssClass = "")
        {
            StringBuilder sb = new StringBuilder();
            bool isChecked = false;
            string realName = "";

            htmlSeparated = string.IsNullOrEmpty(htmlSeparated) ? "&nbsp;&nbsp;" : htmlSeparated;

            if (required)
                sb.Append("<div id='divRadio" + id + "' class='form-control radio_obligatorio'>");

            foreach (var item in itemsList)
            {
                isChecked = false;
                if (value != "")
                {
                    if (value == item[0])
                        isChecked = true;
                }

                realName = id;
                if (!string.IsNullOrEmpty(name))
                    realName = name;

                var inputTag = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("input");
                inputTag.Attributes.Add("type", "radio");
                inputTag.Attributes.Add("id", id);
                inputTag.Attributes.Add("name", realName);
                inputTag.Attributes.Add("value", item[0]);
                inputTag.Attributes.Add("onclick", onclick);
                inputTag.AddCssClass(cssClass);


                if (isChecked)
                    inputTag.Attributes.Add("checked", "checked");
                
                if (required)
                {
                    inputTag.Attributes.Remove("onclick");
                    inputTag.Attributes.Add("onclick", "customValidateRadio('" + id + "'); " + onclick);
                    inputTag.AddCssClass("required");
                }



                string tagResult;

                using (var writer = new StringWriter())
                {
                    inputTag.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                    tagResult = writer.ToString();
                }

                sb.Append(item[1] + " " + tagResult + htmlSeparated);

            }

            if (required)
                sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

        public static IHtmlContent RadioButtonList(this IHtmlHelper helper, string id, TipoLista pTipoLista, bool required, string value, bool isDisable = false, string htmlSeparated = "&nbsp;&nbsp;", string onclick = "", string name = "", bool stringValue = false, string cssClass = "")
        {
            StringBuilder sb = new StringBuilder();
            bool isChecked = false;
            string realName = "";
            List<string[]> itemsList = new List<string[]>();

            htmlSeparated = string.IsNullOrEmpty(htmlSeparated) ? "&nbsp;&nbsp;" : htmlSeparated;

            switch (pTipoLista)
            {
                case TipoLista.SiNo:
                    itemsList = new List<string[]>()
                    {
                        new string[]{ "True", "Sí" },
                        new string[]{ "False", "No" }
                    }; break;
                case TipoLista.MascFem:
                    itemsList = new List<string[]>()
                    {
                        new string[]{"F","Femenino"},
                        new string[]{"M","Masculino"}
                    }; break;
                case TipoLista.ActInact:
                    itemsList = new List<string[]>()
                    {
                        new string[]{ "True", "Activo" },
                        new string[]{ "False", "Inactivo" }
                    }; break;
                case TipoLista.RespuestaLower:
                    itemsList = new List<string[]>()
                    {
                        new string[]{ "Aprobar", "Aprobar" },
                        new string[]{ "Rechazar", "Rechazar" },
                        new string[]{ "Modificar", "Modificar" },
                    }; break;
                case TipoLista.BoolToInt:
                    itemsList = new List<string[]>()
                    {
                        new string[]{ "1", "Si" },
                        new string[]{ "0", "No" }
                    }; break;
            }

            //if (required)
            sb.Append("<div id='divRadio" + id + "' class='form-control'>");

            foreach (var item in itemsList)
            {
                isChecked = false;
                if (value != "")
                {
                    if (value == item[0])
                        isChecked = true;
                }

                realName = id;
                if (!string.IsNullOrEmpty(name))
                    realName = name;

                var inputTag = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("input");
                inputTag.Attributes.Add("type", "radio");
                inputTag.Attributes.Add("id", id);
                inputTag.Attributes.Add("name", realName);
                inputTag.Attributes.Add("value", item[0]);
                inputTag.Attributes.Add("onclick", onclick);
                inputTag.AddCssClass(cssClass);


                if (isChecked)
                    inputTag.Attributes.Add("checked", "checked");

                if (isDisable)
                    inputTag.Attributes.Add("disabled", "disabled");


                if (required)
                {
                    inputTag.Attributes.Remove("onclick");
                    inputTag.Attributes.Add("onclick", "customValidateRadio('" + id + "'); " + onclick);
                    inputTag.AddCssClass("required");
                }

                string tagResult;

                using (var writer = new StringWriter())
                {
                    inputTag.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                    tagResult = writer.ToString();
                }

                sb.Append(item[1] + " " + tagResult + htmlSeparated);
            }

            //if (required)
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

        public static IHtmlContent RadioButtonList(this IHtmlHelper helper, string id, string itemsList, bool required, string value, string htmlSeparated = " ", string onclick = "", string name = "", string cssClass = "", bool checkear = false)
        {
            StringBuilder sb = new StringBuilder();
            bool isChecked = false;
            string realName = "";

            htmlSeparated = string.IsNullOrEmpty(htmlSeparated) ? "&nbsp;&nbsp;" : htmlSeparated;

            if (required)
                sb.Append("<div id='divRadio" + id + "'class=''>");
            //sb.Append("<div id='divRadio" + id + "'class='form-control radio_obligatorio'>");

            isChecked = false;
            if (value != "")
            {
                if (value == itemsList)
                    isChecked = true;
            }

            realName = id;
            if (!string.IsNullOrEmpty(name))
                realName = name;

            var inputTag = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("input");
            inputTag.Attributes.Add("type", "radio");
            inputTag.Attributes.Add("id", id);
            inputTag.Attributes.Add("name", realName);
            inputTag.Attributes.Add("value", itemsList);
            inputTag.Attributes.Add("onclick", onclick);
            inputTag.AddCssClass(cssClass);

            isChecked = checkear;

            if (isChecked)
                inputTag.Attributes.Add("checked", "checked");

            if (required)
            {
                inputTag.Attributes.Remove("onclick");
                inputTag.Attributes.Add("onclick", "customValidateRadio('" + id + "'); " + onclick);
                inputTag.AddCssClass("required");
            }

            string tagResult;

            using (var writer = new StringWriter())
            {
                inputTag.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                tagResult = writer.ToString();
            }

            sb.Append(tagResult + " " + itemsList + htmlSeparated);

            if (required)
            {
                sb.Append("</div>");
            }


            return new HtmlString(sb.ToString());
        }

        public static IHtmlContent RadioButtonList(this IHtmlHelper helper, string id, SelectList itemsList, bool required, string value, string htmlSeparated = " ", string onclick = "", string name = "", string cssClass = "")
        {
            StringBuilder sb = new StringBuilder();
            bool isChecked = false;
            string realName = "";

            htmlSeparated = string.IsNullOrEmpty(htmlSeparated) ? "&nbsp;&nbsp;" : htmlSeparated;

            if (required)
                sb.Append("<div id='divRadio" + id + "' class='form-control radio_obligatorio'>");

            foreach (var item in itemsList)
            {
                isChecked = false;
                if (value != "")
                {
                    if (value == item.Value.Trim())
                        isChecked = true;
                }

                realName = id;
                if (!string.IsNullOrEmpty(name))
                    realName = name;

                var inputTag = new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("input");
                inputTag.Attributes.Add("type", "radio");
                inputTag.Attributes.Add("id", id);
                inputTag.Attributes.Add("name", realName);
                inputTag.Attributes.Add("value", item.Value);
                inputTag.Attributes.Add("onclick", onclick);
                inputTag.AddCssClass(cssClass);


                if (isChecked)
                    inputTag.Attributes.Add("checked", "checked");


                if (required)
                {
                    inputTag.Attributes.Remove("onclick");
                    inputTag.Attributes.Add("onclick", "customValidateRadio('" + id + "'); " + onclick);
                    inputTag.AddCssClass("required");
                }



                string tagResult;

                using (var writer = new StringWriter())
                {
                    inputTag.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                    tagResult = writer.ToString();
                }

                sb.Append(item.Text + " " + tagResult + htmlSeparated);

            }

            if (required)
                sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

    }
}
