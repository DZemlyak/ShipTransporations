using System;
using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class ShipValidator : IValidator<Ship>
    {
        public bool IsValid(Ship baseEntityObject) {
            return Context.GetContext().Ports.Any(t => t.Id == baseEntityObject.PortId) 
                && baseEntityObject.CreateDate < DateTime.Now;
        }
    }
}
