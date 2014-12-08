using System.Configuration;

namespace ShipTransportations.Model.Repository
{
    public static class RepositoryHelper
    {
        internal static readonly string ConnStr = 
            ConfigurationManager.ConnectionStrings["PortDatabaseConnectionString"].ConnectionString;
        public static CaptainRepository CaptainRepository = new CaptainRepository();
        public static CargoRepository CargoRepository = new CargoRepository();
        public static CargoTypesRepository CargoTypesRepository = new CargoTypesRepository();
        public static CityRepository CityRepository = new CityRepository();
        public static PortRepository PortRepository = new PortRepository();
        public static ShipRepository ShipRepository = new ShipRepository();
        public static TripRepositiry TripRepositiry = new TripRepositiry();
    }
}
