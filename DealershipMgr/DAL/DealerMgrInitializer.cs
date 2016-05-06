using DealershipMgr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Dealership.DAL
{
    public class DealerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DealerMgrContext>
    {
        // Takes the datbase context object as an input parameter
        // Code uses the object to add new entities to the database
        protected override void Seed(DealerMgrContext context)
        {
            var salespersons = new List<Salesperson>
            {
                new Salesperson{FirstName="Carson",LastName="Alexander",HireDate=DateTime.Parse("2015-04-05"),SalesYtd=112458,SalesGoal=115000,MetSalesGoal=false},
                new Salesperson{FirstName="Meredith",LastName="Alonso",HireDate=DateTime.Parse("2010-05-01"),SalesYtd=117264,SalesGoal=115000,MetSalesGoal=true},
                new Salesperson{FirstName="Arturo",LastName="Anand",HireDate=DateTime.Parse("2005-07-10"),SalesYtd=122982,SalesGoal=115000,MetSalesGoal=true},
                new Salesperson{FirstName="Gytis",LastName="Barzdukas",HireDate=DateTime.Parse("2012-09-01"),SalesYtd=98276,SalesGoal=115000,MetSalesGoal=false},
                new Salesperson{FirstName="Yan",LastName="Li",HireDate=DateTime.Parse("2006-10-27"),SalesYtd=89365,SalesGoal=115000,MetSalesGoal=false},
                new Salesperson{FirstName="Peggy",LastName="Justice",HireDate=DateTime.Parse("2014-08-15"),SalesYtd=116924,SalesGoal=115000,MetSalesGoal=true},
                new Salesperson{FirstName="Laura",LastName="Norman",HireDate=DateTime.Parse("2008-11-15"),SalesYtd=108925,SalesGoal=115000,MetSalesGoal=false},
                new Salesperson{FirstName="Nino",LastName="Olivetto",HireDate=DateTime.Parse("2011-12-01"),SalesYtd=106926,SalesGoal=115000,MetSalesGoal=false}
            };
            // For each entity type, code creates a collection of new entities, adds them to the
            // appropriate DbSet property, then saves the changes to the database
            salespersons.ForEach(s => context.Salespersons.Add(s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{FirstName="John",LastName="Smith",RelationshipDate=DateTime.Parse("2015-04-05"),PurchasesToDate=39999,City="Indianapolis",PhoneNumber=3171234567,Email="myemail@gmail.com"},
                new Client{FirstName="Jane",LastName="Doe",RelationshipDate=DateTime.Parse("2013-04-05"),PurchasesToDate=31999,City="Indianapolis",PhoneNumber=3179876543,Email="myotheremail@gmail.com"}
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var vehicles = new List<Vehicle>
            {
                new Vehicle{VehicleYear=2016,VehicleMake="Ford",VehicleModel="Mustang",VehicleVIN="",Price=41999},
                new Vehicle{VehicleYear=2016,VehicleMake="Jeep",VehicleModel="Grand Cherokee",VehicleVIN="",Price=42999},
                new Vehicle{VehicleYear=2016,VehicleMake="Chevrolet",VehicleModel="Silverado",VehicleVIN="",Price=44999},
                new Vehicle{VehicleYear=2016,VehicleMake="Honda",VehicleModel="Accord",VehicleVIN="",Price=23999},
                new Vehicle{VehicleYear=2016,VehicleMake="Ford",VehicleModel="Explorer",VehicleVIN="",Price=29999},
                new Vehicle{VehicleYear=2016,VehicleMake="Jeep",VehicleModel="Wrangler",VehicleVIN="",Price=38999},
                new Vehicle{VehicleYear=2016,VehicleMake="Honda",VehicleModel="CRV",VehicleVIN="",Price=21999}
            };
            vehicles.ForEach(s => context.Vehicles.Add(s));
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region{RegionName="North",SalesYtd=2195364,SalesGoal=3200000,MetSalesGoal=false},
                new Region{RegionName="South",SalesYtd=28657396,SalesGoal=3200000,MetSalesGoal=false},
                new Region{RegionName="East",SalesYtd=2594723,SalesGoal=3200000,MetSalesGoal=false},
                new Region{RegionName="West",SalesYtd=3034927,SalesGoal=3200000,MetSalesGoal=false},
            };
            regions.ForEach(s => context.Regions.Add(s));
            context.SaveChanges();

            var managers = new List<Manager>
            {
                new Manager{FirstName="Mike",LastName="Young",HireDate=DateTime.Parse("2011-04-05")},
                new Manager{FirstName="Billie",LastName="Koger",HireDate=DateTime.Parse("2013-06-05")}
            };
            managers.ForEach(s => context.Managers.Add(s));
            context.SaveChanges();

            var locations = new List<Location>
            {
                new Location{LocationName="Indianapolis"},
                new Location{LocationName="Greenwood"}
            };
            locations.ForEach(s => context.Locations.Add(s));
            context.SaveChanges();
        }
    }
}