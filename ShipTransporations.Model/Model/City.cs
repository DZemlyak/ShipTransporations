﻿using System.Collections.Generic;

namespace ShipTransportations.Model.Model
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Port> Ports { get; set; }

        public override string ToString() {
            return string.Format("\nCityID: {0}\nName: {1}", Id, Name);
        }
    }
}
