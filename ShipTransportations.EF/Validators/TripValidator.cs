using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class TripValidator : IValidator<Trip>
    {
        public bool IsValid(Trip baseEntityObject)
        {
            if (baseEntityObject.PortIdFrom == baseEntityObject.PortIdTo)
                return false;
            if (Context.GetContext().Captains.All(t => t.Id != baseEntityObject.CaptainId))
                return false;
            if (Context.GetContext().Ships.All(t => t.Id != baseEntityObject.ShipId))
                return false;
            if (Context.GetContext().Ports.All(t => t.Id != baseEntityObject.PortIdFrom 
                    || t.Id != baseEntityObject.PortIdTo))
                return false;
            return true;
        }
    }
}
