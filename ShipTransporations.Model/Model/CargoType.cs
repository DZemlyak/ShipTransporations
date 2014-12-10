namespace ShipTransportations.Model.Model
{
    public class CargoType
    {
        public int TypeId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("\nTypeID: {0}\nName: {1}", TypeId, Name);
        }
    }
}
