using LD.Entities;
using LD.Entities.Dtos;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Utilities.Excel
{
    public static class ExcelUtil
    {
        public static List<RowNoHeader> cargaValoresExcelRangos(string pathFicheroExcel, string celdaOrigen, string celdaDestino, string Hoja)
        {

            var excel = new ExcelQueryFactory(pathFicheroExcel);

            var dataExcel = (from c in excel.WorksheetRangeNoHeader(celdaOrigen, celdaDestino, Hoja)
                             select c).ToList();
            return dataExcel;
        }

        public static List<RowNoHeader> cargaValoresExcelHoja(string pathFicheroExcel, string Hoja)
        {
            var dataExcel = new List<RowNoHeader>();

            var error = "";

            try
            {
                using (var excel = new ExcelQueryFactory(pathFicheroExcel))
                {
                    dataExcel = (from c in excel.WorksheetNoHeader(Hoja)
                                 select c).ToList();
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return dataExcel;
        }
        public static Respuesta  convertDataExcel(List<RowNoHeader> dataExcel)
        {
            Respuesta respuesta = new Respuesta();
            List<ExcelDto> lstRegistros = new List<ExcelDto>();
            try
            {
                dataExcel.RemoveAt(0); // Se quita el encabezado

                int cont = 2;

                foreach (var fila in dataExcel)
                {
                    ExcelDto registro = new ExcelDto();
                    registro.REGISTRO_NUMBER = cont;
                    registro.ID_ORGANIZATION = fila[0].Cast<string>();
                    registro.NAME_CONTACT = fila[1].Cast<string>();
                    registro.EMAIL_CONTACT = fila[2].Cast<string>();
                    registro.PHONE_CONTACT = fila[3].Cast<string>();
                    registro.ID_EJECUTIVO = fila[4].Cast<string>();
                    registro.ALARMS = fila[5].Cast<string>();
                    registro.LUNES = fila[6].Cast<string>();
                    registro.MARTES = fila[7].Cast<string>();
                    registro.MIERCOLES = fila[8].Cast<string>();
                    registro.JUEVES = fila[9].Cast<string>();
                    registro.VIERNES = fila[10].Cast<string>();
                    registro.SABADO = fila[11].Cast<string>();
                    registro.DOMINGO = fila[12].Cast<string>();
                    lstRegistros.Add(registro);
                    cont++;
                }
                if (lstRegistros.Any())
                {
                    respuesta.ProcesoExitoso = true;
                    respuesta.ObjetoRespuesta = lstRegistros;
                }
            }
            catch(Exception e)
            {
                respuesta.ProcesoExitoso = false;
                respuesta.MensajeRespuesta = e.Message;
            }
            
            return respuesta;
        }

    }
}
