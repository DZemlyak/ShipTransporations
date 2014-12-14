using System;
using System.Collections.Generic;

namespace ShipTransportations.Model.Model
{
    public class Trip
    {
        public int TripId { get; set; }
        public int CaptainId { get; set; }
        public int ShipId { get; set; }
        public int PortIdFrom { get; set; }
        public int PortIdTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Captain Captain { get; set; }
        public virtual Ship Ship { get; set; }
        public virtual Port PortFrom { get; set; }
        public virtual Port PortTo { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; } 

        public override string ToString() {
            return string.Format("\nTripID: {0}\nCaptainId: {1}\nShipId: {2}\nPortIdFrom: {3}\nPortIdTo: {4}" +
                                 "\nStartDate: {5}\nEndDate: {6}", TripId, CaptainId, ShipId, PortIdFrom,
                                 PortIdTo, StartDate.ToShortDateString(), EndDate.ToShortDateString());
        }
    }
}
