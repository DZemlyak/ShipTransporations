using System.Collections.Generic;

namespace ShipTransportations.Model.Model
{
    public class Port : BaseEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Ship> Ships { get; set; }

        public override string ToString() {
            return string.Format("\nPortID: {0}\nCityID: {1}\nName: {2}", Id, CityId, Name);
        }
    }
}
