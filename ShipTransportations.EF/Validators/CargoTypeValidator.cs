using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class CargoTypeValidator : IValidator<CargoType>
    {
        public bool IsValid(CargoType baseEntityObject)
        {
            return Context.GetContext().CargoTypes
                .All(t => t.Name != baseEntityObject.Name);
        }
    }
}
