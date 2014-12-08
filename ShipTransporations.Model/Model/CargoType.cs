namespace ShipTransportations.Model.Model
{
    public class CargoType
    {
        public int TypeId { get; set; }
        public string Name { get; set; }

        public CargoType(int typeId, string name)
        {
            TypeId = typeId;
            Name = name;
        }
        public CargoType() { }

        public override string ToString()
        {
            return string.Format("\nTypeID: {0}\nName: {1}", TypeId, Name);
        }
    }
}
