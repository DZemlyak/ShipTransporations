using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class TripMap : EntityTypeConfiguration<Trip>
    {
        public TripMap()
        {
            HasKey(t => t.TripId);

            Property(t => t.CaptainId)
                .IsRequired();
            Property(t => t.ShipId)
                .IsOptional();
            Property(t => t.PortIdFrom)
                .IsRequired();
            Property(t => t.PortIdTo)
                .IsRequired();
            Property(t => t.StartDate)
                .IsOptional();
            Property(t => t.EndDate)
                .IsOptional();

            ToTable("Trip");
            Property(t => t.CaptainId).HasColumnName("CaptainID");
            Property(t => t.ShipId).HasColumnName("ShipID");
            Property(t => t.TripId).HasColumnName("TripID");
            Property(t => t.PortIdFrom).HasColumnName("PortIDFrom");
            Property(t => t.PortIdTo).HasColumnName("PortIDTo");
            Property(t => t.StartDate).HasColumnName("StartDate");
            Property(t => t.EndDate).HasColumnName("EndDate");

        }

    }
}
