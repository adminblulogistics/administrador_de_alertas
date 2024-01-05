using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Entities.Enumerations
{
    public class Enumeraciones
    {
        public enum Pais
        {
            Colombia = 1,
            Ecuador = 2,
            Mexico = 3
        }
        public enum ErroresLogin
        {
            tokenInvalido = 1,
            sesionNula = 2,
            usuarioNoImportado = 3,
            excepcionSistema = 4,
            sessionExpira = 5,
            usuarioSinRol = 6,
        }
        public enum PerfilesModulo
        {
            AA_Ejecutivo_de_cuenta = 182,
            AA_Comercial = 183,
            AA_Sales_Support = 184,
            AA_Lider_Operaciones = 185,
            AA_Administración = 186,
            AA_Supervisor = 187,
            Comercial = 144,
            SaleSupport = 147,
        }
        public enum TransportMode
        {
            Sea = 1,
            Air = 2,
            Road = 3,
            Raid = 4,
            Fluvial = 5,
        }
        public enum ModuleTransport
        {
            IMP = 1,
            OCE = 2,
            AIR = 3,
            IMPA = 4,
        }
        public enum WayBillType
        {
            MWB = 1,
        }
        public enum PortLocation
        {
            ArrivalCTOAddress = 1,
        }
        public enum SendersLocalClient
        {
            SendersLocalClient = 1,
            SendersOverseasAgent = 2,
            ConsigneeDocumentaryAddress = 3,
            ConsignorDocumentaryAddress = 4,
            ArrivalCFSAddress = 5,
            NotifyParty = 6,
        }
        public enum PaisAbreviado
        {
            CO = 1,
            EC = 2,
            MX = 3
        }
        public enum PaisAbreviado3Letras
        {
            COL = 1,
            ECU = 2,
            MEX = 3
        }
        public enum Dias
        {
            Lunes =1,
            Martes = 2,
            Miercoles = 3,
            Jueves = 4,
            Viernes = 5,
            Sabado = 6,
            Domingo = 7
        }
        public enum ShipmentType
        {
            ASM = 1,
            STD = 2,
        }
        public enum BillIssued
        {
            ShippedOnBoard = 1,
            BillIssued = 2,
            Departure = 3,
        }
        public enum Alarmas
        {
            ETAPOD = 1,
            ONBOARD = 2
        }
        public enum Modulos
        {
            IMPO = 1,
            EXPO = 2,
            STATUS = 3,
        }
        public enum STATUS_SEND
        {
            OK =1,
            ERR =2,
        }
    }
}
