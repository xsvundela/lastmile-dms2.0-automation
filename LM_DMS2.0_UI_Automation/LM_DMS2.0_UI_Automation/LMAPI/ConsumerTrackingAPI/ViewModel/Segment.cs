using System.Collections.Generic;

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.ViewModel
{
    public class Segment
    {
        public string SegmentScheduledDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string DeliveryServiceWindowStartTime { get; set; }
        public string DeliveryServiceWindowEndTime { get; set; }
        // public string ServiceDeliveryWindow { get; set; }
        public string ETA { get; set; }
        public string ETAStatus { get; set; }
        public IList<SegmentLineItem> Items { get; set; }
        public IList<Services> Services { get; set; }
        public IList<CIOrderEvents> Events { get; set; }
        public string CurrentStatus { get; set; }
    }
}
