using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class CargoTypeMap : EntityTypeConfiguration<CargoType>
    {
        public CargoTypeMap()
        {
            HasKey(t => t.TypeId);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("CargoType");
            Property(t => t.TypeId).HasColumnName("CargoTypeID");
            Property(t => t.Name).HasColumnName("Name");
        }

    }
}
