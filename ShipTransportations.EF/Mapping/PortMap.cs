using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class PortMap : EntityTypeConfiguration<Port>
    {
        public PortMap()
        {
            HasKey(t => t.PortId);

            Property(t => t.CityId)
                .IsRequired();
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("Port");
            Property(t => t.CityId).HasColumnName("CityID");
            Property(t => t.PortId).HasColumnName("PortID");
            Property(t => t.Name).HasColumnName("Name");

        }
    }
}
