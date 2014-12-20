namespace ShipTransportations.EF
{
    public interface IValidator<T>
    {
        bool IsValid(T baseEntityObject);
    }
}
