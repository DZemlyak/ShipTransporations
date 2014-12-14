namespace ShipTransportations.Model.Model
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public int TypeId { get; set; }
        public int TripId { get; set; }
        public int Number { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public double InsurancePrice { get; set; }

        public virtual CargoType CargoType { get; set; }
        public virtual Trip Trip { get; set; }

        public override string ToString() {
            return string.Format("\nCargoID: {0}\nTypeID: {1}\nTripID: {2}\nNumber: {3}\nWeight: {4}\nPrice: {5}" +
                                 "\nInsurancePrice: {6}", CargoId, TypeId, TripId, Number, 
                                 Weight, Price, InsurancePrice);
        }
    }
}
