using System.Collections.Generic;

namespace ShipTransportations.Model.Model
{
    public class Captain : BaseEntity
    {
        public int ShipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Ship Ship { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public override string ToString() {
            return string.Format("\nCaptainID: {0}\nShipID: {1}\nFirstName: {2}\nLastName: {3}",
                Id, ShipId, FirstName, LastName);
        }
    }
}
