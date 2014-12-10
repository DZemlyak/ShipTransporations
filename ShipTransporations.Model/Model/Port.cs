using System;
using System.Linq;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Model.Model
{
    public class Port
    {
        public int PortId { get; set; }
        private int _cityId;
        public int CityId {
            get { return _cityId; }
            set {
                if (RepositoryHelper.CityRepository.ReadAll().All(a => a.CityId != value))
                    throw new Exception(string.Format("\nCan't find specified CityID : {0}.", value));
                _cityId = value;
            }
        }

        public string Name { get; set; }

        public override string ToString() {
            return string.Format("\nPortID: {0}\nCityID: {1}\nName: {2}", PortId, CityId, Name);
        }
    }
}
