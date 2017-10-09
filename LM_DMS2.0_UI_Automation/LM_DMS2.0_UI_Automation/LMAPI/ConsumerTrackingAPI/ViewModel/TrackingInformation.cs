using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel
{
   public  class TrackingInformationAPIResponse
    {
        public long OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string ServiceType { get; set; }
        public string ReferenceId { get; set; }
        public string AlternateReferenceId { get; set; }
        public string OrderBookedDate { get; set; }
        public string OrderScheduledDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string DeliveryServiceWindowStartTime { get; set; }
        public string DeliveryServiceWindowEndTime { get; set; }

        //   public string ServiceDeliveryWindow { get; set; }
        public string ETA { get; set; }
        public string ETAStatus { get; set; }
        public string CurrentStatus { get; set; }
        public OrderDeliveryInfo Destination { get; set; }
        public IList<Products>Items { get; set; }
        public IList<Events> Events { get; set; }


        //MinimalTrackingInformationCIOrder
        public IList<Segment> Segments { get; set; }

        //TrackingInformationCIOrder
        public ShipperInfo Shipper { get; set; }
        public ConsigneeInfo Consignee { get; set; }
        // public string Phone { get; set; }
        //  public string Email { get; set; }


        public IList<CIOrderSegment> CISegments { get; set; }
        public bool SmsOptInStatus { get; set; }
        public bool AutoSurveyOptInStatus { get; set; }

        //TrackingInformation
        public string AlertMessage { get; set; }
        public bool CanRescheduleOrder { get; set; }
        public string CallCenterTelephoneNumber { get; set; }
        public string CallCenterEmailAddress { get; set; }

    }
}
