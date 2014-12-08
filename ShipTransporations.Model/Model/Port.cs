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
                    throw new Exception(string.Format("Can't find specified CityID : {0}.", value));
                _cityId = value;
            }
        }

        public string Name { get; set; }

        public Port(int portId, int cityId, string name) {
            PortId = portId;
            CityId = cityId;
            Name = name;
        }
        public Port() { }

        public override string ToString() {
            return string.Format("\nPortID: {0}\nCityID: {1}\nName: {2}", PortId, CityId, Name);
        }
    }
}
