using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Entities.xmlCargoWise
{
    public class Shipments
    {
        public SendersLocalClient ArrivalCFS { get; set; }
		public string BillIssued { get; set; }
        public string Commodity { get; set; }
        public Consignor Consignor { get; set; }
        public Consignor Consignee { get; set; }
        public ContainerMode ContainerMode { get; set; }
        public List<Containers> Containers { get; set; } = new List<Containers>();
        public string ETD { get; set; }
        public string FirmaOTM { get; set; }
        public string GoodsDescription { get; set; }
        public string HBLContainerPackModeOverride { get; set; }
        public string HouseNumber { get; set; }
        public string IncoTerm { get; set; }
        public JobCosting JobCosting { get; set; }        
        public string MarksAndNos { get; set; }
        public SendersLocalClient Notify { get; set; }
        public string NroShipment { get; set; }
        public string Onboard { get; set; }
        public string OrderReference { get; set; }
        public OuterPacksPackageType PackageType { get; set; }
        public string Pieces { get; set; }
        public PortOfOrigin PortOfOrigin { get; set; }
        public SendersLocalClient SendersLocalClient { get; set; }
        public SendersLocalClient SendersOverseasAgent { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public List<TransportLeg> TransportLeg { get; set; }
        public string VolumeCM { get; set; }
        public TotalVolumeUnit VolumeUnit { get; set; }
        public string Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }       

    }
}
