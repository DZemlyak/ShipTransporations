using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class PortValidator : IValidator<Port>
    {
        public bool IsValid(Port baseEntityObject) {
            return Context.GetContext().Ports.All(t => t.Name != baseEntityObject.Name)
                && Context.GetContext().Cities.Any(t => t.Id == baseEntityObject.CityId);
        }
    }
}
