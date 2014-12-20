using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Validators
{
    public class CaptainValidator : IValidator<Captain>
    {
        public bool IsValid(Captain baseEntityObject)
        {
            return Context.GetContext().Captains
                .Any(t => t.ShipId == baseEntityObject.ShipId);
        }
    }
}
