using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class CargoValidator : IValidator<Cargo>
    {
        public bool IsValid(Cargo baseEntityObject)
        {
            return Context.GetContext().CargoTypes.Any(t => t.Id == baseEntityObject.TypeId)
                && Context.GetContext().Trips.Any(t => t.Id == baseEntityObject.TripId);
        }
    }
}
