using System.Data.Entity.ModelConfiguration;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF.Mapping
{
    class CaptainMap : EntityTypeConfiguration<Captain>
    {
        public CaptainMap()
        {
            HasKey(t => t.CaptainId);

            Property(t => t.ShipId)
                .IsOptional();

            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            ToTable("Captain");
            Property(t => t.CaptainId).HasColumnName("CaptainID");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.ShipId).HasColumnName("ShipID");
        }
    }
}
