using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace LD.Entities.xmlCargoWise
{
	[XmlRoot(ElementName = "Header", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Header
	{
		[XmlElement(ElementName = "SenderID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SenderID { get; set; }
		[XmlElement(ElementName = "RecipientID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string RecipientID { get; set; }
	}

	[XmlRoot(ElementName = "DataSource", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class DataSource
	{
		[XmlElement(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Type { get; set; }
		[XmlElement(ElementName = "Key", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Key { get; set; }
	}

	[XmlRoot(ElementName = "DataSourceCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class DataSourceCollection
	{
		[XmlElement(ElementName = "DataSource", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<DataSource> DataSource { get; set; }
	}

	[XmlRoot(ElementName = "ActionPurpose", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ActionPurpose
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Country", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Country
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "Company", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Company
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Country", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Country Country { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "EventBranch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class EventBranch
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "EventDepartment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class EventDepartment
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "EventType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class EventType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "EventUser", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class EventUser
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "RecipientRole", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class RecipientRole
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "RecipientRoleCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class RecipientRoleCollection
	{
		[XmlElement(ElementName = "RecipientRole", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public RecipientRole RecipientRole { get; set; }
	}

	[XmlRoot(ElementName = "DataContext", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class DataContext
	{
		[XmlElement(ElementName = "DataSourceCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public DataSourceCollection DataSourceCollection { get; set; }
		[XmlElement(ElementName = "ActionPurpose", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ActionPurpose ActionPurpose { get; set; }
		[XmlElement(ElementName = "Company", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Company Company { get; set; }
		[XmlElement(ElementName = "DataProvider", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DataProvider { get; set; }
		[XmlElement(ElementName = "EnterpriseID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EnterpriseID { get; set; }
		[XmlElement(ElementName = "EventBranch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public EventBranch EventBranch { get; set; }
		[XmlElement(ElementName = "EventDepartment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public EventDepartment EventDepartment { get; set; }
		[XmlElement(ElementName = "EventType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public EventType EventType { get; set; }
		[XmlElement(ElementName = "EventUser", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public EventUser EventUser { get; set; }
		[XmlElement(ElementName = "ServerID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ServerID { get; set; }
		[XmlElement(ElementName = "TriggerCount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TriggerCount { get; set; }
		[XmlElement(ElementName = "TriggerDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TriggerDate { get; set; }
		[XmlElement(ElementName = "TriggerDescription", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TriggerDescription { get; set; }
		[XmlElement(ElementName = "TriggerType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TriggerType { get; set; }
		[XmlElement(ElementName = "RecipientRoleCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public RecipientRoleCollection RecipientRoleCollection { get; set; }
	}

	[XmlRoot(ElementName = "AWBServiceLevel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class AWBServiceLevel
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "CarrierBookingLatestStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CarrierBookingLatestStatus
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "CarrierBookingOffice", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CarrierBookingOffice
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "ContainerMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerMode
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "FreightRateCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class FreightRateCurrency
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "MaximumAllowablePackageLengthUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class MaximumAllowablePackageLengthUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "PaymentMethod", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PaymentMethod
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "PlaceOfDelivery", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PlaceOfDelivery
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PlaceOfIssue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PlaceOfIssue
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PlaceOfReceipt", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PlaceOfReceipt
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PortFirstForeign", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortFirstForeign
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "PortLastForeign", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortLastForeign
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "PortOfDischarge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortOfDischarge
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PortOfFirstArrival", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortOfFirstArrival
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "PortOfLoading", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortOfLoading
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "ReceivingForwarderHandlingType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ReceivingForwarderHandlingType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "ReleaseType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ReleaseType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ScreeningStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ScreeningStatus
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "SendingForwarderHandlingType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SendingForwarderHandlingType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "ShipmentType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ShipmentType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "TotalNoOfPacksPackageType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TotalNoOfPacksPackageType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "TotalPreallocatedVolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TotalPreallocatedVolumeUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "TotalPreallocatedWeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TotalPreallocatedWeightUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "TotalVolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TotalVolumeUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "TotalWeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TotalWeightUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "TransportMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TransportMode
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "WayBillType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class WayBillType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Type
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "AdditionalReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class AdditionalReference
	{
		[XmlElement(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Type Type { get; set; }
		[XmlElement(ElementName = "ReferenceNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ReferenceNumber { get; set; }
		[XmlElement(ElementName = "ContextInformation", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContextInformation { get; set; }
		[XmlElement(ElementName = "IssueDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IssueDate { get; set; }
	}

	[XmlRoot(ElementName = "AdditionalReferenceCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class AdditionalReferenceCollection
	{
		[XmlElement(ElementName = "AdditionalReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public AdditionalReference AdditionalReference { get; set; }
		[XmlAttribute(AttributeName = "Content")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "AirVentFlowRateUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class AirVentFlowRateUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "Commodity", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Commodity
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ContainerQuality", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerQuality
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "ContainerStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerStatus
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "Category", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Category
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ContainerType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Category", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Category Category { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
		[XmlElement(ElementName = "ISOCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ISOCode { get; set; }
	}

	[XmlRoot(ElementName = "FCL_LCL_AIR", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class FCL_LCL_AIR
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "GoodsValueCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class GoodsValueCurrency
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "GrossWeightVerificationType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class GrossWeightVerificationType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "LengthUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class LengthUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "SealPartyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SealPartyType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "SecondSealPartyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SecondSealPartyType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "ThirdSealPartyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ThirdSealPartyType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "VolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class VolumeUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "WeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class WeightUnit
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "GovRegNumType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class GovRegNumType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Port", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Port
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "State", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class State
	{
		[XmlAttribute(AttributeName = "Description")]
		public string Description { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "CountryOfIssue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CountryOfIssue
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "RegistrationNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class RegistrationNumber
	{
		[XmlElement(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Type Type { get; set; }
		[XmlElement(ElementName = "CountryOfIssue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CountryOfIssue CountryOfIssue { get; set; }
		[XmlElement(ElementName = "Value", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "RegistrationNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class RegistrationNumberCollection
	{
		[XmlElement(ElementName = "RegistrationNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<RegistrationNumber> RegistrationNumber { get; set; }
	}

	[XmlRoot(ElementName = "Creditor", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Creditor
	{
		[XmlElement(ElementName = "AddressType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AddressType { get; set; }
		[XmlElement(ElementName = "Address1", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Address1 { get; set; }
		[XmlElement(ElementName = "Address2", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Address2 { get; set; }
		[XmlElement(ElementName = "AddressOverride", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AddressOverride { get; set; }
		[XmlElement(ElementName = "AddressShortCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AddressShortCode { get; set; }
		[XmlElement(ElementName = "City", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string City { get; set; }
		[XmlElement(ElementName = "CompanyName", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CompanyName { get; set; }
		[XmlElement(ElementName = "Country", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Country Country { get; set; }
		[XmlElement(ElementName = "Email", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Email { get; set; }
		[XmlElement(ElementName = "Fax", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Fax { get; set; }
		[XmlElement(ElementName = "GovRegNum", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GovRegNum { get; set; }
		[XmlElement(ElementName = "GovRegNumType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public GovRegNumType GovRegNumType { get; set; }
		[XmlElement(ElementName = "OrganizationCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OrganizationCode { get; set; }
		[XmlElement(ElementName = "Phone", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Phone { get; set; }
		[XmlElement(ElementName = "Port", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Port Port { get; set; }
		[XmlElement(ElementName = "Postcode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Postcode { get; set; }
		[XmlElement(ElementName = "ScreeningStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ScreeningStatus ScreeningStatus { get; set; }
		[XmlElement(ElementName = "State", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public State State { get; set; }
		[XmlElement(ElementName = "RegistrationNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public RegistrationNumberCollection RegistrationNumberCollection { get; set; }
		[XmlElement(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Type { get; set; }
		[XmlElement(ElementName = "Key", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Key { get; set; }
	}

	[XmlRoot(ElementName = "CreditorType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CreditorType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Currency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Currency
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Location", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Location
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PenaltyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PenaltyType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ProcessType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ProcessType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ContainerPenalty", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerPenalty
	{
		[XmlElement(ElementName = "Creditor", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Creditor Creditor { get; set; }
		[XmlElement(ElementName = "CreditorType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CreditorType CreditorType { get; set; }
		[XmlElement(ElementName = "Currency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Currency Currency { get; set; }
		[XmlElement(ElementName = "Duration", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Duration { get; set; }
		[XmlElement(ElementName = "FreeTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FreeTime { get; set; }
		[XmlElement(ElementName = "Location", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Location Location { get; set; }
		[XmlElement(ElementName = "PenaltyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PenaltyType PenaltyType { get; set; }
		[XmlElement(ElementName = "PerUnitCost", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PerUnitCost { get; set; }
		[XmlElement(ElementName = "ProcessType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ProcessType ProcessType { get; set; }
		[XmlElement(ElementName = "TimeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TimeUnit { get; set; }
		[XmlElement(ElementName = "TotalCost", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalCost { get; set; }
	}

	[XmlRoot(ElementName = "ContainerPenaltyCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerPenaltyCollection
	{
		[XmlElement(ElementName = "ContainerPenalty", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<ContainerPenalty> ContainerPenalty { get; set; }
	}

	[XmlRoot(ElementName = "Milestone", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Milestone
	{
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
		[XmlElement(ElementName = "EventCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EventCode { get; set; }
		[XmlElement(ElementName = "Sequence", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Sequence { get; set; }
		[XmlElement(ElementName = "ActualDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ActualDate { get; set; }
		[XmlElement(ElementName = "ConditionReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ConditionReference { get; set; }
		[XmlElement(ElementName = "ConditionType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ConditionType { get; set; }
		[XmlElement(ElementName = "EstimatedDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EstimatedDate { get; set; }
	}

	[XmlRoot(ElementName = "MilestoneCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class MilestoneCollection
	{
		[XmlElement(ElementName = "Milestone", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<Milestone> Milestone { get; set; }
	}

	[XmlRoot(ElementName = "Container", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Container
	{
		[XmlElement(ElementName = "AirVentFlow", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AirVentFlow { get; set; }
		[XmlElement(ElementName = "AirVentFlowRateUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public AirVentFlowRateUnit AirVentFlowRateUnit { get; set; }
		[XmlElement(ElementName = "ArrivalCartageAdvised", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalCartageAdvised { get; set; }
		[XmlElement(ElementName = "ArrivalCartageComplete", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalCartageComplete { get; set; }
		[XmlElement(ElementName = "ArrivalCartageDemurrageTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalCartageDemurrageTime { get; set; }
		[XmlElement(ElementName = "ArrivalCartageRef", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalCartageRef { get; set; }
		[XmlElement(ElementName = "ArrivalCTOStorageStartDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalCTOStorageStartDate { get; set; }
		[XmlElement(ElementName = "ArrivalDeliveryRequiredBy", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalDeliveryRequiredBy { get; set; }
		[XmlElement(ElementName = "ArrivalEstimatedDelivery", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalEstimatedDelivery { get; set; }
		[XmlElement(ElementName = "ArrivalPickupByRail", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalPickupByRail { get; set; }
		[XmlElement(ElementName = "ArrivalSlotDateTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalSlotDateTime { get; set; }
		[XmlElement(ElementName = "ArrivalSlotReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalSlotReference { get; set; }
		[XmlElement(ElementName = "ArrivalTruckWaitTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalTruckWaitTime { get; set; }
		[XmlElement(ElementName = "Commodity", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Commodity Commodity { get; set; }
		[XmlElement(ElementName = "ContainerCount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerCount { get; set; }
		[XmlElement(ElementName = "ContainerImportDORelease", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerImportDORelease { get; set; }
		[XmlElement(ElementName = "ContainerJobID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerJobID { get; set; }
		[XmlElement(ElementName = "ContainerNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerNumber { get; set; }
		[XmlElement(ElementName = "ContainerParkEmptyPickupGateOut", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerParkEmptyPickupGateOut { get; set; }
		[XmlElement(ElementName = "ContainerParkEmptyReturnGateIn", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerParkEmptyReturnGateIn { get; set; }
		[XmlElement(ElementName = "ContainerQuality", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerQuality ContainerQuality { get; set; }
		[XmlElement(ElementName = "ContainerStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerStatus ContainerStatus { get; set; }
		[XmlElement(ElementName = "ContainerType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerType ContainerType { get; set; }
		[XmlElement(ElementName = "DeliveryMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryMode { get; set; }
		[XmlElement(ElementName = "DeliverySequence", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliverySequence { get; set; }
		[XmlElement(ElementName = "DepartureCartageAdvised", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureCartageAdvised { get; set; }
		[XmlElement(ElementName = "DepartureCartageComplete", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureCartageComplete { get; set; }
		[XmlElement(ElementName = "DepartureCartageDemurrageTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureCartageDemurrageTime { get; set; }
		[XmlElement(ElementName = "DepartureCartageRef", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureCartageRef { get; set; }
		[XmlElement(ElementName = "DepartureDeliveryByRail", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureDeliveryByRail { get; set; }
		[XmlElement(ElementName = "DepartureDockReceipt", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureDockReceipt { get; set; }
		[XmlElement(ElementName = "DepartureEstimatedPickup", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureEstimatedPickup { get; set; }
		[XmlElement(ElementName = "DepartureSlotDateTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureSlotDateTime { get; set; }
		[XmlElement(ElementName = "DepartureSlotReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureSlotReference { get; set; }
		[XmlElement(ElementName = "DepartureTruckWaitTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DepartureTruckWaitTime { get; set; }
		[XmlElement(ElementName = "DunnageWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DunnageWeight { get; set; }
		[XmlElement(ElementName = "EmptyReadyForReturn", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EmptyReadyForReturn { get; set; }
		[XmlElement(ElementName = "EmptyRequired", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EmptyRequired { get; set; }
		[XmlElement(ElementName = "EmptyReturnedBy", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EmptyReturnedBy { get; set; }
		[XmlElement(ElementName = "EmptyReturnRef", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EmptyReturnRef { get; set; }
		[XmlElement(ElementName = "ExportDepotCustomsReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ExportDepotCustomsReference { get; set; }
		[XmlElement(ElementName = "FCL_LCL_AIR", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public FCL_LCL_AIR FCL_LCL_AIR { get; set; }
		[XmlElement(ElementName = "FCLAvailable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLAvailable { get; set; }
		[XmlElement(ElementName = "FCLHeldInTransitStaging", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLHeldInTransitStaging { get; set; }
		[XmlElement(ElementName = "FCLOnBoardVessel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLOnBoardVessel { get; set; }
		[XmlElement(ElementName = "FCLStorageArrivedUnderbond", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLStorageArrivedUnderbond { get; set; }
		[XmlElement(ElementName = "FCLStorageCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLStorageCommences { get; set; }
		[XmlElement(ElementName = "FCLStorageModuleOnlyMaster", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLStorageModuleOnlyMaster { get; set; }
		[XmlElement(ElementName = "FCLStorageUnderbondCleared", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLStorageUnderbondCleared { get; set; }
		[XmlElement(ElementName = "FCLUnloadFromVessel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLUnloadFromVessel { get; set; }
		[XmlElement(ElementName = "FCLWharfGateIn", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLWharfGateIn { get; set; }
		[XmlElement(ElementName = "FCLWharfGateOut", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLWharfGateOut { get; set; }
		[XmlElement(ElementName = "GoodsValue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GoodsValue { get; set; }
		[XmlElement(ElementName = "GoodsValueCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public GoodsValueCurrency GoodsValueCurrency { get; set; }
		[XmlElement(ElementName = "GoodsWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GoodsWeight { get; set; }
		[XmlElement(ElementName = "GrossWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GrossWeight { get; set; }
		[XmlElement(ElementName = "GrossWeightVerificationType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public GrossWeightVerificationType GrossWeightVerificationType { get; set; }
		[XmlElement(ElementName = "HumidityPercent", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string HumidityPercent { get; set; }
		[XmlElement(ElementName = "ImportDepotCustomsReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ImportDepotCustomsReference { get; set; }
		[XmlElement(ElementName = "IsCFSRegistered", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsCFSRegistered { get; set; }
		[XmlElement(ElementName = "IsControlledAtmosphere", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsControlledAtmosphere { get; set; }
		[XmlElement(ElementName = "IsDamaged", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsDamaged { get; set; }
		[XmlElement(ElementName = "IsEmptyContainer", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsEmptyContainer { get; set; }
		[XmlElement(ElementName = "IsSealOk", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsSealOk { get; set; }
		[XmlElement(ElementName = "IsShipperOwned", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsShipperOwned { get; set; }
		[XmlElement(ElementName = "LCLAvailable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLAvailable { get; set; }
		[XmlElement(ElementName = "LCLStorageCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLStorageCommences { get; set; }
		[XmlElement(ElementName = "LCLUnpack", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLUnpack { get; set; }
		[XmlElement(ElementName = "LengthUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public LengthUnit LengthUnit { get; set; }
		[XmlElement(ElementName = "Link", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Link { get; set; }
		[XmlElement(ElementName = "NonOperatingReefer", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string NonOperatingReefer { get; set; }
		[XmlElement(ElementName = "OverhangBack", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverhangBack { get; set; }
		[XmlElement(ElementName = "OverhangFront", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverhangFront { get; set; }
		[XmlElement(ElementName = "OverhangHeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverhangHeight { get; set; }
		[XmlElement(ElementName = "OverhangLeft", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverhangLeft { get; set; }
		[XmlElement(ElementName = "OverhangRight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverhangRight { get; set; }
		[XmlElement(ElementName = "OverrideFCLAvailableStorage", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverrideFCLAvailableStorage { get; set; }
		[XmlElement(ElementName = "OverrideLCLAvailableStorage", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OverrideLCLAvailableStorage { get; set; }
		[XmlElement(ElementName = "PackDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PackDate { get; set; }
		[XmlElement(ElementName = "RefrigGeneratorID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string RefrigGeneratorID { get; set; }
		[XmlElement(ElementName = "ReleaseNum", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ReleaseNum { get; set; }
		[XmlElement(ElementName = "Seal", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Seal { get; set; }
		[XmlElement(ElementName = "SealPartyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SealPartyType SealPartyType { get; set; }
		[XmlElement(ElementName = "SecondSeal", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SecondSeal { get; set; }
		[XmlElement(ElementName = "SecondSealPartyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SecondSealPartyType SecondSealPartyType { get; set; }
		[XmlElement(ElementName = "SetPointTemp", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SetPointTemp { get; set; }
		[XmlElement(ElementName = "SetPointTempUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SetPointTempUnit { get; set; }
		[XmlElement(ElementName = "StowagePosition", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string StowagePosition { get; set; }
		[XmlElement(ElementName = "TareWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TareWeight { get; set; }
		[XmlElement(ElementName = "TempRecorderSerialNo", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TempRecorderSerialNo { get; set; }
		[XmlElement(ElementName = "ThirdSeal", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ThirdSeal { get; set; }
		[XmlElement(ElementName = "ThirdSealPartyType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ThirdSealPartyType ThirdSealPartyType { get; set; }
		[XmlElement(ElementName = "TotalHeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalHeight { get; set; }
		[XmlElement(ElementName = "TotalLength", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalLength { get; set; }
		[XmlElement(ElementName = "TotalWidth", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalWidth { get; set; }
		[XmlElement(ElementName = "TrainWagonNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TrainWagonNumber { get; set; }
		[XmlElement(ElementName = "UnpackGang", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string UnpackGang { get; set; }
		[XmlElement(ElementName = "UnpackShed", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string UnpackShed { get; set; }
		[XmlElement(ElementName = "VolumeCapacity", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VolumeCapacity { get; set; }
		[XmlElement(ElementName = "VolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public VolumeUnit VolumeUnit { get; set; }
		[XmlElement(ElementName = "WeightCapacity", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string WeightCapacity { get; set; }
		[XmlElement(ElementName = "WeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public WeightUnit WeightUnit { get; set; }
		[XmlElement(ElementName = "ContainerPenaltyCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerPenaltyCollection ContainerPenaltyCollection { get; set; }
		[XmlElement(ElementName = "MilestoneCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public MilestoneCollection MilestoneCollection { get; set; }
	}

	[XmlRoot(ElementName = "ContainerCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ContainerCollection
	{
		[XmlElement(ElementName = "Container", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<Container> Container { get; set; }
		[XmlAttribute(AttributeName = "Content")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "CustomizedField", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CustomizedField
	{
		[XmlElement(ElementName = "DataType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DataType { get; set; }
		[XmlElement(ElementName = "Key", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Key { get; set; }
		[XmlElement(ElementName = "Value", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "CustomizedFieldCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CustomizedFieldCollection
	{
		[XmlElement(ElementName = "CustomizedField", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<CustomizedField> CustomizedField { get; set; }
	}

	[XmlRoot(ElementName = "Date", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Date
	{
		[XmlElement(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Type { get; set; }
		[XmlElement(ElementName = "IsEstimate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsEstimate { get; set; }
		[XmlElement(ElementName = "Value", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "DateCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class DateCollection
	{
		[XmlElement(ElementName = "Date", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<Date> Date { get; set; }
	}

	[XmlRoot(ElementName = "MessageNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class MessageNumber
	{
		[XmlAttribute(AttributeName = "Type")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "MessageNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class MessageNumberCollection
	{
		[XmlElement(ElementName = "MessageNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<MessageNumber> MessageNumber { get; set; }
	}

	[XmlRoot(ElementName = "OrganizationAddress", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class OrganizationAddress
	{
		[XmlElement(ElementName = "AddressType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AddressType { get; set; }
		[XmlElement(ElementName = "Address1", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Address1 { get; set; }
		[XmlElement(ElementName = "Address2", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Address2 { get; set; }
		[XmlElement(ElementName = "AddressOverride", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AddressOverride { get; set; }
		[XmlElement(ElementName = "AddressShortCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AddressShortCode { get; set; }
		[XmlElement(ElementName = "City", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string City { get; set; }
		[XmlElement(ElementName = "CompanyName", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CompanyName { get; set; }
		[XmlElement(ElementName = "Country", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Country Country { get; set; }
		[XmlElement(ElementName = "Email", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Email { get; set; }
		[XmlElement(ElementName = "Fax", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Fax { get; set; }
		[XmlElement(ElementName = "GovRegNum", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GovRegNum { get; set; }
		[XmlElement(ElementName = "GovRegNumType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public GovRegNumType GovRegNumType { get; set; }
		[XmlElement(ElementName = "OrganizationCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OrganizationCode { get; set; }
		[XmlElement(ElementName = "Phone", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Phone { get; set; }
		[XmlElement(ElementName = "Port", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Port Port { get; set; }
		[XmlElement(ElementName = "Postcode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Postcode { get; set; }
		[XmlElement(ElementName = "ScreeningStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ScreeningStatus ScreeningStatus { get; set; }
		[XmlElement(ElementName = "RegistrationNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public RegistrationNumberCollection RegistrationNumberCollection { get; set; }
		[XmlElement(ElementName = "State", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public State State { get; set; }
	}

	[XmlRoot(ElementName = "OrganizationAddressCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class OrganizationAddressCollection
	{
		[XmlElement(ElementName = "OrganizationAddress", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<OrganizationAddress> OrganizationAddress { get; set; }
	}

	[XmlRoot(ElementName = "CommunityTransitStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CommunityTransitStatus
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "HBLAWBChargesDisplay", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class HBLAWBChargesDisplay
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "HouseBillOfLadingType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class HouseBillOfLadingType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "InsuranceValueCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class InsuranceValueCurrency
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "Branch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Branch
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "Department", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Department
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "HomeBranch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class HomeBranch
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "OperationsStaff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class OperationsStaff
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "SalesStaff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SalesStaff
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "ChargeCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ChargeCode
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ChargeCodeGroup", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ChargeCodeGroup
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "CostGSTVATID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CostGSTVATID
	{
		[XmlElement(ElementName = "TaxCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TaxCode { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "CostOSCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CostOSCurrency
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "CostRatingBehaviour", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CostRatingBehaviour
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Debtor", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Debtor
	{
		[XmlElement(ElementName = "Type", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Type { get; set; }
		[XmlElement(ElementName = "Key", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Key { get; set; }
	}

	[XmlRoot(ElementName = "SellGSTVATID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SellGSTVATID
	{
		[XmlElement(ElementName = "TaxCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TaxCode { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "SellOSCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SellOSCurrency
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "SellRatingBehaviour", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SellRatingBehaviour
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ChargeLine", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ChargeLine
	{
		[XmlElement(ElementName = "APCashAdvanceRequired", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string APCashAdvanceRequired { get; set; }
		[XmlElement(ElementName = "ARCashAdvanceRequired", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ARCashAdvanceRequired { get; set; }
		[XmlElement(ElementName = "Branch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Branch Branch { get; set; }
		[XmlElement(ElementName = "ChargeCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ChargeCode ChargeCode { get; set; }
		[XmlElement(ElementName = "ChargeCodeGroup", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ChargeCodeGroup ChargeCodeGroup { get; set; }
		[XmlElement(ElementName = "CostExchangeRate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostExchangeRate { get; set; }
		[XmlElement(ElementName = "CostGSTVATID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CostGSTVATID CostGSTVATID { get; set; }
		[XmlElement(ElementName = "CostIsPosted", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostIsPosted { get; set; }
		[XmlElement(ElementName = "CostLocalAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostLocalAmount { get; set; }
		[XmlElement(ElementName = "CostOSAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostOSAmount { get; set; }
		[XmlElement(ElementName = "CostOSCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CostOSCurrency CostOSCurrency { get; set; }
		[XmlElement(ElementName = "CostOSGSTVATAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostOSGSTVATAmount { get; set; }
		[XmlElement(ElementName = "CostRatingBehaviour", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CostRatingBehaviour CostRatingBehaviour { get; set; }
		[XmlElement(ElementName = "Creditor", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Creditor Creditor { get; set; }
		[XmlElement(ElementName = "Debtor", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Debtor Debtor { get; set; }
		[XmlElement(ElementName = "Department", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Department Department { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
		[XmlElement(ElementName = "DisplaySequence", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DisplaySequence { get; set; }
		[XmlElement(ElementName = "SellExchangeRate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellExchangeRate { get; set; }
		[XmlElement(ElementName = "SellGSTVATID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SellGSTVATID SellGSTVATID { get; set; }
		[XmlElement(ElementName = "SellInvoiceType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellInvoiceType { get; set; }
		[XmlElement(ElementName = "SellIsPosted", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellIsPosted { get; set; }
		[XmlElement(ElementName = "SellLocalAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellLocalAmount { get; set; }
		[XmlElement(ElementName = "SellOSAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellOSAmount { get; set; }
		[XmlElement(ElementName = "SellOSCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SellOSCurrency SellOSCurrency { get; set; }
		[XmlElement(ElementName = "SellOSGSTVATAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellOSGSTVATAmount { get; set; }
		[XmlElement(ElementName = "SellRatingBehaviour", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SellRatingBehaviour SellRatingBehaviour { get; set; }
		[XmlElement(ElementName = "CostRatingBasisCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostRatingBasisCollection { get; set; }
		[XmlElement(ElementName = "SellRatingBasisCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string SellRatingBasisCollection { get; set; }
		[XmlElement(ElementName = "CostAPInvoiceNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostAPInvoiceNumber { get; set; }
		[XmlElement(ElementName = "CostDueDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostDueDate { get; set; }
		[XmlElement(ElementName = "CostInvoiceDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CostInvoiceDate { get; set; }
	}

	[XmlRoot(ElementName = "ChargeLineCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ChargeLineCollection
	{
		[XmlElement(ElementName = "ChargeLine", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<ChargeLine> ChargeLine { get; set; }
	}

	[XmlRoot(ElementName = "JobCosting", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class JobCosting
	{
		[XmlElement(ElementName = "AccrualNotRecognized", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AccrualNotRecognized { get; set; }
		[XmlElement(ElementName = "AccrualRecognized", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AccrualRecognized { get; set; }
		[XmlElement(ElementName = "AgentRevenue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AgentRevenue { get; set; }
		[XmlElement(ElementName = "Branch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Branch Branch { get; set; }
		[XmlElement(ElementName = "ClientContractNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ClientContractNumber { get; set; }
		[XmlElement(ElementName = "Currency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Currency Currency { get; set; }
		[XmlElement(ElementName = "Department", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Department Department { get; set; }
		[XmlElement(ElementName = "HomeBranch", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public HomeBranch HomeBranch { get; set; }
		[XmlElement(ElementName = "LocalClientRevenue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LocalClientRevenue { get; set; }
		[XmlElement(ElementName = "OperationsStaff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public OperationsStaff OperationsStaff { get; set; }
		[XmlElement(ElementName = "OtherDebtorRevenue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OtherDebtorRevenue { get; set; }
		[XmlElement(ElementName = "SalesStaff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SalesStaff SalesStaff { get; set; }
		[XmlElement(ElementName = "TotalAccrual", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalAccrual { get; set; }
		[XmlElement(ElementName = "TotalCost", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalCost { get; set; }
		[XmlElement(ElementName = "TotalJobProfit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalJobProfit { get; set; }
		[XmlElement(ElementName = "TotalRevenue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalRevenue { get; set; }
		[XmlElement(ElementName = "TotalWIP", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalWIP { get; set; }
		[XmlElement(ElementName = "WIPNotRecognized", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string WIPNotRecognized { get; set; }
		[XmlElement(ElementName = "WIPRecognized", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string WIPRecognized { get; set; }
		[XmlElement(ElementName = "ChargeLineCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ChargeLineCollection ChargeLineCollection { get; set; }
	}

	[XmlRoot(ElementName = "OuterPacksPackageType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class OuterPacksPackageType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "PortOfDestination", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortOfDestination
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "PortOfOrigin", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PortOfOrigin
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "ServiceLevel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ServiceLevel
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ShipmentIncoTerm", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ShipmentIncoTerm
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ShippedOnBoard", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ShippedOnBoard
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "ShipperCODPayMethod", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ShipperCODPayMethod
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "ExportStatement", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class ExportStatement
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "FCLDeliveryEquipmentNeeded", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class FCLDeliveryEquipmentNeeded
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "FCLPickupEquipmentNeeded", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class FCLPickupEquipmentNeeded
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "PrintOptionForPackagesOnAWB", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PrintOptionForPackagesOnAWB
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "OrderNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class OrderNumber
	{
		[XmlElement(ElementName = "OrderReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OrderReference { get; set; }
		[XmlElement(ElementName = "Sequence", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Sequence { get; set; }
	}

	[XmlRoot(ElementName = "OrderNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class OrderNumberCollection
	{
		[XmlElement(ElementName = "OrderNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<OrderNumber> OrderNumber { get; set; }
	}

	[XmlRoot(ElementName = "LocalProcessing", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class LocalProcessing
	{
		[XmlElement(ElementName = "ArrivalCartageRef", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ArrivalCartageRef { get; set; }
		[XmlElement(ElementName = "DeliveryCartageAdvised", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryCartageAdvised { get; set; }
		[XmlElement(ElementName = "DeliveryCartageCompleted", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryCartageCompleted { get; set; }
		[XmlElement(ElementName = "DeliveryLabourCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryLabourCharge { get; set; }
		[XmlElement(ElementName = "DeliveryLabourTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryLabourTime { get; set; }
		[XmlElement(ElementName = "DeliveryRequiredBy", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryRequiredBy { get; set; }
		[XmlElement(ElementName = "DeliveryRequiredFrom", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryRequiredFrom { get; set; }
		[XmlElement(ElementName = "DeliveryTruckWaitCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryTruckWaitCharge { get; set; }
		[XmlElement(ElementName = "DeliveryTruckWaitTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DeliveryTruckWaitTime { get; set; }
		[XmlElement(ElementName = "DemurrageOnDeliveryCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DemurrageOnDeliveryCharge { get; set; }
		[XmlElement(ElementName = "DemurrageOnDeliveryTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DemurrageOnDeliveryTime { get; set; }
		[XmlElement(ElementName = "DemurrageOnPickupCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DemurrageOnPickupCharge { get; set; }
		[XmlElement(ElementName = "DemurrageOnPickupTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DemurrageOnPickupTime { get; set; }
		[XmlElement(ElementName = "EstimatedDelivery", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EstimatedDelivery { get; set; }
		[XmlElement(ElementName = "EstimatedPickup", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EstimatedPickup { get; set; }
		[XmlElement(ElementName = "ExportStatement", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ExportStatement ExportStatement { get; set; }
		[XmlElement(ElementName = "FCLAvailable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLAvailable { get; set; }
		[XmlElement(ElementName = "FCLDeliveryDetentionCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLDeliveryDetentionCharge { get; set; }
		[XmlElement(ElementName = "FCLDeliveryDetentionDays", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLDeliveryDetentionDays { get; set; }
		[XmlElement(ElementName = "FCLDeliveryDetentionFreeDays", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLDeliveryDetentionFreeDays { get; set; }
		[XmlElement(ElementName = "FCLDeliveryEquipmentNeeded", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public FCLDeliveryEquipmentNeeded FCLDeliveryEquipmentNeeded { get; set; }
		[XmlElement(ElementName = "FCLPickupDetentionCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLPickupDetentionCharge { get; set; }
		[XmlElement(ElementName = "FCLPickupDetentionDays", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLPickupDetentionDays { get; set; }
		[XmlElement(ElementName = "FCLPickupDetentionFreeDays", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLPickupDetentionFreeDays { get; set; }
		[XmlElement(ElementName = "FCLPickupEquipmentNeeded", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public FCLPickupEquipmentNeeded FCLPickupEquipmentNeeded { get; set; }
		[XmlElement(ElementName = "FCLStorageCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLStorageCommences { get; set; }
		[XmlElement(ElementName = "HasProhibitedPackaging", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string HasProhibitedPackaging { get; set; }
		[XmlElement(ElementName = "InsuranceRequired", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string InsuranceRequired { get; set; }
		[XmlElement(ElementName = "IsContingencyRelease", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsContingencyRelease { get; set; }
		[XmlElement(ElementName = "LCLAirStorageCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLAirStorageCharge { get; set; }
		[XmlElement(ElementName = "LCLAirStorageDaysOrHours", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLAirStorageDaysOrHours { get; set; }
		[XmlElement(ElementName = "LCLAvailable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLAvailable { get; set; }
		[XmlElement(ElementName = "LCLDatesOverrideConsol", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLDatesOverrideConsol { get; set; }
		[XmlElement(ElementName = "LCLStorageCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLStorageCommences { get; set; }
		[XmlElement(ElementName = "PickupCartageAdvised", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupCartageAdvised { get; set; }
		[XmlElement(ElementName = "PickupCartageCompleted", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupCartageCompleted { get; set; }
		[XmlElement(ElementName = "PickupLabourCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupLabourCharge { get; set; }
		[XmlElement(ElementName = "PickupLabourTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupLabourTime { get; set; }
		[XmlElement(ElementName = "PickupRequiredBy", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupRequiredBy { get; set; }
		[XmlElement(ElementName = "PickupRequiredFrom", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupRequiredFrom { get; set; }
		[XmlElement(ElementName = "PickupTruckWaitCharge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupTruckWaitCharge { get; set; }
		[XmlElement(ElementName = "PickupTruckWaitTime", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PickupTruckWaitTime { get; set; }
		[XmlElement(ElementName = "PrintOptionForPackagesOnAWB", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PrintOptionForPackagesOnAWB PrintOptionForPackagesOnAWB { get; set; }
		[XmlElement(ElementName = "OrderNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public OrderNumberCollection OrderNumberCollection { get; set; }
	}

	[XmlRoot(ElementName = "NoteContext", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class NoteContext
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Visibility", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Visibility
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "Note", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Note
	{
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
		[XmlElement(ElementName = "IsCustomDescription", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsCustomDescription { get; set; }
		[XmlElement(ElementName = "NoteText", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string NoteText { get; set; }
		[XmlElement(ElementName = "NoteContext", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public NoteContext NoteContext { get; set; }
		[XmlElement(ElementName = "Visibility", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Visibility Visibility { get; set; }
	}

	[XmlRoot(ElementName = "NoteCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class NoteCollection
	{
		[XmlElement(ElementName = "Note", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<Note> Note { get; set; }
		[XmlAttribute(AttributeName = "Content")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "CountryOfOrigin", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CountryOfOrigin
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "LastKnownCFSStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class LastKnownCFSStatus
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "PackType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PackType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "PackingLine", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PackingLine
	{
		[XmlElement(ElementName = "Commodity", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Commodity Commodity { get; set; }
		[XmlElement(ElementName = "ContainerLink", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerLink { get; set; }
		[XmlElement(ElementName = "ContainerNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerNumber { get; set; }
		[XmlElement(ElementName = "ContainerPackingOrder", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerPackingOrder { get; set; }
		[XmlElement(ElementName = "CountryOfOrigin", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CountryOfOrigin CountryOfOrigin { get; set; }
		[XmlElement(ElementName = "DetailedDescription", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DetailedDescription { get; set; }
		[XmlElement(ElementName = "EndItemNo", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EndItemNo { get; set; }
		[XmlElement(ElementName = "ExportReferenceNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ExportReferenceNumber { get; set; }
		[XmlElement(ElementName = "GoodsDescription", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GoodsDescription { get; set; }
		[XmlElement(ElementName = "HarmonisedCode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string HarmonisedCode { get; set; }
		[XmlElement(ElementName = "Height", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Height { get; set; }
		[XmlElement(ElementName = "ImportReferenceNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ImportReferenceNumber { get; set; }
		[XmlElement(ElementName = "ItemNo", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ItemNo { get; set; }
		[XmlElement(ElementName = "LastKnownCFSStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public LastKnownCFSStatus LastKnownCFSStatus { get; set; }
		[XmlElement(ElementName = "LastKnownCFSStatusDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LastKnownCFSStatusDate { get; set; }
		[XmlElement(ElementName = "Length", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Length { get; set; }
		[XmlElement(ElementName = "LengthUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public LengthUnit LengthUnit { get; set; }
		[XmlElement(ElementName = "LinePrice", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LinePrice { get; set; }
		[XmlElement(ElementName = "Link", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Link { get; set; }
		[XmlElement(ElementName = "LoadingMeters", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LoadingMeters { get; set; }
		[XmlElement(ElementName = "MarksAndNos", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string MarksAndNos { get; set; }
		[XmlElement(ElementName = "OutturnComment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnComment { get; set; }
		[XmlElement(ElementName = "OutturnDamagedQty", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnDamagedQty { get; set; }
		[XmlElement(ElementName = "OutturnedHeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnedHeight { get; set; }
		[XmlElement(ElementName = "OutturnedLength", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnedLength { get; set; }
		[XmlElement(ElementName = "OutturnedVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnedVolume { get; set; }
		[XmlElement(ElementName = "OutturnedWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnedWeight { get; set; }
		[XmlElement(ElementName = "OutturnedWidth", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnedWidth { get; set; }
		[XmlElement(ElementName = "OutturnPillagedQty", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnPillagedQty { get; set; }
		[XmlElement(ElementName = "OutturnQty", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OutturnQty { get; set; }
		[XmlElement(ElementName = "PackingLineID", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PackingLineID { get; set; }
		[XmlElement(ElementName = "PackQty", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PackQty { get; set; }
		[XmlElement(ElementName = "PackType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PackType PackType { get; set; }
		[XmlElement(ElementName = "ReferenceNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ReferenceNumber { get; set; }
		[XmlElement(ElementName = "RequiresTemperatureControl", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string RequiresTemperatureControl { get; set; }
		[XmlElement(ElementName = "Volume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Volume { get; set; }
		[XmlElement(ElementName = "VolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public VolumeUnit VolumeUnit { get; set; }
		[XmlElement(ElementName = "Weight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Weight { get; set; }
		[XmlElement(ElementName = "WeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public WeightUnit WeightUnit { get; set; }
		[XmlElement(ElementName = "Width", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Width { get; set; }
		[XmlElement(ElementName = "PackedItemCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PackedItemCollection { get; set; }
	}

	[XmlRoot(ElementName = "PackingLineCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class PackingLineCollection
	{
		[XmlElement(ElementName = "PackingLine", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<PackingLine> PackingLine { get; set; }
		[XmlAttribute(AttributeName = "Content")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "SubShipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SubShipment
	{
		[XmlElement(ElementName = "DataContext", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public DataContext DataContext { get; set; }
		[XmlElement(ElementName = "ActualChargeable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ActualChargeable { get; set; }
		[XmlElement(ElementName = "AdditionalTerms", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AdditionalTerms { get; set; }
		[XmlElement(ElementName = "BookingConfirmationReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string BookingConfirmationReference { get; set; }
		[XmlElement(ElementName = "CartageWaybillNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CartageWaybillNumber { get; set; }
		[XmlElement(ElementName = "CFSReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CFSReference { get; set; }
		[XmlElement(ElementName = "CommunityTransitStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CommunityTransitStatus CommunityTransitStatus { get; set; }
		[XmlElement(ElementName = "ContainerCount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]		
		public string ContainerCount { get; set; }
		[XmlElement(ElementName = "ContainerCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerCollection ContainerCollection { get; set; }
		[XmlElement(ElementName = "ContainerMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerMode ContainerMode { get; set; }
		[XmlElement(ElementName = "DocumentedChargeable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentedChargeable { get; set; }
		[XmlElement(ElementName = "DocumentedVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentedVolume { get; set; }
		[XmlElement(ElementName = "DocumentedWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentedWeight { get; set; }
		[XmlElement(ElementName = "FreightRate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FreightRate { get; set; }
		[XmlElement(ElementName = "FreightRateCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public FreightRateCurrency FreightRateCurrency { get; set; }
		[XmlElement(ElementName = "GoodsDescription", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GoodsDescription { get; set; }
		[XmlElement(ElementName = "GoodsValue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string GoodsValue { get; set; }
		[XmlElement(ElementName = "GoodsValueCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public GoodsValueCurrency GoodsValueCurrency { get; set; }
		[XmlElement(ElementName = "HBLAWBChargesDisplay", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public HBLAWBChargesDisplay HBLAWBChargesDisplay { get; set; }
		[XmlElement(ElementName = "HBLContainerPackModeOverride", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string HBLContainerPackModeOverride { get; set; }
		[XmlElement(ElementName = "HouseBillOfLadingType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public HouseBillOfLadingType HouseBillOfLadingType { get; set; }
		[XmlElement(ElementName = "InsuranceValue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string InsuranceValue { get; set; }
		[XmlElement(ElementName = "InsuranceValueCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public InsuranceValueCurrency InsuranceValueCurrency { get; set; }
		[XmlElement(ElementName = "InterimReceiptNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string InterimReceiptNumber { get; set; }
		[XmlElement(ElementName = "IsBooking", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsBooking { get; set; }
		[XmlElement(ElementName = "IsCancelled", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsCancelled { get; set; }
		[XmlElement(ElementName = "IsCFSRegistered", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsCFSRegistered { get; set; }
		[XmlElement(ElementName = "IsDirectBooking", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsDirectBooking { get; set; }
		[XmlElement(ElementName = "IsForwardRegistered", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsForwardRegistered { get; set; }
		[XmlElement(ElementName = "IsHighRisk", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsHighRisk { get; set; }
		[XmlElement(ElementName = "IsNeutralMaster", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsNeutralMaster { get; set; }
		[XmlElement(ElementName = "IsShipping", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsShipping { get; set; }
		[XmlElement(ElementName = "IsSplitShipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsSplitShipment { get; set; }
		[XmlElement(ElementName = "JobCosting", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public JobCosting JobCosting { get; set; }
		[XmlElement(ElementName = "LloydsIMO", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LloydsIMO { get; set; }
		[XmlElement(ElementName = "ManifestedChargeable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ManifestedChargeable { get; set; }
		[XmlElement(ElementName = "ManifestedVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ManifestedVolume { get; set; }
		[XmlElement(ElementName = "ManifestedWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ManifestedWeight { get; set; }
		[XmlElement(ElementName = "NoCopyBills", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string NoCopyBills { get; set; }
		[XmlElement(ElementName = "NoOriginalBills", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string NoOriginalBills { get; set; }
		[XmlElement(ElementName = "OuterPacks", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OuterPacks { get; set; }
		[XmlElement(ElementName = "OuterPacksPackageType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public OuterPacksPackageType OuterPacksPackageType { get; set; }
		[XmlElement(ElementName = "PackingOrder", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string PackingOrder { get; set; }
		[XmlElement(ElementName = "PortOfDestination", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfDestination PortOfDestination { get; set; }
		[XmlElement(ElementName = "PortOfDischarge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfDischarge PortOfDischarge { get; set; }
		[XmlElement(ElementName = "PortOfFirstArrival", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfFirstArrival PortOfFirstArrival { get; set; }
		[XmlElement(ElementName = "PortOfLoading", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfLoading PortOfLoading { get; set; }
		[XmlElement(ElementName = "PortOfOrigin", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfOrigin PortOfOrigin { get; set; }
		[XmlElement(ElementName = "ReleaseType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ReleaseType ReleaseType { get; set; }
		[XmlElement(ElementName = "ScreeningStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ScreeningStatus ScreeningStatus { get; set; }
		[XmlElement(ElementName = "ServiceLevel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ServiceLevel ServiceLevel { get; set; }
		[XmlElement(ElementName = "ShipmentIncoTerm", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ShipmentIncoTerm ShipmentIncoTerm { get; set; }
		[XmlElement(ElementName = "ShipmentType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ShipmentType ShipmentType { get; set; }
		[XmlElement(ElementName = "ShippedOnBoard", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ShippedOnBoard ShippedOnBoard { get; set; }
		[XmlElement(ElementName = "ShipperCODAmount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ShipperCODAmount { get; set; }
		[XmlElement(ElementName = "ShipperCODPayMethod", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ShipperCODPayMethod ShipperCODPayMethod { get; set; }
		[XmlElement(ElementName = "TotalNoOfPacks", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalNoOfPacks { get; set; }
		[XmlElement(ElementName = "TotalNoOfPacksPackageType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalNoOfPacksPackageType TotalNoOfPacksPackageType { get; set; }
		[XmlElement(ElementName = "TotalVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalVolume { get; set; }
		[XmlElement(ElementName = "TotalVolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalVolumeUnit TotalVolumeUnit { get; set; }
		[XmlElement(ElementName = "TotalWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalWeight { get; set; }
		[XmlElement(ElementName = "TotalWeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalWeightUnit TotalWeightUnit { get; set; }
		[XmlElement(ElementName = "TranshipToOtherCFS", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TranshipToOtherCFS { get; set; }
		[XmlElement(ElementName = "TransportLegCollection")]
		public TransportLegCollection TransportLegCollection { get; set; }
		[XmlElement(ElementName = "TransportMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TransportMode TransportMode { get; set; }
		[XmlElement(ElementName = "VesselName", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VesselName { get; set; }
		[XmlElement(ElementName = "VoyageFlightNo", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VoyageFlightNo { get; set; }
		[XmlElement(ElementName = "WarehouseLocation", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string WarehouseLocation { get; set; }
		[XmlElement(ElementName = "WayBillNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string WayBillNumber { get; set; }
		[XmlElement(ElementName = "WayBillType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public WayBillType WayBillType { get; set; }
		[XmlElement(ElementName = "LocalProcessing", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public LocalProcessing LocalProcessing { get; set; }
		[XmlElement(ElementName = "CustomizedFieldCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CustomizedFieldCollection CustomizedFieldCollection { get; set; }
		[XmlElement(ElementName = "DateCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public DateCollection DateCollection { get; set; }
		[XmlElement(ElementName = "MilestoneCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public MilestoneCollection MilestoneCollection { get; set; }
		[XmlElement(ElementName = "NoteCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public NoteCollection NoteCollection { get; set; }
		[XmlElement(ElementName = "OrganizationAddressCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public OrganizationAddressCollection OrganizationAddressCollection { get; set; }
		[XmlElement(ElementName = "PackingLineCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PackingLineCollection PackingLineCollection { get; set; }
	}

	[XmlRoot(ElementName = "SubShipmentCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class SubShipmentCollection
	{
		[XmlElement(ElementName = "SubShipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<SubShipment> SubShipment { get; set; }
	}

	[XmlRoot(ElementName = "AircraftType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class AircraftType
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "BookingStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class BookingStatus
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Description { get; set; }
	}

	[XmlRoot(ElementName = "CarrierServiceLevel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class CarrierServiceLevel
	{
		[XmlElement(ElementName = "Code", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName = "TransportLeg", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TransportLeg
	{
		[XmlElement(ElementName = "PortOfDischarge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfDischarge PortOfDischarge { get; set; }
		[XmlElement(ElementName = "PortOfLoading", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfLoading PortOfLoading { get; set; }
		[XmlElement(ElementName = "LegOrder", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LegOrder { get; set; }
		[XmlElement(ElementName = "ActualArrival", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ActualArrival { get; set; }
		[XmlElement(ElementName = "ActualDeparture", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ActualDeparture { get; set; }
		[XmlElement(ElementName = "AircraftType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public AircraftType AircraftType { get; set; }
		[XmlElement(ElementName = "BookingStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public BookingStatus BookingStatus { get; set; }
		[XmlElement(ElementName = "CarrierBookingReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CarrierBookingReference { get; set; }
		[XmlElement(ElementName = "CarrierServiceLevel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CarrierServiceLevel CarrierServiceLevel { get; set; }
		[XmlElement(ElementName = "DocumentCutOff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentCutOff { get; set; }
		[XmlElement(ElementName = "EmptyCutOff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EmptyCutOff { get; set; }
		[XmlElement(ElementName = "EmptyReceivalCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EmptyReceivalCommences { get; set; }
		[XmlElement(ElementName = "EstimatedArrival", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EstimatedArrival { get; set; }
		[XmlElement(ElementName = "EstimatedDeparture", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string EstimatedDeparture { get; set; }
		[XmlElement(ElementName = "FCLAvailability", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLAvailability { get; set; }
		[XmlElement(ElementName = "FCLCutOff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLCutOff { get; set; }
		[XmlElement(ElementName = "FCLReceivalCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLReceivalCommences { get; set; }
		[XmlElement(ElementName = "FCLStorage", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FCLStorage { get; set; }
		[XmlElement(ElementName = "HazzardCutOffDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string HazzardCutOffDate { get; set; }
		[XmlElement(ElementName = "HazzardReceivalCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string HazzardReceivalCommences { get; set; }
		[XmlElement(ElementName = "IsCargoOnly", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsCargoOnly { get; set; }
		[XmlElement(ElementName = "LCLAvailability", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLAvailability { get; set; }
		[XmlElement(ElementName = "LCLCutOff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLCutOff { get; set; }
		[XmlElement(ElementName = "LCLReceivalCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLReceivalCommences { get; set; }
		[XmlElement(ElementName = "LCLStorageDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LCLStorageDate { get; set; }
		[XmlElement(ElementName = "LegNotes", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LegNotes { get; set; }
		[XmlElement(ElementName = "LegType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LegType { get; set; }
		[XmlElement(ElementName = "ReeferCutOff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ReeferCutOff { get; set; }
		[XmlElement(ElementName = "ReeferReceivalCommences", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ReeferReceivalCommences { get; set; }
		[XmlElement(ElementName = "ScheduledArrival", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ScheduledArrival { get; set; }
		[XmlElement(ElementName = "ScheduledDeparture", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ScheduledDeparture { get; set; }
		[XmlElement(ElementName = "TransportMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TransportMode { get; set; }
		[XmlElement(ElementName = "VesselLloydsIMO", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VesselLloydsIMO { get; set; }
		[XmlElement(ElementName = "VesselName", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VesselName { get; set; }
		[XmlElement(ElementName = "VGMCutOff", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VGMCutOff { get; set; }
		[XmlElement(ElementName = "VoyageFlightNo", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VoyageFlightNo { get; set; }
	}

	[XmlRoot(ElementName = "TransportLegCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class TransportLegCollection
	{
		[XmlElement(ElementName = "TransportLeg", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public List<TransportLeg> TransportLeg { get; set; }
		[XmlAttribute(AttributeName = "Content")]
		public string Content { get; set; }
	}

	[XmlRoot(ElementName = "Shipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Shipment
	{
		[XmlElement(ElementName = "DataContext", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public DataContext DataContext { get; set; }
		[XmlElement(ElementName = "AgentsReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string AgentsReference { get; set; }
		[XmlElement(ElementName = "AWBServiceLevel", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public AWBServiceLevel AWBServiceLevel { get; set; }
		[XmlElement(ElementName = "BookingConfirmationReference", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string BookingConfirmationReference { get; set; }
		[XmlElement(ElementName = "CarrierBookingLatestDate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CarrierBookingLatestDate { get; set; }
		[XmlElement(ElementName = "CarrierBookingLatestStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CarrierBookingLatestStatus CarrierBookingLatestStatus { get; set; }
		[XmlElement(ElementName = "CarrierBookingOffice", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CarrierBookingOffice CarrierBookingOffice { get; set; }
		[XmlElement(ElementName = "CarrierContractNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string CarrierContractNumber { get; set; }
		[XmlElement(ElementName = "ChargeableRate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ChargeableRate { get; set; }
		[XmlElement(ElementName = "ContainerCount", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ContainerCount { get; set; }
		[XmlElement(ElementName = "ContainerMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerMode ContainerMode { get; set; }
		[XmlElement(ElementName = "DocumentedChargeable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentedChargeable { get; set; }
		[XmlElement(ElementName = "DocumentedVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentedVolume { get; set; }
		[XmlElement(ElementName = "DocumentedWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string DocumentedWeight { get; set; }
		[XmlElement(ElementName = "FreightRate", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string FreightRate { get; set; }
		[XmlElement(ElementName = "FreightRateCurrency", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public FreightRateCurrency FreightRateCurrency { get; set; }
		[XmlElement(ElementName = "IsCFSRegistered", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsCFSRegistered { get; set; }
		[XmlElement(ElementName = "IsDirectBooking", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsDirectBooking { get; set; }
		[XmlElement(ElementName = "IsForwardRegistered", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsForwardRegistered { get; set; }
		[XmlElement(ElementName = "IsHazardous", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsHazardous { get; set; }
		[XmlElement(ElementName = "IsNeutralMaster", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string IsNeutralMaster { get; set; }
		[XmlElement(ElementName = "LloydsIMO", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string LloydsIMO { get; set; }
		[XmlElement(ElementName = "ManifestedChargeable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ManifestedChargeable { get; set; }
		[XmlElement(ElementName = "ManifestedVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ManifestedVolume { get; set; }
		[XmlElement(ElementName = "ManifestedWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string ManifestedWeight { get; set; }
		[XmlElement(ElementName = "MaximumAllowablePackageHeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string MaximumAllowablePackageHeight { get; set; }
		[XmlElement(ElementName = "MaximumAllowablePackageLength", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string MaximumAllowablePackageLength { get; set; }
		[XmlElement(ElementName = "MaximumAllowablePackageLengthUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public MaximumAllowablePackageLengthUnit MaximumAllowablePackageLengthUnit { get; set; }
		[XmlElement(ElementName = "MaximumAllowablePackageWidth", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string MaximumAllowablePackageWidth { get; set; }
		[XmlElement(ElementName = "NoCopyBills", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string NoCopyBills { get; set; }
		[XmlElement(ElementName = "NoOriginalBills", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string NoOriginalBills { get; set; }
		[XmlElement(ElementName = "OuterPacks", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string OuterPacks { get; set; }
		[XmlElement(ElementName = "PaymentMethod", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PaymentMethod PaymentMethod { get; set; }
		[XmlElement(ElementName = "PlaceOfDelivery", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PlaceOfDelivery PlaceOfDelivery { get; set; }
		[XmlElement(ElementName = "PlaceOfIssue", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PlaceOfIssue PlaceOfIssue { get; set; }
		[XmlElement(ElementName = "PlaceOfReceipt", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PlaceOfReceipt PlaceOfReceipt { get; set; }
		[XmlElement(ElementName = "PortFirstForeign", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortFirstForeign PortFirstForeign { get; set; }
		[XmlElement(ElementName = "PortLastForeign", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortLastForeign PortLastForeign { get; set; }
		[XmlElement(ElementName = "PortOfDischarge", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfDischarge PortOfDischarge { get; set; }
		[XmlElement(ElementName = "PortOfFirstArrival", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfFirstArrival PortOfFirstArrival { get; set; }
		[XmlElement(ElementName = "PortOfLoading", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public PortOfLoading PortOfLoading { get; set; }
		[XmlElement(ElementName = "ReceivingForwarderHandlingType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ReceivingForwarderHandlingType ReceivingForwarderHandlingType { get; set; }
		[XmlElement(ElementName = "ReleaseType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ReleaseType ReleaseType { get; set; }
		[XmlElement(ElementName = "RequiresTemperatureControl", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string RequiresTemperatureControl { get; set; }
		[XmlElement(ElementName = "ScreeningStatus", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ScreeningStatus ScreeningStatus { get; set; }
		[XmlElement(ElementName = "SendingForwarderHandlingType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SendingForwarderHandlingType SendingForwarderHandlingType { get; set; }
		[XmlElement(ElementName = "ShipmentType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ShipmentType ShipmentType { get; set; }
		[XmlElement(ElementName = "TotalNoOfPacks", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalNoOfPacks { get; set; }
		[XmlElement(ElementName = "TotalNoOfPacksPackageType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalNoOfPacksPackageType TotalNoOfPacksPackageType { get; set; }
		[XmlElement(ElementName = "TotalPreallocatedChargeable", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalPreallocatedChargeable { get; set; }
		[XmlElement(ElementName = "TotalPreallocatedVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalPreallocatedVolume { get; set; }
		[XmlElement(ElementName = "TotalPreallocatedVolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalPreallocatedVolumeUnit TotalPreallocatedVolumeUnit { get; set; }
		[XmlElement(ElementName = "TotalPreallocatedWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalPreallocatedWeight { get; set; }
		[XmlElement(ElementName = "TotalPreallocatedWeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalPreallocatedWeightUnit TotalPreallocatedWeightUnit { get; set; }
		[XmlElement(ElementName = "TotalVolume", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalVolume { get; set; }
		[XmlElement(ElementName = "TotalVolumeUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalVolumeUnit TotalVolumeUnit { get; set; }
		[XmlElement(ElementName = "TotalWeight", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string TotalWeight { get; set; }
		[XmlElement(ElementName = "TotalWeightUnit", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TotalWeightUnit TotalWeightUnit { get; set; }
		[XmlElement(ElementName = "TransportMode", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TransportMode TransportMode { get; set; }
		[XmlElement(ElementName = "VesselName", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VesselName { get; set; }
		[XmlElement(ElementName = "VoyageFlightNo", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string VoyageFlightNo { get; set; }
		[XmlElement(ElementName = "WayBillNumber", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public string WayBillNumber { get; set; }
		[XmlElement(ElementName = "WayBillType", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public WayBillType WayBillType { get; set; }
		[XmlElement(ElementName = "AdditionalReferenceCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public AdditionalReferenceCollection AdditionalReferenceCollection { get; set; }
		[XmlElement(ElementName = "ContainerCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public ContainerCollection ContainerCollection { get; set; }
		[XmlElement(ElementName = "CustomizedFieldCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public CustomizedFieldCollection CustomizedFieldCollection { get; set; }
		[XmlElement(ElementName = "DateCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public DateCollection DateCollection { get; set; }
		[XmlElement(ElementName = "MessageNumberCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public MessageNumberCollection MessageNumberCollection { get; set; }
		[XmlElement(ElementName = "MilestoneCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public MilestoneCollection MilestoneCollection { get; set; }
		[XmlElement(ElementName = "OrganizationAddressCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public OrganizationAddressCollection OrganizationAddressCollection { get; set; }
		[XmlElement(ElementName = "SubShipmentCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public SubShipmentCollection SubShipmentCollection { get; set; }
		[XmlElement(ElementName = "TransportLegCollection", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public TransportLegCollection TransportLegCollection { get; set; }
	}

	[XmlRoot(ElementName = "UniversalShipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class UniversalShipment
	{
		[XmlElement(ElementName = "Shipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Shipment Shipment { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
	}

	[XmlRoot(ElementName = "Body", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class Body
	{
		[XmlElement(ElementName = "UniversalShipment", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public UniversalShipment UniversalShipment { get; set; }
	}

	[XmlRoot(ElementName = "UniversalInterchange", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
	public class UniversalInterchange
	{
		[XmlElement(ElementName = "Header", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Header Header { get; set; }
		[XmlElement(ElementName = "Body", Namespace = "http://www.cargowise.com/Schemas/Universal/2011/11")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
	}

}
