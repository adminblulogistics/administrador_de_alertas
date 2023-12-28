using System;
using System.Collections.Generic;
using System.Text;

namespace LD.Entities.xmlCargoWise
{
    public class Containers
    {
        public string ContainerNum { get; set; }
        public string ContainerType { get; set; }
        public string DeliveryMode { get; set; }        
        public string Mode { get; set; }
        public string PackQty { get; set; }
        public PackType PackType { get; set; }
        public string Seal { get; set; }
        public string  SecondSeal { get; set; }
        public float TareWeight { get; set; }
        public string ThirdSeal { get; set; }
        public string Volume { get; set; }
        public string VolumeUnit { get; set; }
        public string Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        
    }
}
