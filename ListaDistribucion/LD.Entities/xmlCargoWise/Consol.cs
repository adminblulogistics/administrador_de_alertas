using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Entities.xmlCargoWise
{
    public  class Consol
    {
        public string ATA { get; set; }
        public string ATD { get; set; }
        public string ContainerMode { get; set; }
        public string CambioETA { get; set; }
        public string DeliveryMode { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public string ETAInicialCOIO { get; set; }
        public string Master { get; set; }
        public string Module { get; set; }
        public string NroConsol { get; set; }
        public string Payterms { get; set; }
        public PlaceOfReceipt PlaceOfReceipt { get; set; }
        public string PortLocation { get; set; }        
        public string ServiceLevel { get; set; }
        public List<Shipments> Shipments { get; set; }
        public string ShipmentType { get; set; }
        public List<TransportLeg> TransportLeg { get; set; }
        public string Voyage { get; set; }
        public string Vessel { get; set; }
        public string TotalWeight { get; set; }
        public string TotalWeightUnit { get; set; }
        public string TotalVolume { get; set; }
        public string TotalVolumeUnit { get; set; }
        public TransportMode TransportMode { get; set; }
    }
}
