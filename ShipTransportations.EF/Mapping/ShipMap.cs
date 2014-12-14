using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class ShipMap : EntityTypeConfiguration<Ship>
    {
        public ShipMap()
        {
            HasKey(t => t.ShipId);

            Property(t => t.PortId)
                .IsRequired();
            Property(t => t.Number)
                .IsOptional();
            Property(t => t.Capacity)
                .IsOptional();
            Property(t => t.CreateDate)
                .IsOptional();
            Property(t => t.MaxDistance)
                .IsOptional();
            Property(t => t.CrewSize)
                .IsOptional();

            ToTable("Ship");
            Property(t => t.ShipId).HasColumnName("ShipID");
            Property(t => t.PortId).HasColumnName("PortID");
            Property(t => t.Capacity).HasColumnName("Capacity");
            Property(t => t.Number).HasColumnName("Number");
            Property(t => t.CreateDate).HasColumnName("CreateDate");
            Property(t => t.MaxDistance).HasColumnName("MaxDistance");
            Property(t => t.CrewSize).HasColumnName("CrewSize");

        }

    }
}
