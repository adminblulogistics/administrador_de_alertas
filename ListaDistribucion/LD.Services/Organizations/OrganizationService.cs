using LD.Entities;
using LD.Entities.Dtos;
using LD.Entities.Enumerations;
using LD.EntitiesCotizador;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Auditoria;
using LD.Services.Interfaces.Contact;
using LD.Services.Interfaces.Organizations;
using LD.Services.Interfaces.Users;
using LD.Utilities;
using LD.Utilities.Email;
using LD.Utilities.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace LD.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepositoryOrganizationLD _repositoryOrganizationLD;
        private readonly IRepositoryCustomerCT _repositoryCustomerCT;
        private readonly IUserService _userService;
        private readonly IContactService _contactService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAlarmService _alarmService;
        private readonly IAuditoriaService _auditoriaService;
        public OrganizationService(IRepositoryOrganizationLD repositoryOrganizationLD, IRepositoryCustomerCT repositoryCustomerCT, IUserService userService, 
            IContactService contactService, IHostingEnvironment hostingEnvironment, IAlarmService alarmService, IAuditoriaService auditoriaService)
        {
            _repositoryOrganizationLD = repositoryOrganizationLD;
            _repositoryCustomerCT = repositoryCustomerCT;
            _userService = userService;
            _contactService = contactService;
            _hostingEnvironment = hostingEnvironment;
            _alarmService = alarmService;
            _auditoriaService = auditoriaService;
        }        

        public List<ORGANIZATIONDto> obtenerOrganizacionesPorUsuario(int iduserComercial, int iduserSaleSupport, int iduserEjecutivo, int idSession, bool? esAgente = null)
        {
            List<ORGANIZATIONDto> lstOrganization = new List<ORGANIZATIONDto>();
            List<USERDto> lstComerciales = new List<USERDto>();
            List<CUSTOMERS> lstOrganizationComerciales = new List<CUSTOMERS>();

            if (iduserComercial != 0)
            {
                var userCT = _userService.obtenerUsuarioCOTPorID(iduserComercial);
                lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComercial(userCT.ID_USER_SF, esAgente);
                var userComercial = _userService.obtenerUsuarioPorID(iduserComercial);
                if (userComercial != null)
                    lstComerciales.Add(userComercial);
            }
            if (iduserSaleSupport != 0)
            {
                lstComerciales = _userService.obtenerComercialesPorSaleSupport(iduserSaleSupport);
                if (lstComerciales.Any())
                {
                    var idsComercialesSF = lstComerciales.Select(s => s.ID_USER_SF).ToList();
                    lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComerciales(idsComercialesSF);
                }
            }
            if (iduserEjecutivo != 0)
            {
                var user = this.obtenerInfoAdicionalLDPorIDEjecutivo(iduserEjecutivo);
                if (user != null)
                {
                    var org = this.obtenerOrganizacionCustomerPorId(user.ID_ORGANIZATION_BODEGA);
                    lstOrganizationComerciales.Add(org);
                    var userComercial = _userService.obtenerUsuarioPorID(iduserEjecutivo);
                    if (userComercial != null)
                        lstComerciales.Add(userComercial);
                }
            }
            if (iduserComercial == 0 && iduserSaleSupport == 0 && iduserEjecutivo == 0)
            {
                var userGB = _userService.obtenerUsuarioPorID(idSession);

                var userCT = _userService.obtenerUsuarioCOTPorID(userGB.ID_USER);
                if (userCT != null && !string.IsNullOrEmpty(userCT.ID_USER_SF))
                    lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComercial(userCT.ID_USER_SF, esAgente);
                else
                {
                    lstComerciales = _userService.obtenerComercialesPorSaleSupport(idSession);
                    if (lstComerciales.Any())
                    {
                        var idsComercialesSF = lstComerciales.Select(s => s.ID_USER_SF).ToList();
                        lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComerciales(idsComercialesSF);
                    }
                }

            }

            foreach (var org in lstOrganizationComerciales)
            {
                string ejecutivo = string.Empty;
                List<string> lstSaleSupport = new List<string>();
                var infoAdicionalOrg = _repositoryOrganizationLD.obtenerInfoAdicionalLDPorID(org.ID_CUSTOMER);
                if (infoAdicionalOrg != null)
                {
                    if (infoAdicionalOrg.ID_SERVICE_CLIENT != null && infoAdicionalOrg.ID_SERVICE_CLIENT != 0)
                    {
                        var userEjecutivo = _userService.obtenerUsuarioGBPorId((int)infoAdicionalOrg.ID_SERVICE_CLIENT);
                        ejecutivo = userEjecutivo.use_name + " " + userEjecutivo.use_lastName;
                    }
                }
                var userGB = lstComerciales.Where(w => w.ID_USER_SF == org.ID_SALES_PERSON_SF).FirstOrDefault();
                if (userGB != null)
                {
                    var saleSupport = _userService.obtenerSaleSupportPorComercial(userGB.ID_USER);
                    if (saleSupport.Any())
                    {
                        foreach (var s in saleSupport)
                        {
                            lstSaleSupport.Add(s.FIRST_NAME + " " + s.LAST_NAME);
                        }
                    }
                }

                ORGANIZATIONDto organization = new ORGANIZATIONDto();
                organization.ID = org.ID_CUSTOMER;
                organization.NAME = org.NAME;
                organization.IDENTIFICACION = org.REG_NUMBER;
                organization.COMERCIAL = userGB != null ? userGB.FIRST_NAME + " " + userGB.LAST_NAME : "";
                organization.SALESUPPORT = lstSaleSupport;
                organization.EJECUTIVO = ejecutivo;
                lstOrganization.Add(organization);
            }

            return lstOrganization;
        }

        public bool validarExistenciaOrganizacion(long id)
        {
            return _repositoryCustomerCT.validarExistenciaOrganizacion(id);
        }

        public ORGANIZATIONDto obtenerOrganizacionPorId(long id)
        {
            ORGANIZATIONDto organization = new ORGANIZATIONDto();
            List<string> lstSaleSupport = new List<string>();
            CUSTOMERS customer = _repositoryCustomerCT.ObtenerOrganizacionPorId(id);
            
            if (customer != null)
            {
                int idComercial = 0;
                int idEjecutivo = 0;
                string nombreComercial = string.Empty;
                string nombreEjecutivo = string.Empty;
                var infoAdicionalOrg = _repositoryOrganizationLD.obtenerInfoAdicionalLDPorID(customer.ID_CUSTOMER);
                var userCT = _userService.obtenerUsuarioCOTPorSF(customer.ID_SALES_PERSON_SF);
                if (userCT != null)
                {
                    var userGB = _userService.obtenerUsuarioGBPorId(userCT.ID_USER);
                    idComercial = userGB.use_id;
                    nombreComercial = userGB.use_name + " " + userGB.use_lastName;

                    var saleSupport = _userService.obtenerSaleSupportPorComercial(userCT.ID_USER);
                    if (saleSupport.Any())
                    {
                        foreach (var s in saleSupport)
                        {
                            lstSaleSupport.Add(s.FIRST_NAME + " " + s.LAST_NAME);
                        }
                    }
                }
                if (infoAdicionalOrg != null)
                {
                    idEjecutivo = infoAdicionalOrg.ID_SERVICE_CLIENT!= null ? (int)infoAdicionalOrg.ID_SERVICE_CLIENT : 0;
                    var ejecutivo = _userService.obtenerUsuarioGBPorId(idEjecutivo);
                    if(ejecutivo!=null)
                        nombreEjecutivo = ejecutivo.use_name + " " + ejecutivo.use_lastName;
                }
                organization.ID = customer.ID_CUSTOMER;
                organization.NAME = customer.NAME;
                organization.IDENTIFICACION = customer.REG_NUMBER;
                organization.COMERCIAL = nombreComercial;
                organization.ID_COMERCIAL = idComercial;
                organization.SALESUPPORT = lstSaleSupport;
                organization.ID_EJECUTIVO = idEjecutivo;
                organization.EJECUTIVO = nombreEjecutivo;
            }

            return organization;
        }
        public ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorID(long id)
        {
            return _repositoryOrganizationLD.obtenerInfoAdicionalLDPorID(id);
        }

        public Respuesta insertarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd)
        {
            return _repositoryOrganizationLD.insertarInfoAdicionalLD(orgInfoAdd);
        }
        public Respuesta actualizarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd)
        {
            return _repositoryOrganizationLD.actualizarInfoAdicionalLD(orgInfoAdd);
        }

        public Respuesta saveContact(int idContacto, int idOrg, string nombre, string telefono, string email)
        {
            Respuesta respuesta = new Respuesta();
            CONTACTS contacto = new CONTACTS();

            contacto.ID_CONTACT = idContacto;
            contacto.ID_ORGANIZATION_BODEGA = idOrg;
            contacto.NAME_CONTACT = nombre;
            contacto.PHONE_CONTACT = telefono;
            contacto.EMAIL_CONTACT = email;

            var organizacion = this.obtenerInfoAdicionalLDPorID(contacto.ID_ORGANIZATION_BODEGA);
            if (organizacion == null)
            {
                ORGANIZATIONDto org = this.obtenerOrganizacionPorId(contacto.ID_ORGANIZATION_BODEGA);
                ADDITIONAL_ORGANIZATION_INFORMATION orgAddNew = new ADDITIONAL_ORGANIZATION_INFORMATION();
                orgAddNew.ID_ORGANIZATION_BODEGA = org.ID;
                orgAddNew.ID_SERVICE_CLIENT = org.ID_EJECUTIVO;
                this.insertarInfoAdicionalLD(orgAddNew);
            }

            if (contacto.ID_CONTACT == 0)
            {
                respuesta = _contactService.validarContactoExistente(contacto);
                if (!respuesta.ProcesoExitoso)
                {
                    respuesta = _contactService.insertarContacto(contacto);
                    _auditoriaService.insertarAuditoria(new ACTIVITY_LOG { ID_CLIENT = idOrg, OPERATION = "Inserta Contacto", OLD_VALUE = "", NEW_VALUE = contacto.NAME_CONTACT + Environment.NewLine + contacto.EMAIL_CONTACT + Environment.NewLine + contacto.PHONE_CONTACT });
                }
            }
            else
            {
                var contactOld  = _contactService.ObtenerContactoPorId(contacto.ID_CONTACT);
                _auditoriaService.insertarAuditoria(new ACTIVITY_LOG { ID_CLIENT = idOrg, OPERATION = "Actualiza Contacto", OLD_VALUE = contactOld.NAME_CONTACT + Environment.NewLine  + contactOld.EMAIL_CONTACT + Environment.NewLine + contactOld.PHONE_CONTACT , NEW_VALUE = contacto.NAME_CONTACT + Environment.NewLine + contacto.EMAIL_CONTACT + Environment.NewLine + contacto.PHONE_CONTACT });
                respuesta = _contactService.actualizarContacto(contacto);
                
            }          

            return respuesta;
        }
        public Respuesta saveOrganization(int idOrganization, int idEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            ADDITIONAL_ORGANIZATION_INFORMATION orgAddNew = new ADDITIONAL_ORGANIZATION_INFORMATION();

            var organizacion = this.obtenerInfoAdicionalLDPorID(idOrganization);
            if (organizacion == null)
            {                
                orgAddNew.ID_ORGANIZATION_BODEGA = idOrganization;
                orgAddNew.ID_SERVICE_CLIENT = idEjecutivo;
                _auditoriaService.insertarAuditoria(new ACTIVITY_LOG { ID_CLIENT = idOrganization, OPERATION = "Asigna Ejecutivo", OLD_VALUE = "", NEW_VALUE = orgAddNew.ID_SERVICE_CLIENT.ToString() });
                this.insertarInfoAdicionalLD(orgAddNew);
            }
            else
            {
                orgAddNew.ID_ORGANIZATION_BODEGA = organizacion.ID_ORGANIZATION_BODEGA;
                orgAddNew.ID_SERVICE_CLIENT = idEjecutivo;
                _auditoriaService.insertarAuditoria(new ACTIVITY_LOG { ID_CLIENT = idOrganization, OPERATION = "Actializa Ejecutivo", OLD_VALUE = orgAddNew.ID_SERVICE_CLIENT.ToString(), NEW_VALUE = orgAddNew.ID_SERVICE_CLIENT.ToString()});
                this.actualizarInfoAdicionalLD(orgAddNew);
            }

            return respuesta;
        }
        public ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorIDEjecutivo(int id)
        {
            return _repositoryOrganizationLD.obtenerInfoAdicionalLDPorIDEjecutivo(id);
        }
        public CUSTOMERS obtenerOrganizacionCustomerPorId(long id)
        {
            return _repositoryCustomerCT.ObtenerOrganizacionPorId(id);
        }
        public List<ORGANIZATIONDto> obtenerOrganizacionesPorSaleSupport(ADDITIONAL_USER_INFORMATION user, bool? esAgente = null)
        {
            throw new NotImplementedException();
        }
        public Respuesta ValidarExcelMasivo(IFormFile archivo)
        {
            string ruta = "";
            int contProcesardos = 0;
            int AuxFilas = 0;
            List<string> erroresTotal = new List<string>();

            Respuesta resp = new Respuesta();
            resp.ObjetoRespuesta = erroresTotal;            
            
            try
            {
                string nombreArchivoFinal = "f_" + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + "_" + new FileInfo(archivo.FileName).Name;
                nombreArchivoFinal = Regex.Replace(nombreArchivoFinal, @"[^a-zA-z0-9. ]+", "");
                nombreArchivoFinal = Regex.Replace(nombreArchivoFinal, @"\s+", "");

                var contentRootPath = _hostingEnvironment.WebRootPath;
                ruta = Path.Combine(contentRootPath, @"./documents/CargueMasivo/", nombreArchivoFinal);

                FileInfo fi1 = new FileInfo(ruta);

                using (FileStream fs = fi1.Create())
                {
                    archivo.CopyTo(fs);
                }

                var datosExcel = ExcelUtil.cargaValoresExcelHoja(ruta, "Hoja1");
                int numFilas = datosExcel.Count() - 1; // Se resta la fila de encabezado
                AuxFilas = numFilas;
                if (numFilas > 0)
                {
                    var respuesta = ExcelUtil.convertDataExcel(datosExcel);
                    if (respuesta.ProcesoExitoso)
                    {
                        var lstregistros = (List<ExcelDto>)respuesta.ObjetoRespuesta;

                        foreach (var fila in lstregistros)
                        {
                            List<string> errores = new List<string>();

                            bool boolidOrg = long.TryParse(fila.ID_ORGANIZATION, out long idOrg);
                            bool boolidEjec = int.TryParse(fila.ID_EJECUTIVO, out int idEjec);
                            //Valida organizacion
                            if (string.IsNullOrEmpty(fila.ID_ORGANIZATION))
                                errores.Add($"Fila número {fila.REGISTRO_NUMBER} el Id Cliente no puede estar vacío.");
                            if (boolidOrg)
                            {
                                var orgExit = this.validarExistenciaOrganizacion(idOrg);
                                if (!orgExit)
                                    errores.Add($"Fila número {fila.REGISTRO_NUMBER} el Cliente no existe.");
                            }
                            else
                                errores.Add($"Fila número {fila.REGISTRO_NUMBER} el Id Cliente debe ser un número entero.");

                            //Valida Ejecutivo de cuenta
                            if (!string.IsNullOrEmpty(fila.ID_EJECUTIVO))
                                {
                                if (boolidEjec)
                                {
                                    var roles = _userService.obtenerRolesPorUsuario(idEjec).Select(s => s.rol_name == nameof(Enumeraciones.PerfilesModulo.AA_Ejecutivo_de_cuenta));
                                    if (!roles.Any())
                                        errores.Add($"Fila número {fila.REGISTRO_NUMBER} el Id no pertenece a un Ejecutivo de cuentas.");
                                }
                                else
                                    errores.Add($"Fila número {fila.REGISTRO_NUMBER} el Id Ejecutivo de cuentas debe ser un número entero.");
                            }

                            //Valida Contacto e Email
                            if (string.IsNullOrEmpty(fila.NAME_CONTACT) && !string.IsNullOrEmpty(fila.EMAIL_CONTACT))
                                errores.Add($"Fila número {fila.REGISTRO_NUMBER} no puede estar vacio el Nombre del contacto si el Email esta diligenciado.");
                            else if (string.IsNullOrEmpty(fila.EMAIL_CONTACT) && !string.IsNullOrEmpty(fila.NAME_CONTACT))
                                errores.Add($"Fila número {fila.REGISTRO_NUMBER} no puede estar vacio el Email del contacto si el Nombre esta diligenciado.");
                            else
                            {
                                bool validEmail = false;
                                if (!string.IsNullOrEmpty(fila.EMAIL_CONTACT))
                                {
                                    validEmail = EmailUtilities.ComprobarFormatoEmail(fila.EMAIL_CONTACT);
                                    if (!validEmail)
                                        errores.Add($"Fila número {fila.REGISTRO_NUMBER} el Email no tiene un formato valido.");
                                }
                                //if (boolidOrg && validEmail)
                                //{
                                //    var contactoExiste = _contactService.validarContactoExistente(new CONTACTS { EMAIL_CONTACT = fila.EMAIL_CONTACT, ID_ORGANIZATION_BODEGA = idOrg });
                                //    if (contactoExiste.ProcesoExitoso)
                                //        errores.Add($"Fila número {fila.REGISTRO_NUMBER} {contactoExiste.MensajeRespuesta}");
                                //}
                            }
                            //Valida alarmas
                            if (!string.IsNullOrEmpty(fila.ALARMS))
                            {
                                var alarmSplit = fila.ALARMS.Split('-');
                                foreach (var al in alarmSplit)
                                {
                                    bool boolidAlarma = int.TryParse(al, out int idAlarma);
                                    if (boolidAlarma)
                                    {
                                        var alarma = _alarmService.obtenerAlarmaPorId(idAlarma);
                                        if (alarma == null)
                                            errores.Add($"Fila número {fila.REGISTRO_NUMBER} la alarma con Id {al} no existe.");
                                    }
                                }                                
                            }
                            if (errores.Any())
                            {
                                foreach (var error in errores)
                                    erroresTotal.Add(error);
                            }
                        }

                        if (!erroresTotal.Any())
                        {
                            foreach (var elim in lstregistros)
                            {
                                respuesta = _alarmService.eliminarAlarmasPorOrganizacionContacto(Convert.ToInt32(elim.ID_ORGANIZATION));
                                if (respuesta.ProcesoExitoso)
                                {
                                    respuesta = _contactService.eliminarContactosPorOrganizacion(Convert.ToInt32(elim.ID_ORGANIZATION));
                                }
                            }
                            foreach (var regis in lstregistros)
                            {                                                             
                                var procesar = this.ProcesarExcelMasivo(regis);
                                contProcesardos++;                                
                                if (!procesar.ProcesoExitoso)
                                    erroresTotal.Add($"Fila número {regis.REGISTRO_NUMBER} error al insertar registro: {procesar.MensajeRespuesta}");
                            }
                        }                        
                        resp.ProcesoExitoso = true;
                    }
                    else
                        erroresTotal.Add($"Ocurrio un error al convertir los datos del archivo: {respuesta.MensajeRespuesta}");
                }
                else
                {
                    erroresTotal.Add("Al parecer el archivo está vacio. Valide que el nombre de la hoja sea 'Hoja1'");
                }
            }
            catch (Exception ex)
            {
                erroresTotal.Add($"Ocurrio el siguiente error: {ex.Message}");               
                
            }
            int conError = AuxFilas - contProcesardos;
            resp.MensajeRespuesta = $"Total de registros: {AuxFilas}, Procesados: {contProcesardos}, Con Error: {conError} ";
            resp.ObjetoRespuesta = erroresTotal;
            return resp;
        }
        internal Respuesta ProcesarExcelMasivo(ExcelDto resgistroProcesar)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                int idOrg = Convert.ToInt32(resgistroProcesar.ID_ORGANIZATION);
                int idContantoNew = 0;
                if (!string.IsNullOrEmpty(resgistroProcesar.NAME_CONTACT) && !string.IsNullOrEmpty(resgistroProcesar.EMAIL_CONTACT))
                    respuesta = this.saveContact(idContantoNew, idOrg, resgistroProcesar.NAME_CONTACT, resgistroProcesar.PHONE_CONTACT, resgistroProcesar.EMAIL_CONTACT);
                    
                if (!string.IsNullOrEmpty(resgistroProcesar.ALARMS))
                {
                    var alarmSplit = resgistroProcesar.ALARMS.Split('-');
                    foreach (var al in alarmSplit)
                    {
                        int idAlarma = Convert.ToInt32(al);
                        var alarma = _alarmService.obtenerAlarmaPorId(idAlarma);
                        CONTACT_ALARMS contactAlarmaNew = new CONTACT_ALARMS();
                        contactAlarmaNew.ID_ORGANIZATION = idOrg;
                        contactAlarmaNew.ID_CONTACT = Convert.ToInt32(respuesta.Id);
                        contactAlarmaNew.EVENTCODE = alarma.EVENTCODE;
                        if (alarma.SHOW_CALENDAR)
                        {
                            contactAlarmaNew.LUNES = string.IsNullOrEmpty(resgistroProcesar.LUNES) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.LUNES);
                            contactAlarmaNew.MARTES = string.IsNullOrEmpty(resgistroProcesar.MARTES) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.MARTES);
                            contactAlarmaNew.MIERCOLES = string.IsNullOrEmpty(resgistroProcesar.MIERCOLES) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.MIERCOLES);
                            contactAlarmaNew.JUEVES = string.IsNullOrEmpty(resgistroProcesar.JUEVES) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.JUEVES);
                            contactAlarmaNew.VIERNES = string.IsNullOrEmpty(resgistroProcesar.VIERNES) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.VIERNES);
                            contactAlarmaNew.SABADO = string.IsNullOrEmpty(resgistroProcesar.SABADO) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.SABADO);
                            contactAlarmaNew.DOMINGO = string.IsNullOrEmpty(resgistroProcesar.DOMINGO) ? false : GeneralUtilities.ConvertBoolean(resgistroProcesar.DOMINGO);
                        }
                        else
                        {
                            contactAlarmaNew.LUNES = false;
                            contactAlarmaNew.MARTES = false;
                            contactAlarmaNew.MIERCOLES = false;
                            contactAlarmaNew.JUEVES = false;
                            contactAlarmaNew.VIERNES = false;
                            contactAlarmaNew.SABADO = false;
                            contactAlarmaNew.DOMINGO = false;
                        }
                        var guardarContactoAlarma = _alarmService.insertAlarmaContacto(contactAlarmaNew);
                    }
                }

                if (!string.IsNullOrEmpty(resgistroProcesar.ID_EJECUTIVO) && respuesta.ProcesoExitoso)
                {
                    int idEjecutivo = Convert.ToInt32(resgistroProcesar.ID_EJECUTIVO);
                    respuesta = this.saveOrganization(idOrg, idEjecutivo);
                }   

                respuesta.ProcesoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ProcesoExitoso = false;
                respuesta.MensajeRespuesta = ex.Message;
            }            
            return respuesta;
        }

        public CUSTOMERS obtenerOrganizacionCustomerPorCodeCW(string codeCW)
        {
            return _repositoryCustomerCT.obtenerOrganizacionCustomerPorCodeCW(codeCW);
        }

        public List<ACTIVITY_LOG> obtenerLogsPorIdOrganizacion(long id)
        {
            return _auditoriaService.obtenerAuditoriaPorOrganizacion(id);
        }
    }
}
