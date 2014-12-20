using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class PortMap : EntityTypeConfiguration<Port>
    {
        public PortMap()
        {
            HasKey(t => t.Id);
            HasMany(t => t.Ships)
                .WithRequired(t => t.Port).HasForeignKey(t => t.PortId);
            HasMany(t => t.Trips)
                .WithRequired(t => t.PortFrom).HasForeignKey(t => t.PortIdFrom);
            HasMany(t => t.Trips)
                .WithRequired(t => t.PortTo).HasForeignKey(t => t.PortIdTo);
            Property(t => t.CityId)
                .IsRequired();
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("Port");
            Property(t => t.CityId).HasColumnName("CityID");
            Property(t => t.Id).HasColumnName("PortID");
            Property(t => t.Name).HasColumnName("Name");

        }
    }
}
