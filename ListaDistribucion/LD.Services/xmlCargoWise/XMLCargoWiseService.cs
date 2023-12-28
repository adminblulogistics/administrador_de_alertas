using LD.Entities.Enumerations;
using LD.Entities.xmlCargoWise;
using LD.Services.Interfaces.xmlCargoWise;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.xmlCargoWise
{
    public class XMLCargoWiseService: IXMLCargoWiseService
    {
        public Consol ConvertInfoConsol(UniversalInterchange InfoConsol, string paisCompania)
        {
            Consol consol = new Consol();
            try
            {
                if (InfoConsol.Body.UniversalShipment != null)
                {
                    consol.NroConsol = InfoConsol.Body.UniversalShipment.Shipment.DataContext.DataSourceCollection.DataSource.FirstOrDefault().Key;
                    consol.TransportMode = InfoConsol.Body.UniversalShipment.Shipment.TransportMode != null ? InfoConsol.Body.UniversalShipment.Shipment.TransportMode : new TransportMode();
                    consol.TransportLeg = ObtenerTransportLeg(InfoConsol.Body.UniversalShipment.Shipment.TransportLegCollection);
                    consol.Module = ObtenerModulo(InfoConsol.Body.UniversalShipment.Shipment.TransportLegCollection, paisCompania, InfoConsol.Body.UniversalShipment.Shipment.TransportMode);
                    consol.ETD = ObtenerEstimatedDeparture(InfoConsol.Body.UniversalShipment.Shipment.TransportLegCollection);
                    consol.CambioETA = ObtenerCustomizedFieldCambioETA(InfoConsol.Body.UniversalShipment.Shipment.CustomizedFieldCollection);
                    consol.ETA = ObtenerEstimatedArrival(InfoConsol.Body.UniversalShipment.Shipment.TransportLegCollection);
                    consol.ATA = ObtenerActualArrival(InfoConsol.Body.UniversalShipment.Shipment.TransportLegCollection);
                    consol.ATD = ObtenerActualDeparture(InfoConsol.Body.UniversalShipment.Shipment.TransportLegCollection);
                    consol.Master = ObtenerWayBillNumber(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.Voyage = ObtenerVoyageFlightNo(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.Vessel = ObtenerVesselName(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.ShipmentType = ObtenerShipmentType(InfoConsol.Body.UniversalShipment.Shipment).Code;
                    consol.ETAInicialCOIO = ObtenerCustomizedFieldETA(InfoConsol.Body.UniversalShipment.Shipment.CustomizedFieldCollection);
                    consol.ServiceLevel = ObtenerAWBServiceLevel(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.PortLocation = ObtenerPortLocation(InfoConsol.Body.UniversalShipment.Shipment.OrganizationAddressCollection);
                    consol.Shipments = ObtenerShipments(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.PlaceOfReceipt = ObtenerPlaceOfReceipt(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.ContainerMode = InfoConsol.Body.UniversalShipment.Shipment.ContainerMode.Code;
                    consol.DeliveryMode = ObtenerDeliveryMode(InfoConsol.Body.UniversalShipment.Shipment);
                    consol.TotalWeight = InfoConsol.Body.UniversalShipment.Shipment.TotalWeight;
                    consol.TotalWeightUnit = InfoConsol.Body.UniversalShipment.Shipment.TotalWeightUnit.Code;
                    consol.TotalVolume = InfoConsol.Body.UniversalShipment.Shipment.TotalVolume;
                    consol.TotalVolumeUnit = InfoConsol.Body.UniversalShipment.Shipment.TotalVolumeUnit.Code;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message; 
            }
            
            return consol;
        }
        #region module
        private string ObtenerModulo(TransportLegCollection transportLegCollection, string paisCompania, TransportMode transportMode)
        {
            string module = string.Empty;
            string pais = (paisCompania == nameof(Enumeraciones.Pais.Colombia).Substring(0, 3).ToUpper() ? nameof(Enumeraciones.PaisAbreviado.CO) :
                          (paisCompania == nameof(Enumeraciones.Pais.Mexico).Substring(0, 3).ToUpper() ? nameof(Enumeraciones.PaisAbreviado.MX) :
                          (paisCompania == nameof(Enumeraciones.Pais.Ecuador).Substring(0, 3).ToUpper() ? nameof(Enumeraciones.PaisAbreviado.EC) : "")));

            if (transportLegCollection != null && transportLegCollection.TransportLeg.Count > 0)
            {
                foreach (var transportLeg in transportLegCollection.TransportLeg)
                {
                    if (transportLeg.PortOfLoading != null)
                    {
                        if (transportLeg.PortOfLoading.Code.Substring(0, 2) != pais && transportMode.Code == nameof(Enumeraciones.TransportMode.Sea).ToUpper())
                        {
                            module = nameof(Enumeraciones.ModuleTransport.IMP);
                        }
                        if (transportLeg.PortOfLoading.Code.Substring(0, 2) == pais && transportMode.Code == nameof(Enumeraciones.TransportMode.Sea).ToUpper())
                        {
                            module = nameof(Enumeraciones.ModuleTransport.OCE);
                        }
                        if (transportLeg.PortOfLoading.Code.Substring(0, 2) != pais && transportMode.Code == nameof(Enumeraciones.TransportMode.Air).ToUpper())
                        {
                            module = nameof(Enumeraciones.ModuleTransport.IMPA);
                        }
                        if (transportLeg.PortOfLoading.Code.Substring(0, 2) == pais && transportMode.Code == nameof(Enumeraciones.TransportMode.Air).ToUpper())
                        {
                            module = nameof(Enumeraciones.ModuleTransport.IMP);
                        }
                    }
                }
            }
            return module;
        }
        #endregion
        #region DeliveryMode
        /// <summary>
        /// Obtiene el DeliveryMode
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public string ObtenerDeliveryMode(Shipment shipment)
        {
            string deliveryMode = string.Empty;
            if (shipment.CustomizedFieldCollection != null && shipment.CustomizedFieldCollection.CustomizedField.Count() > 0)
            {
                foreach (var customizedField in shipment.CustomizedFieldCollection.CustomizedField)
                {
                    if (customizedField.Key == "Delivery Type" && !string.IsNullOrEmpty(customizedField.Value))
                        deliveryMode = customizedField.Value.Replace("CY", "FCL").Replace("CFS", "LCL");
                }
            }
            return deliveryMode;
        }
        #endregion
        #region Estimated Departure
        private string ObtenerEstimatedDeparture(TransportLegCollection transportLegCollection)
        {
            string estimatedDeparture = string.Empty;

            if (transportLegCollection != null && transportLegCollection.TransportLeg.Count > 0)
            {
                foreach (var transportLeg in transportLegCollection.TransportLeg)
                {
                    if (string.IsNullOrEmpty(estimatedDeparture))
                    {
                        estimatedDeparture = transportLeg.EstimatedDeparture.Substring(0, 10);
                        break;
                    }
                }
            }
            return estimatedDeparture;
        }
        #endregion
        #region Estimated Arrival
        private string ObtenerEstimatedArrival(TransportLegCollection transportLegCollection)
        {
            string estimatedArrival = string.Empty;

            if (transportLegCollection != null && transportLegCollection.TransportLeg.Count > 0)
            {
                foreach (var transportLeg in transportLegCollection.TransportLeg)
                {
                    if (!string.IsNullOrEmpty(transportLeg.EstimatedArrival))
                    {
                        estimatedArrival = transportLeg.EstimatedArrival.Substring(0, 10);
                        break;
                    }
                }
            }
            return estimatedArrival;
        }
        #endregion
        #region Actual Arrival
        private string ObtenerActualArrival(TransportLegCollection transportLegCollection)
        {
            string actualArrival = string.Empty;

            if (transportLegCollection != null && transportLegCollection.TransportLeg.Count > 0)
            {
                foreach (var transportLeg in transportLegCollection.TransportLeg)
                {
                    if (!string.IsNullOrEmpty(transportLeg.ActualArrival))
                    {
                        actualArrival = transportLeg.ActualArrival.Substring(0, 10);
                        break;
                    }
                }
            }
            return actualArrival;
        }
        #endregion
        #region Actual Departure
        private string ObtenerActualDeparture(TransportLegCollection transportLegCollection)
        {
            string actualDeparture = string.Empty;

            if (transportLegCollection != null && transportLegCollection.TransportLeg.Count > 0)
            {
                foreach (var transportLeg in transportLegCollection.TransportLeg)
                {
                    if (!string.IsNullOrEmpty(transportLeg.ActualDeparture))
                    {
                        actualDeparture = transportLeg.ActualDeparture.Substring(0, 10);
                        break;
                    }
                }
            }
            return actualDeparture;
        }
        #endregion
        #region WayBillNumber
        private string ObtenerWayBillNumber(Shipment shipment)
        {
            string wayBillNumber = string.Empty;
            if (shipment.WayBillType != null && shipment.WayBillType.Code == Enum.GetName(typeof(Enumeraciones.WayBillType), Enumeraciones.WayBillType.MWB))
            {
                wayBillNumber = shipment.WayBillNumber;
            }
            return wayBillNumber;
        }
        #endregion
        #region Voyage FlightNo
        private string ObtenerVoyageFlightNo(Shipment shipment)
        {
            string voyageFlightNo = string.Empty;
            if (!string.IsNullOrEmpty(shipment.VoyageFlightNo))
            {
                voyageFlightNo = shipment.VoyageFlightNo;
            }
            return voyageFlightNo;
        }
        #endregion
        #region Vessel Name
        private string ObtenerVesselName(Shipment shipment)
        {
            string vesselName = string.Empty;
            if (!string.IsNullOrEmpty(shipment.VesselName))
            {
                vesselName = shipment.VesselName;
            }
            return vesselName;
        }
        #endregion
        #region ShipmentType
        private ShipmentType ObtenerShipmentType(Shipment shipment)
        {
            ShipmentType shipmentType = new ShipmentType();
            if (shipment.ShipmentType != null)
            {
                shipmentType.Code = shipment.ShipmentType.Code;
                shipmentType.Description = shipment.ShipmentType.Description;
            }
            return shipmentType;
        }
        private ShipmentType ObtenerShipmentTypeSubshipment(SubShipment subShipment)
        {
            ShipmentType shipmentType = new ShipmentType();
            if (subShipment.ShipmentType != null)
            {
                shipmentType.Code = subShipment.ShipmentType.Code;
                shipmentType.Description = subShipment.ShipmentType.Description;
            }
            return shipmentType;
        }
        #endregion
        #region CustomizedField ETA Inicial CO IO
        private string ObtenerCustomizedFieldETA(CustomizedFieldCollection customizedFieldCollection)
        {
            string fieldETAInicial = string.Empty;
            if (customizedFieldCollection != null && customizedFieldCollection.CustomizedField.Count>0)
            {
                foreach (var custom in customizedFieldCollection.CustomizedField)
                {
                    if(custom.Key == "ETA Inicial CO IO")
                        fieldETAInicial = custom.Value.Substring(0,10);
                }
            }
            return fieldETAInicial;
        }
        #endregion
        #region CustomizedField Cambio ETA
        private string ObtenerCustomizedFieldCambioETA(CustomizedFieldCollection customizedFieldCollection)
        {
            string cambioEta = string.Empty;
            if (customizedFieldCollection != null && customizedFieldCollection.CustomizedField.Count > 0)
            {
                foreach (var custom in customizedFieldCollection.CustomizedField)
                {
                    if (custom.Key == "Motivo Cambio ETA - Mex" || custom.Key == "D- Motivo Cambio ETA" || custom.Key == "Motivo Cambio ETA EC IM"
                        || custom.Key == "Motivo Cambio ETA EC IO" || custom.Key == "ETA Inicial CO IO")
                        cambioEta = custom.Value;
                }
            }
            return cambioEta;
        }
        #endregion
        #region AWBServiceLevel
        private string ObtenerAWBServiceLevel(Shipment shipment)
        {
            string awbServiceLevel = string.Empty;
            if (shipment.AWBServiceLevel != null)
            {
                awbServiceLevel = shipment.AWBServiceLevel.Code;
            }
            return awbServiceLevel;
        }
        #endregion
        //#region OrganizationAddress
        ////private string ObtenerOrganizationAddress(OrganizationAddressCollection organizationAddressCollection)
        ////{
        ////    string organizationAddress = string.Empty;
        ////    if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
        ////    {
        ////        foreach (var orgAddress in organizationAddressCollection.OrganizationAddress)
        ////        {
        ////            if (tu)
        ////            {
        ////            }
        ////        }
        ////    }
        ////    return organizationAddress;
        ////}
        //#endregion
        #region PortLocation
        /// <summary>
        /// Obtiene el port location del consol
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        private string ObtenerPortLocation(OrganizationAddressCollection organizationAddressCollection)
        {
            string location = string.Empty;

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var portLocation = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == Enum.GetName(typeof(Enumeraciones.PortLocation), Enumeraciones.PortLocation.ArrivalCTOAddress)).ToList();
                if (portLocation.Count > 0)
                {
                    foreach (var pl in portLocation)
                    {
                        location = pl.CompanyName;
                    }
                }
            }
            return location;
        }
        #endregion
        #region SubShipmentCollection
        private List<Shipments> ObtenerShipments(Shipment shipment)
        {
            List<Shipments> lstShipments = new List<Shipments>();

            if (shipment.SubShipmentCollection != null && shipment.SubShipmentCollection.SubShipment.Count > 0)
            {
                foreach (var subShipment in shipment.SubShipmentCollection.SubShipment)
                {
                    Shipments shipments = new Shipments();

                    shipments.NroShipment = subShipment.DataContext.DataSourceCollection.DataSource[0].Key;
                    shipments.JobCosting = subShipment.JobCosting;
                    shipments.TransportLeg = ObtenerTransportLeg(subShipment.TransportLegCollection);
                    shipments.OrderReference = ObtenerLocalProcessing(subShipment.LocalProcessing);
                    shipments.HouseNumber = subShipment.WayBillNumber;
                    shipments.ShipmentType = ObtenerShipmentTypeSubshipment(subShipment);
                    shipments.Weight = ObtenerWeightSubshipment(subShipment.PackingLineCollection);
                    shipments.WeightUnit = ObtenerWeightUnitSubshipment(subShipment.PackingLineCollection);
                    shipments.ContainerMode = ObtenerContainerModeSubshipment(subShipment);
                    shipments.SendersLocalClient = ObtenerSendersLocalClient(subShipment.OrganizationAddressCollection);
                    shipments.SendersOverseasAgent = ObtenerSendersOverseasAgent(subShipment.OrganizationAddressCollection);
                    shipments.Consignor = ObtenerConsignor(subShipment.OrganizationAddressCollection);
                    shipments.Consignee = ObtenerConsignee(subShipment.OrganizationAddressCollection);
                    shipments.ArrivalCFS = ObtenerArrivalCFSAddress(subShipment.OrganizationAddressCollection);
                    shipments.Notify = ObtenerNotifyParty(subShipment.OrganizationAddressCollection);
                    shipments.BillIssued = ObtenerBillIssued(subShipment.DateCollection);
                    shipments.Onboard = ObtenerOnboard(subShipment.DateCollection);
                    shipments.ETD = ObtenerDeparture(subShipment.DateCollection);
                    shipments.PortOfOrigin = subShipment.PortOfOrigin;
                    shipments.Commodity = ObtenerCommodity(subShipment.PackingLineCollection);
                    if (shipments.ShipmentType.Code == nameof(Enumeraciones.ShipmentType.ASM))
                        shipments.Containers = ObtenerContainersASM(subShipment, shipment);
                    else
                        shipments.Containers = ObtenerContainers(subShipment, shipment);
                    shipments.PackageType = ObtenerOuterPacksPackageType(subShipment);
                    shipments.Pieces = subShipment.OuterPacks;
                    shipments.VolumeCM = subShipment.TotalVolume;
                    shipments.VolumeUnit = subShipment.TotalVolumeUnit;
                    shipments.GoodsDescription = ObtenerGoodsDescription(subShipment);
                    shipments.MarksAndNos = ObtenerNoteMarksAndNos(subShipment);
                    shipments.IncoTerm = subShipment.ShipmentIncoTerm.Code;
                    shipments.HBLContainerPackModeOverride = subShipment.HBLContainerPackModeOverride.Replace("CY", "FCL").Replace("CFS", "LCL");
                    shipments.FirmaOTM = ObtenerFirmaOTM(subShipment);
                    lstShipments.Add(shipments);

                }
            }
            return lstShipments;
        }
        #endregion
        #region OrderReference
        /// <summary>
        /// Obtiene el OrderReference
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public string ObtenerLocalProcessing(LocalProcessing localProcessing)
        {
            string orderReference = string.Empty;
            if (localProcessing != null && localProcessing.OrderNumberCollection != null && localProcessing.OrderNumberCollection.OrderNumber.Count>0)
            {
                foreach (var local in localProcessing.OrderNumberCollection.OrderNumber)
                {
                    orderReference = local.OrderReference != null? local.OrderReference:"";
                }
            }
            return orderReference;
        }
        #endregion
        #region FirmaOTM
        /// <summary>
        /// Obtiene la FirmaOTM
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public string ObtenerFirmaOTM(SubShipment subShipment)
        {
            string firmaOTM = string.Empty;
            if (subShipment.CustomizedFieldCollection != null && subShipment.CustomizedFieldCollection.CustomizedField.Count() > 0)
            {
                foreach (var customizedField in subShipment.CustomizedFieldCollection.CustomizedField)
                {
                    if (customizedField.Key == "Firma Autorizada OTMPART" && !string.IsNullOrEmpty(customizedField.Value))
                        firmaOTM = customizedField.Value;
                    if (customizedField.Key == "Firma autorizada OTM" && !string.IsNullOrEmpty(customizedField.Value))
                        firmaOTM = customizedField.Value;
                }
            }
            return firmaOTM;
        }
        #endregion
        #region Weight PackingLine
        public string ObtenerWeightSubshipment(PackingLineCollection packingLineCollection)
        {
            string weight = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (PackingLine part in packingLineCollection.PackingLine)
                {
                    weight = part.Weight;
                }
            }
            return weight;
        }
        public string ObtenerWeightSubshipment(PackingLineCollection packingLineCollection, string nroContenedor)
        {
            string weight = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                var findContenedor = packingLineCollection.PackingLine.Find(f => f.ContainerNumber == nroContenedor);
                if (findContenedor != null)
                {
                    weight = findContenedor.Weight;
                }
            }
            return weight;
        }
        public WeightUnit ObtenerWeightUnitSubshipment(PackingLineCollection packingLineCollection)
        {
            WeightUnit weightUnit = new WeightUnit();
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (PackingLine part in packingLineCollection.PackingLine)
                {
                    weightUnit.Code = part.WeightUnit.Code;
                    weightUnit.Description = part.WeightUnit.Description;
                }
            }
            return weightUnit;
        }
        public WeightUnit ObtenerWeightUnitSubshipment(PackingLineCollection packingLineCollection, string nroContenedor)
        {
            WeightUnit weightUnit = new WeightUnit();
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                var findContenedor = packingLineCollection.PackingLine.Find(f => f.ContainerNumber == nroContenedor);
                if (findContenedor != null)
                {
                    weightUnit.Code = findContenedor.WeightUnit.Code;
                    weightUnit.Description = findContenedor.WeightUnit.Description;
                }
            }
            return weightUnit;
        }
        #endregion
        #region Volumen PackingLine
        public string ObtenerVolumenSubshipment(PackingLineCollection packingLineCollection)
        {
            string volumen = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (PackingLine part in packingLineCollection.PackingLine)
                {
                    volumen = part.Volume;
                }
            }
            return volumen;
        }
        /// <summary>
        /// Obtiene el volumen del paquete cuando se extrae del consol el contenedor
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public string ObtenerVolumenSubshipmentConsol(PackingLineCollection packingLineCollection, string nroContenedor)
        {
            string volumen = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                var findContenedor = packingLineCollection.PackingLine.Find(f => f.ContainerNumber == nroContenedor);
                if (findContenedor != null)
                    volumen = findContenedor.Volume;
            }
            return volumen;
        }
        public string ObtenerVolumenUnitSubshipment(PackingLineCollection packingLineCollection)
        {
            string volumenUnit = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (PackingLine part in packingLineCollection.PackingLine)
                {
                    volumenUnit = part.VolumeUnit.Code;
                }
            }
            return volumenUnit;
        }
        /// <summary>
        /// Obtiene el codigo del tipo de paquete cuando se extrae del consol el contenedor
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public string ObtenerVolumenUnitSubshipmentConsol(PackingLineCollection packingLineCollection, string nroContenedor)
        {
            string volumenUnit = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                var findContenedor = packingLineCollection.PackingLine.Find(f => f.ContainerNumber == nroContenedor);
                if (findContenedor != null)
                    volumenUnit = findContenedor.VolumeUnit.Code;
            }
            return volumenUnit;
        }
        #endregion
        #region Package PackingLine
        /// <summary>
        /// Obtiene la cantidad del paquete
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public string ObtenerQuantityPackage(PackingLineCollection packingLineCollection)
        {
            string quantity = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (PackingLine part in packingLineCollection.PackingLine)
                {
                    quantity = part.PackQty;
                }
            }
            return quantity;
        }
        /// <summary>
        /// Obtiene la cantidad del paquete cuando se extrae del consol el contenedor
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public string ObtenerQuantityPackageConsol(PackingLineCollection packingLineCollection, string nroContenedor)
        {
            string quantity = string.Empty;
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                var findContenedor = packingLineCollection.PackingLine.Find(f => f.ContainerNumber == nroContenedor);
                if (findContenedor != null)
                    quantity = findContenedor.PackQty;
            }
            return quantity;
        }
        /// <summary>
        /// Obtiene el codigo y la descripcion del tipo de paquete
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public PackType ObtenerPackTypePackage(PackingLineCollection packingLineCollection)
        {
            PackType packType = new PackType();
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (PackingLine part in packingLineCollection.PackingLine)
                {
                    packType = part.PackType;
                }
            }
            return packType;
        }
        /// <summary>
        /// Obtiene el codigo del tipo de paquete cuando se extrae del consol el contenedor
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public PackType ObtenerPackTypePackageConsol(PackingLineCollection packingLineCollection, string nroContenedor)
        {
            PackType packType = new PackType();
            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                var findContenedor = packingLineCollection.PackingLine.Find(f => f.ContainerNumber == nroContenedor);
                if (findContenedor != null)
                    packType = findContenedor.PackType;
            }
            return packType;
        }
        #endregion
        #region PlaceOfReceipt
        /// <summary>
        /// Obtiene el PlaceOfReceipt
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public PlaceOfReceipt ObtenerPlaceOfReceipt(Shipment shipment)
        {
            PlaceOfReceipt placeOfReceipt = new PlaceOfReceipt();

            if (shipment != null && shipment.PlaceOfReceipt != null)
            {
                placeOfReceipt.Code = shipment.PlaceOfReceipt.Code;
                placeOfReceipt.Name = shipment.PlaceOfReceipt.Name;
            }
            return placeOfReceipt;
        }
        #endregion
        #region OuterPacksPackageType
        /// <summary>
        /// Obtiene el OuterPacksPackageType
        /// </summary>
        /// <param name="subShipment"></param>
        /// <returns></returns>
        public OuterPacksPackageType ObtenerOuterPacksPackageType(SubShipment subShipment)
        {
            OuterPacksPackageType outerPacksPackageType = new OuterPacksPackageType();
            if (subShipment.OuterPacksPackageType != null)
            {
                outerPacksPackageType = subShipment.OuterPacksPackageType;
            }
            return outerPacksPackageType;
        }
        #endregion
        #region GoodsDescription
        /// <summary>
        /// Obtiene el GoodsDescription
        /// </summary>
        /// <param name="subShipment"></param>
        /// <returns></returns>
        public string ObtenerGoodsDescription(SubShipment subShipment)
        {
            string goodsDescription = string.Empty;

            if (subShipment.NoteCollection != null && subShipment.NoteCollection.Note.Count() > 0)
            {
                foreach (var note in subShipment.NoteCollection.Note)
                {
                    if (note.Description == "Detailed Goods Description")
                        goodsDescription += " " + note.NoteText;
                }
            }
            if (string.IsNullOrEmpty(goodsDescription))
                if (!string.IsNullOrEmpty(subShipment.GoodsDescription) && string.IsNullOrEmpty(goodsDescription))
                    goodsDescription = subShipment.GoodsDescription;

            return goodsDescription;
        }
        #endregion
        #region Note MarksAndNos
        /// <summary>
        /// Obtiene el MarksAndNos
        /// </summary>
        /// <param name="subShipment"></param>
        /// <returns></returns>
        public string ObtenerNoteMarksAndNos(SubShipment subShipment)
        {
            string noteMarksAndNos = string.Empty;
            if (subShipment.NoteCollection != null && subShipment.NoteCollection.Note.Count() > 0)
            {
                foreach (var note in subShipment.NoteCollection.Note)
                {
                    if (note.Description == "Marks & Numbers")
                        noteMarksAndNos += " " + note.NoteText;
                }
            }
            return noteMarksAndNos;
        }
        #endregion

        #region ContainerMode
        /// <summary>
        /// Obtiene el container mode del subshipment
        /// </summary>
        /// <param name="subShipment"></param>
        /// <returns></returns>
        public ContainerMode ObtenerContainerModeSubshipment(SubShipment subShipment)
        {
            ContainerMode containerMode = new ContainerMode();
            if (subShipment.ContainerMode != null)
            {
                containerMode.Code = subShipment.ContainerMode.Code;
                containerMode.Description = subShipment.ContainerMode.Description;
            }
            return containerMode;
        }
        #endregion
        #region Containers
        /// <summary>
        /// Obtiene los Containers de los subshipment
        /// </summary>
        /// <param name="subShipment"></param>
        /// <returns></returns>
        public List<Containers> ObtenerContainers(SubShipment subShipment, Shipment shipment)
        {
            List<Containers> lstContainers = new List<Containers>();
            if (subShipment.ContainerCollection != null && subShipment.ContainerCollection.Container.Count > 0)
            {
                var lstcontainer = subShipment.PackingLineCollection.PackingLine.Select(s => s.ContainerNumber).ToList();
                foreach (string nroContenedor in lstcontainer)
                {
                    var contenedor = shipment.ContainerCollection.Container.Find(f => f.ContainerNumber == nroContenedor);
                    if (contenedor != null)
                    {
                        Containers container = new Containers();
                        container.ContainerNum = contenedor.ContainerNumber;
                        container.DeliveryMode = contenedor.DeliveryMode.Replace("CY", "FCL").Replace("CFS", "LCL");
                        container.Seal = contenedor.Seal;
                        container.TareWeight = !string.IsNullOrEmpty(contenedor.TareWeight) ? float.Parse(contenedor.TareWeight) : 0;
                        container.ContainerType = contenedor.ContainerType.Code;
                        container.Weight = ObtenerWeightSubshipment(subShipment.PackingLineCollection, contenedor.ContainerNumber); //contenedor.GoodsWeight;
                        container.Mode = contenedor.FCL_LCL_AIR.Code;
                        container.WeightUnit = ObtenerWeightUnitSubshipment(subShipment.PackingLineCollection, contenedor.ContainerNumber); //contenedor.WeightUnit;
                        container.PackQty = ObtenerQuantityPackageConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.PackType = ObtenerPackTypePackageConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.Volume = ObtenerVolumenSubshipmentConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.VolumeUnit = ObtenerVolumenUnitSubshipmentConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.SecondSeal = contenedor.SecondSeal;
                        container.ThirdSeal = contenedor.ThirdSeal;
                        lstContainers.Add(container);
                    }
                }
            }
            else if (shipment.ContainerCollection != null && shipment.ContainerCollection.Container.Count > 0)
            {
                var lstcontainer = subShipment.PackingLineCollection.PackingLine.Select(s => s.ContainerNumber).ToList();
                foreach (string nroContenedor in lstcontainer)
                {
                    var contenedor = shipment.ContainerCollection.Container.Find(f => f.ContainerNumber == nroContenedor);
                    if (contenedor != null)
                    {
                        Containers container = new Containers();
                        container.ContainerNum = contenedor.ContainerNumber;
                        container.DeliveryMode = contenedor.DeliveryMode.Replace("CY", "FCL").Replace("CFS", "LCL");
                        container.Seal = contenedor.Seal;
                        container.TareWeight = !string.IsNullOrEmpty(contenedor.TareWeight) ? float.Parse(contenedor.TareWeight) : 0;
                        container.ContainerType = contenedor.ContainerType.Code;
                        container.Weight = ObtenerWeightSubshipment(subShipment.PackingLineCollection, contenedor.ContainerNumber); //contenedor.GoodsWeight;
                        container.Mode = contenedor.FCL_LCL_AIR.Code;
                        container.WeightUnit = ObtenerWeightUnitSubshipment(subShipment.PackingLineCollection, contenedor.ContainerNumber); //contenedor.WeightUnit;
                        container.PackQty = ObtenerQuantityPackageConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.PackType = ObtenerPackTypePackageConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.Volume = ObtenerVolumenSubshipmentConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.VolumeUnit = ObtenerVolumenUnitSubshipmentConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        container.SecondSeal = contenedor.SecondSeal;
                        container.ThirdSeal = contenedor.ThirdSeal;
                        lstContainers.Add(container);
                    }
                }
            }
            return lstContainers;
        }
        /// <summary>
        /// Obtiene los Containers de los subshipment ASM
        /// </summary>
        /// <param name="subShipment"></param>
        /// <returns></returns>
        public List<Containers> ObtenerContainersASM(SubShipment subShipment, Shipment shipment)
        {
            List<Containers> lstContainers = new List<Containers>();
            if (shipment.ContainerCollection != null && shipment.ContainerCollection.Container.Count > 0)
            {
                foreach (var contenedor in shipment.ContainerCollection.Container)
                {
                    string totalPackQty = shipment.SubShipmentCollection.SubShipment.Select(s => s.PackingLineCollection.PackingLine.Where(w => w.ContainerNumber == contenedor.ContainerNumber).Sum(x => !string.IsNullOrEmpty(x.PackQty) ? Convert.ToInt32(x.PackQty) : 0)).Sum().ToString();
                    string totalVolument = shipment.SubShipmentCollection.SubShipment.Select(s => s.PackingLineCollection.PackingLine.Where(w => w.ContainerNumber == contenedor.ContainerNumber).Sum(x => !string.IsNullOrEmpty(x.Volume) ? float.Parse(x.Volume, CultureInfo.InvariantCulture.NumberFormat) : 0)).Sum().ToString();
                    string totalWeight = shipment.SubShipmentCollection.SubShipment.Select(s => s.PackingLineCollection.PackingLine.Where(w => w.ContainerNumber == contenedor.ContainerNumber).Sum(x => !string.IsNullOrEmpty(x.Weight) ? float.Parse(x.Weight, CultureInfo.InvariantCulture.NumberFormat) : 0)).Sum().ToString();
                    var weightUnit = shipment.SubShipmentCollection.SubShipment.Select(s => s.PackingLineCollection).Where(we => we.PackingLine.Count > 0).Select(se => se.PackingLine.Where(w => w.ContainerNumber == contenedor.ContainerNumber).Select(ss => ss.WeightUnit)).FirstOrDefault();
                    var volumeUnit = shipment.SubShipmentCollection.SubShipment.Select(s => s.PackingLineCollection).Where(we => we.PackingLine.Count > 0).Select(se => se.PackingLine.Where(w => w.ContainerNumber == contenedor.ContainerNumber).Select(ss => ss.VolumeUnit)).FirstOrDefault();
                    var lstcontainer = subShipment.PackingLineCollection.PackingLine.Select(s => s.ContainerNumber).ToList();
                    if (contenedor != null)
                    {
                        Containers container = new Containers();
                        container.ContainerNum = contenedor.ContainerNumber;
                        container.DeliveryMode = contenedor.DeliveryMode.Replace("CY", "FCL").Replace("CFS", "LCL");
                        container.Seal = contenedor.Seal;
                        container.TareWeight = !string.IsNullOrEmpty(contenedor.TareWeight) ? float.Parse(contenedor.TareWeight) : 0;
                        container.ContainerType = contenedor.ContainerType.Code;
                        container.Weight = totalWeight.Replace(",", "."); //contenedor.GoodsWeight;
                        container.Mode = contenedor.FCL_LCL_AIR.Code;
                        container.WeightUnit = weightUnit.Count() == 0 ? contenedor.WeightUnit : weightUnit.FirstOrDefault();
                        container.PackQty = totalPackQty;
                        container.PackType = ObtenerPackTypePackageConsol(subShipment.PackingLineCollection, contenedor.ContainerNumber);
                        if (container.PackType.Code == null)
                        {
                            container.PackType.Code = subShipment.OuterPacksPackageType.Code;
                            container.PackType.Description = subShipment.OuterPacksPackageType.Description;
                        }
                        container.Volume = totalVolument.Replace(",", ".");
                        container.VolumeUnit = volumeUnit.Count() == 0 ? contenedor.VolumeUnit.Code : volumeUnit.FirstOrDefault().Code;
                        container.SecondSeal = contenedor.SecondSeal;
                        container.ThirdSeal = contenedor.ThirdSeal;
                        lstContainers.Add(container);
                    }
                }
            }
            return lstContainers;
        }
        #endregion
        #region SendersLocalClient
        /// <summary>
        /// Obtiene el SendersLocalClient del subshipment
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        public SendersLocalClient ObtenerSendersLocalClient(OrganizationAddressCollection organizationAddressCollection)
        {
            SendersLocalClient sendersLocalClient = new SendersLocalClient();

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var LocalClient = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == nameof(Enumeraciones.SendersLocalClient.SendersLocalClient)).ToList();
                if (LocalClient.Count > 0)
                {
                    foreach (var lc in LocalClient)
                    {
                        sendersLocalClient.Nit = lc.GovRegNum;
                        sendersLocalClient.City = lc.City;
                        sendersLocalClient.Country = lc.Country.Name;
                        sendersLocalClient.Address = lc.Address1;
                        sendersLocalClient.Code = lc.OrganizationCode;
                        sendersLocalClient.Name = lc.CompanyName;
                    }
                }
            }
            return sendersLocalClient;
        }
        #endregion
        #region SendersOverseasAgent
        /// <summary>
        /// Obtiene el SendersOverseasAgent del subshipment
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        public SendersLocalClient ObtenerSendersOverseasAgent(OrganizationAddressCollection organizationAddressCollection)
        {
            SendersLocalClient sendersOverseasAgent = new SendersLocalClient();

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var LocalClient = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == Enum.GetName(typeof(Enumeraciones.SendersLocalClient), Enumeraciones.SendersLocalClient.SendersOverseasAgent)).ToList();
                if (LocalClient.Count > 0)
                {
                    foreach (var lc in LocalClient)
                    {
                        sendersOverseasAgent.Nit = lc.GovRegNum;
                        sendersOverseasAgent.City = lc.City;
                        sendersOverseasAgent.Country = lc.Country.Name;
                        sendersOverseasAgent.Address = lc.Address1;
                        sendersOverseasAgent.Code = lc.OrganizationCode;
                        sendersOverseasAgent.Name = lc.CompanyName;
                        sendersOverseasAgent.Phone = lc.Phone;
                    }
                }
            }
            return sendersOverseasAgent;
        }
        #endregion
        #region Consignor
        /// <summary>
        /// Obtiene el Consignor del subshipment
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        public Consignor ObtenerConsignor(OrganizationAddressCollection organizationAddressCollection)
        {
            Consignor consignor = new Consignor();

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var consignorAdress = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == Enum.GetName(typeof(Enumeraciones.SendersLocalClient), Enumeraciones.SendersLocalClient.ConsignorDocumentaryAddress)).ToList();
                if (consignorAdress.Count > 0)
                {
                    foreach (var ca in consignorAdress)
                    {
                        consignor.Nit = ca.GovRegNum;
                        consignor.City = ca.City;
                        consignor.Country = ca.Country.Name;
                        consignor.Address = ca.Address1;
                        consignor.Code = ca.OrganizationCode;
                        consignor.Name = ca.CompanyName;
                    }
                }
            }
            return consignor;
        }
        #endregion
        #region Consignee
        /// <summary>
        /// Obtiene el SendersOverseasAgent del subshipment
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        public Consignor ObtenerConsignee(OrganizationAddressCollection organizationAddressCollection)
        {
            Consignor consignee = new Consignor();

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var consigneeAdress = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == Enum.GetName(typeof(Enumeraciones.SendersLocalClient), Enumeraciones.SendersLocalClient.ConsigneeDocumentaryAddress)).ToList();
                if (consigneeAdress.Count > 0)
                {
                    foreach (var ca in consigneeAdress)
                    {
                        consignee.Nit = ca.GovRegNum;
                        consignee.City = ca.City;
                        consignee.Country = ca.Country.Name;
                        consignee.Address = ca.Address1;
                        consignee.Code = ca.OrganizationCode;
                        consignee.Name = ca.CompanyName;
                    }
                }
            }
            return consignee;
        }
        #endregion
        #region ArrivalCFSAddress
        /// <summary>
        /// Obtiene el ArrivalCFSAddress del subshipment
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        public SendersLocalClient ObtenerArrivalCFSAddress(OrganizationAddressCollection organizationAddressCollection)
        {
            SendersLocalClient sendersLocalClient = new SendersLocalClient();

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var localClient = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == Enum.GetName(typeof(Enumeraciones.SendersLocalClient), Enumeraciones.SendersLocalClient.ArrivalCFSAddress)).ToList();
                if (localClient.Count > 0)
                {
                    foreach (var lc in localClient)
                    {
                        sendersLocalClient.Nit = lc.GovRegNum;
                        sendersLocalClient.City = lc.City;
                        sendersLocalClient.Country = lc.Country.Name;
                        sendersLocalClient.Address = lc.Address1;
                        sendersLocalClient.AddressShort = lc.AddressShortCode;
                        sendersLocalClient.Code = lc.OrganizationCode;
                        sendersLocalClient.Name = lc.CompanyName;
                    }
                }
            }
            return sendersLocalClient;
        }
        #endregion
        #region NotifyParty
        /// <summary>
        /// Obtiene el NotifyParty del subshipment
        /// </summary>
        /// <param name="organizationAddressCollection"></param>
        /// <returns></returns>
        public SendersLocalClient ObtenerNotifyParty(OrganizationAddressCollection organizationAddressCollection)
        {
            SendersLocalClient notifyParty = new SendersLocalClient();

            if (organizationAddressCollection != null && organizationAddressCollection.OrganizationAddress.Count > 0)
            {
                var notifyP = organizationAddressCollection.OrganizationAddress.Where(w => w.AddressType == Enum.GetName(typeof(Enumeraciones.SendersLocalClient), Enumeraciones.SendersLocalClient.NotifyParty)).ToList();
                if (notifyP.Count > 0)
                {
                    foreach (var lc in notifyP)
                    {
                        notifyParty.Nit = lc.GovRegNum;
                        notifyParty.City = lc.City;
                        notifyParty.Country = lc.Country.Name;
                        notifyParty.Address = lc.Address1;
                        notifyParty.Code = lc.OrganizationCode;
                        notifyParty.Name = lc.CompanyName;
                    }
                }
            }
            return notifyParty;
        }
        #endregion
        #region BillIssued
        /// <summary>
        /// Obtiene el BillIssued del subshipment
        /// </summary>
        /// <param name="dateCollection"></param>
        /// <returns></returns>
        public string ObtenerBillIssued(DateCollection dateCollection)
        {
            string billIssued = string.Empty;

            if (dateCollection != null && dateCollection.Date.Count > 0)
            {
                var dateBillIssued = dateCollection.Date.Where(w => w.Type == nameof(Enumeraciones.BillIssued.BillIssued)).FirstOrDefault();
                if (dateBillIssued != null && !string.IsNullOrEmpty(dateBillIssued.Value))
                {
                    billIssued = dateBillIssued.Value.Substring(0, 10);
                }
            }
            return billIssued;
        }
        #endregion
        #region Commodity
        /// <summary>
        /// Obtiene el Commodity del subshipment
        /// </summary>
        /// <param name="packingLineCollection"></param>
        /// <returns></returns>
        public string ObtenerCommodity(PackingLineCollection packingLineCollection)
        {
            string commodity = string.Empty;

            if (packingLineCollection != null && packingLineCollection.PackingLine.Count > 0)
            {
                foreach (var packingLine in packingLineCollection.PackingLine)
                {
                    if (packingLine.Commodity != null && !string.IsNullOrEmpty(packingLine.Commodity.Code))
                        commodity = packingLine.Commodity.Code;
                }
            }
            return commodity;
        }
        #endregion
        #region Onboard
        /// <summary>
        /// Obtiene el Onboard del subshipment
        /// </summary>
        /// <param name="dateCollection"></param>
        /// <returns></returns>
        public string ObtenerOnboard(DateCollection dateCollection)
        {
            string onboard = string.Empty;

            if (dateCollection != null && dateCollection.Date.Count > 0)
            {
                var dateOnboard = dateCollection.Date.Where(w => w.Type == Enum.GetName(typeof(Enumeraciones.BillIssued), Enumeraciones.BillIssued.ShippedOnBoard)).FirstOrDefault();
                if (dateOnboard != null && !string.IsNullOrEmpty(dateOnboard.Value))
                {
                    onboard = dateOnboard.Value.Substring(0, 10);
                }
            }
            return onboard;
        }
        #endregion
        #region Departure
        /// <summary>
        /// Obtiene el Departure del subshipment
        /// </summary>
        /// <param name="dateCollection"></param>
        /// <returns></returns>
        public string ObtenerDeparture(DateCollection dateCollection)
        {
            string departure = string.Empty;

            if (dateCollection != null && dateCollection.Date.Count > 0)
            {
                var dateDeparture = dateCollection.Date.Where(w => w.Type == Enum.GetName(typeof(Enumeraciones.BillIssued), Enumeraciones.BillIssued.Departure)).FirstOrDefault();
                if (dateDeparture != null)
                {
                    departure = dateDeparture.Value.Substring(0, 10);
                }
            }
            return departure;
        }
        #endregion
        #region TransportLeg
        /// <summary>
        /// Obtiene el TransportLeg del subshipment
        /// </summary>
        /// <param name="transportLegCollection"></param>
        /// <returns></returns>
        public List<TransportLeg> ObtenerTransportLeg(TransportLegCollection transportLegCollection)
        {
            List<TransportLeg> lstTransportLeg = new List<TransportLeg>();

            if (transportLegCollection != null && transportLegCollection.TransportLeg.Count > 0)
            {
                foreach (TransportLeg transportL in transportLegCollection.TransportLeg)
                {
                    TransportLeg transportLeg = new TransportLeg();
                    transportLeg.TransportMode = transportL.TransportMode;
                    transportLeg.LegOrder = transportL.LegOrder;
                    transportLeg.PortOfLoading = transportL.PortOfLoading;
                    transportLeg.PortOfDischarge = transportL.PortOfDischarge;
                    transportLeg.EstimatedDeparture = transportL.EstimatedDeparture;
                    lstTransportLeg.Add(transportLeg);
                }
            }
            return lstTransportLeg;
        }
        #endregion
    }
}
