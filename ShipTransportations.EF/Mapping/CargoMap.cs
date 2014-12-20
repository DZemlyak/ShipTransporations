using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            HasKey(t => t.Id);

            Property(t => t.TypeId)
                .IsRequired();
            Property(t => t.TripId)
                .IsRequired();
            Property(t => t.Number)
                .IsOptional();
            Property(t => t.Weight)
                .IsOptional();
            Property(t => t.Price)
                .IsOptional();
            Property(t => t.InsurancePrice)
                .IsOptional();
            
            ToTable("Cargo");
            Property(t => t.Id).HasColumnName("CargoID");
            Property(t => t.TypeId).HasColumnName("TypeID");
            Property(t => t.TripId).HasColumnName("TripID");
            Property(t => t.Number).HasColumnName("Number");
            Property(t => t.Weight).HasColumnName("Weight");
            Property(t => t.Price).HasColumnName("Price");
            Property(t => t.InsurancePrice).HasColumnName("InsurancePrice");

        }

    }
}
