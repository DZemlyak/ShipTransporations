using System;
using System.Collections.Generic;

namespace ShipTransportations.Model.Model
{
    public class Ship
    {
        public int ShipId { get; set; }
        public int PortId { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public int MaxDistance { get; set; }
        public int CrewSize { get; set; }

        public virtual Port Port { get; set; }

        public virtual ICollection<Captain> Captains { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        

        public override string ToString() {
            return string.Format("\nShipId: {0}\nPortId: {1}\nNumber: {2}\nCapacity: {3}\nCreateDate: {4}" +
                                 "\nMaxDistance: {5}\nCrewSize: {6}", ShipId, PortId, Number, Capacity,
                                 CreateDate.ToShortDateString(), MaxDistance, CrewSize);
        }
    }
}
