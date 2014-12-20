using System.Collections.Generic;

namespace ShipTransportations.Model.Model
{
    public class CargoType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; } 

        public override string ToString()
        {
            return string.Format("\nTypeID: {0}\nName: {1}", Id, Name);
        }
    }
}
