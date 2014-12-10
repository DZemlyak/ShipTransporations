using System;
using System.Linq;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Model.Model
{
    public class Trip
    {
        private int? _captainId;
        private int? _shipId;
        private int? _portFromId;
        private int? _portToId;

        public int TripId { get; set; }
        public int? CaptainId {
            get { return _captainId; }
            set {
                if (value != null && RepositoryHelper.CaptainRepository.ReadAll().All(a => a.CaptainId != value))
                    throw new Exception(string.Format("\nCan't find specified CaptainID : {0}.", value));
                _captainId = value;
            }
        }
        public int? ShipId
        {
            get { return _shipId; }
            set {
                if (value != null && RepositoryHelper.ShipRepository.ReadAll().All(a => a.ShipId != value))
                    throw new Exception(string.Format("\nCan't find specified ShipID : {0}.", value));
                _shipId = value;
            }
        }
        public int? PortIdFrom
        {
            get { return _portFromId; }
            set {
                if (value != null && RepositoryHelper.PortRepository.ReadAll().All(a => a.PortId != value))
                    throw new Exception(string.Format("\nCan't find specified PortFromID : {0}.", value));
                _portFromId = value;
            }
        }
        public int? PortIdTo {
            get { return _portToId; }
            set {
                if (value != null && RepositoryHelper.PortRepository.ReadAll().All(a => a.PortId != value))
                    throw new Exception(string.Format("\nCan't find specified PortToID : {0}.", value));
                _portToId = value;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString() {
            return string.Format("\nTripID: {0}\nCaptainId: {1}\nShipId: {2}\nPortIdFrom: {3}\nPortIdTo: {4}" +
                                 "\nStartDate: {5}\nEndDate: {6}", TripId, CaptainId, ShipId, PortIdFrom,
                                 PortIdTo, StartDate.ToShortDateString(), EndDate.ToShortDateString());
        }
    }
}
