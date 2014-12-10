using System;
using System.Linq;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Model.Model
{
    public class Cargo
    {
        private int _typeId;
        private int _tripId;

        public int CargoId { get; set; }
        public int TypeId { 
            get { return _typeId; }
            set {
                if (RepositoryHelper.CargoTypesRepository.ReadAll().All(a => a.TypeId != value))
                    throw new Exception(string.Format("\nCan't find specified TypeID : {0}.", value));
                _typeId = value;
            }
        }
        public int TripId {
            get { return _tripId; }
            set {
                if (RepositoryHelper.TripRepositiry.ReadAll().All(a => a.TripId != value))
                    throw new Exception(string.Format("\nCan't find specified TripID : {0}.", value));
                _tripId = value;
            }
        }
        public int Number { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
        public double InsurancePrice { get; set; }

        public override string ToString() {
            return string.Format("\nCargoID: {0}\nTypeID: {1}\nTripID: {2}\nNumber: {3}\nWeight: {4}\nPrice: {5}" +
                                 "\nInsurancePrice: {6}", CargoId, TypeId, TripId, Number, 
                                 Weight, Price, InsurancePrice);
        }
    }
}
