using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            HasKey(t => t.CityId);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("City");
            Property(t => t.CityId).HasColumnName("CityID");
            Property(t => t.Name).HasColumnName("Name");
        }

    }
}
