using System;
using System.Linq;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Model.Model
{
    public class Ship
    {
        private int? _portId;

        public int ShipId { get; set; }
        public int? PortId
        {
            get { return _portId; }
            set {
                if (value != null && RepositoryHelper.PortRepository.ReadAll().All(a => a.PortId != value))
                    throw new Exception(string.Format("\nCan't find specified PortID : {0}.", value));
                _portId = value;
            }
        }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public int MaxDistance { get; set; }
        public int CrewSize { get; set; }

        public override string ToString() {
            return string.Format("\nShipId: {0}\nPortId: {1}\nNumber: {2}\nCapacity: {3}\nCreateDate: {4}" +
                                 "\nMaxDistance: {5}\nCrewSize: {6}", ShipId, PortId, Number, Capacity,
                                 CreateDate.ToShortDateString(), MaxDistance, CrewSize);
        }
    }
}
