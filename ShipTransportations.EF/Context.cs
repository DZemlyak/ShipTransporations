using System;
using System.Collections.Generic;
using System.Data.Entity;
using ShipTransportations.EF.Mapping;
using ShipTransportations.Model.Model;

namespace ShipTransportations.EF
{
    public class Context : DbContext
    {
        public Context() : base("PortConnectionString") {
            Database.SetInitializer(new PortDBInitializer());
        }
        
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaptainMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new CargoTypeMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new PortMap());
            modelBuilder.Configurations.Add(new ShipMap());
            modelBuilder.Configurations.Add(new TripMap());

            modelBuilder.Entity<Ship>().HasMany(t => t.Captains)
                .WithRequired(t => t.Ship).HasForeignKey(t => t.ShipId);

            modelBuilder.Entity<City>().HasMany(t => t.Ports)
                .WithRequired(t => t.City).HasForeignKey(t => t.CityId);

            modelBuilder.Entity<Port>().HasMany(t => t.Ships)
                .WithRequired(t => t.Port).HasForeignKey(t => t.PortId);

            modelBuilder.Entity<Port>().HasMany(t => t.Trips)
                .WithRequired(t => t.PortFrom).HasForeignKey(t => t.PortIdFrom);

            modelBuilder.Entity<Port>().HasMany(t => t.Trips)
                .WithRequired(t => t.PortTo).HasForeignKey(t => t.PortIdTo);

            modelBuilder.Entity<Ship>().HasMany(t => t.Trips)
                .WithOptional(t => t.Ship).HasForeignKey(t => t.ShipId);

            modelBuilder.Entity<Captain>().HasMany(t => t.Trips)
               .WithRequired(t => t.Captain).HasForeignKey(t => t.CaptainId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>().HasMany(t => t.Cargos)
               .WithRequired(t => t.Trip).HasForeignKey(t => t.TripId);

            modelBuilder.Entity<CargoType>().HasMany(t => t.Cargos)
               .WithRequired(t => t.CargoType).HasForeignKey(t => t.TypeId);
            
            base.OnModelCreating(modelBuilder);
        }

        protected class PortDBInitializer : CreateDatabaseIfNotExists<Context> {
            protected override void Seed(Context context) {
                IList<City> cities = new List<City>();
                cities.Add(new City { Name = "Odessa" });
                cities.Add(new City { Name = "Sevastopol" });
                cities.Add(new City { Name = "New York" });
                cities.Add(new City { Name = "Istambul" });
                foreach (var city in cities)
                    context.Cities.Add(city);
                context.SaveChanges();

                IList<Port> ports = new List<Port>();
                ports.Add(new Port { Name = "Odessa Port", CityId = 1 });
                ports.Add(new Port { Name = "Sevastopol Port", CityId = 2 });
                ports.Add(new Port { Name = "New York Port", CityId = 3 });
                ports.Add(new Port { Name = "Istambul Port", CityId = 4 });
                foreach (var port in ports)
                    context.Ports.Add(port);
                context.SaveChanges();

                IList<Ship> ships = new List<Ship>();
                ships.Add(new Ship {
                    Capacity = 50, PortId = 1, Number = 1502,
                    CreateDate = DateTime.Parse("2004.5.4"),
                    MaxDistance = 5000, CrewSize = 25
                });
                ships.Add(new Ship {
                    Capacity = 75, PortId = 3, Number = 1762,
                    CreateDate = DateTime.Parse("2006.5.10"),
                    MaxDistance = 7500, CrewSize = 45
                });
                ships.Add(new Ship {
                    Capacity = 100, PortId = 4, Number = 5348,
                    CreateDate = DateTime.Parse("2009.10.10"),
                    MaxDistance = 12000, CrewSize = 80
                });
                foreach (var ship in ships)
                    context.Ships.Add(ship);
                context.SaveChanges();

                IList<Captain> captains = new List<Captain>();
                captains.Add(new Captain { FirstName = "Tom", LastName = "Jones", ShipId = 1 });
                captains.Add(new Captain { FirstName = "Mark", LastName = "Richards", ShipId = 2 });
                captains.Add(new Captain { FirstName = "Henry", LastName = "York", ShipId = 3 });
                foreach (var captain in captains)
                    context.Captains.Add(captain);

                IList<CargoType> cargoTypes = new List<CargoType>();
                cargoTypes.Add(new CargoType { Name = "Wood" });
                cargoTypes.Add(new CargoType { Name = "Furniture" });
                cargoTypes.Add(new CargoType { Name = "People" });
                cargoTypes.Add(new CargoType { Name = "Flowers" });

                base.Seed(context);
            }
        }
    }
}
