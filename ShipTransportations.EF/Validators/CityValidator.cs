using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class CityValidator : IValidator<City>
    {
        public bool IsValid(City baseEntityObject) {
            return Context.GetContext().Cities.All(t => t.Name != baseEntityObject.Name);
        }
    }
}
