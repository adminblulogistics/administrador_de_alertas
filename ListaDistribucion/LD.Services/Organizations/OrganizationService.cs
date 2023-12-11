using LD.Entities;
using LD.Entities.Dtos;
using LD.Entities.Enumerations;
using LD.EntitiesCotizador;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Contact;
using LD.Services.Interfaces.Organizations;
using LD.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepositoryOrganizationLD _repositoryOrganizationLD;
        private readonly IRepositoryCustomerCT _repositoryCustomerCT;
        private readonly IUserService _userService;
        private readonly IContactService _contactService;
        public OrganizationService(IRepositoryOrganizationLD repositoryOrganizationLD, IRepositoryCustomerCT repositoryCustomerCT, IUserService userService, IContactService contactService)
        {
            _repositoryOrganizationLD = repositoryOrganizationLD;
            _repositoryCustomerCT = repositoryCustomerCT;
            _userService = userService;
            _contactService = contactService;
        }

        public List<ORGANIZATIONDto> obtenerOrganizacionesPorUsuario(ADDITIONAL_USER_INFORMATION user, string rol, bool? esAgente = null)
        {
            List<ORGANIZATIONDto> lstOrganization = new List<ORGANIZATIONDto>();
            List<USERDto> lstComerciales = new List<USERDto>();
            List<CUSTOMERS> lstOrganizationComerciales = new List<CUSTOMERS>();


            if (rol == nameof(Enumeraciones.PerfilesModulo.AA_Comercial).Replace("_", ""))
            {
                lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComercial(user.ID_USER_SF, esAgente);
                var userComercial = _userService.obtenerUsuarioPorID(user.ID_USER_BLU); 
                if(userComercial!=null)
                    lstComerciales.Add(userComercial);
            }
            else if (rol == nameof(Enumeraciones.PerfilesModulo.AA_Sales_Support).Replace("_", ""))
            {
                lstComerciales = _userService.obtenerComercialesPorSaleSupport(user.ID_USER_BLU);
                var idsComercialesSF = lstComerciales.Select(s => s.ID_USER_SF).ToList();
                lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComerciales(idsComercialesSF);
            }
            else if (rol == nameof(Enumeraciones.PerfilesModulo.AA_Ejecutivo_de_cuenta).Replace("_", ""))
            {
            }
            else 
            {
                lstOrganizationComerciales = _repositoryCustomerCT.ObtenerOrganizacionesPorComercial(user.ID_USER_SF, esAgente);
                var userComercial = _userService.obtenerUsuarioPorID(user.ID_USER_BLU);
                if (userComercial != null)
                    lstComerciales.Add(userComercial);
            }

            foreach (var org in lstOrganizationComerciales)
            {
                string ejecutivo = string.Empty;
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

                ORGANIZATIONDto organization = new ORGANIZATIONDto();
                organization.ID = org.ID_CUSTOMER;
                organization.NAME = org.NAME;
                organization.IDENTIFICACION = org.REG_NUMBER;
                organization.COMERCIAL = userGB!=null? userGB.FIRST_NAME + " " + userGB.LAST_NAME:"";
                //organization.SALESUPPORT =
                organization.EJECUTIVO = ejecutivo;
                lstOrganization.Add(organization);
            }
            return lstOrganization;
        }
        public ORGANIZATIONDto obtenerOrganizacionPorId(long id)
        {
            ORGANIZATIONDto organization = new ORGANIZATIONDto();
            CUSTOMERS customer = _repositoryCustomerCT.ObtenerOrganizacionPorId(id);
            
            if (customer != null)
            {
                int idComercial = 0;
                int idEjecutivo = 0;
                string comercial = string.Empty;
                var infoAdicionalOrg = _repositoryOrganizationLD.obtenerInfoAdicionalLDPorID(customer.ID_CUSTOMER);
                var userLD = _userService.obtenerUsuarioLDPorAlisasSF(customer.ID_SALES_PERSON_SF);
                if (userLD != null)
                {
                    var userGB = _userService.obtenerUsuarioGBPorId(userLD.ID_USER_BLU);
                    idComercial = userGB.use_id;
                    comercial = userGB.use_name + " " + userGB.use_lastName;
                }
                if (infoAdicionalOrg != null)
                {
                    idEjecutivo = infoAdicionalOrg.ID_SERVICE_CLIENT!= null ? (int)infoAdicionalOrg.ID_SERVICE_CLIENT : 0;
                }
                organization.ID = customer.ID_CUSTOMER;
                organization.NAME = customer.NAME;
                organization.IDENTIFICACION = customer.REG_NUMBER;
                organization.COMERCIAL = comercial;
                organization.ID_COMERCIAL = idComercial;
                //organization.SALESUPPORT =
                organization.ID_EJECUTIVO = idEjecutivo;

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
                respuesta = _contactService.insertarContacto(contacto);
            else
                respuesta = _contactService.actualizarContacto(contacto);

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
                this.insertarInfoAdicionalLD(orgAddNew);
            }
            else
            {
                orgAddNew.ID_SERVICE_CLIENT = idEjecutivo;
                this.actualizarInfoAdicionalLD(orgAddNew);
            }

            return respuesta;
        }

        public List<ORGANIZATIONDto> obtenerOrganizacionesPorSaleSupport(ADDITIONAL_USER_INFORMATION user, bool? esAgente = null)
        {
            throw new NotImplementedException();
        }
    }
}
