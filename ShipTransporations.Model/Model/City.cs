namespace ShipTransportations.Model.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public City(int cityId, string name)
        {
            CityId = cityId;
            Name = name;
        }
        public City() { }

        public override string ToString() {
            return string.Format("\nCityID: {0}\nName: {1}", CityId, Name);
        }
    }
}
