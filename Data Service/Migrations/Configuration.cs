//using System.Collections.Generic;

//namespace Data_Service.Migrations
//{
//    using Enums;
//    using Models;
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<DataService.DataContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(DataService.DataContext context)
//        {
//            var saltForUser = PasswordHandler.CreateSalt();
//            var saltForUser2 = PasswordHandler.CreateSalt();
//            var saltForUser3 = PasswordHandler.CreateSalt();
//            var saltForUser4 = PasswordHandler.CreateSalt();

//            var users = new List<User>
//            {
//            };

//            //var regions = new List<Region>
//            //{
//            //    new Region { Id = 1, Name = "Örebro" },
//            //    new Region { Id = 2, Name = "Askersund" },
//            //    new Region { Id = 3, Name = "Stockholm Norra" },
//            //    new Region { Id = 4, Name = "Stockholm Södra" },
//            //    new Region { Id = 5, Name = "Uppland" },
//            //    new Region { Id = 6, Name = "Gävle" },
//            //    new Region { Id = 7, Name = "Dalarna" },
//            //    new Region { Id = 8, Name = "Kopparberg" },
//            //    new Region { Id = 9, Name = "Hällefors" },
//            //    new Region { Id = 10, Name = "Nyköping" },
//            //    new Region { Id = 11, Name = "Norrköping" },
//            //    new Region { Id = 12, Name = "Linköping" },
//            //    new Region { Id = 13, Name = "Lidköping" },
//            //    new Region { Id = 14, Name = "Värmland" },
//            //    new Region { Id = 15, Name = "LF Lantbruk" },
//            //    new Region { Id = 16, Name = "Övriga" },
//            //    new Region { Id = 17, Name = "Kemsortering" },
//            //};

//            //var customers = new List<Customer>
//            //{
//            //    new Customer { Id = 1, CustNumber = "1122", Name = "Kunden Marcus", Adress = "Storvägen 99", City = "999 99 Örebro", CorporateIdentity = "999999-9999", Reports = new List<Report>()},
//            //    new Customer { Id = 2, CustNumber = "2555", Name = "Kunden Rickard", Adress = "Storvägen 99", City = "999 99 Örebro", CorporateIdentity = "999999-9999", Reports = new List<Report>() },
//            //    new Customer { Id = 3, CustNumber = "3344", Name = "Kunden Michel", Adress = "Storvägen 99", City = "999 99 Örebro", CorporateIdentity = "999999-9999", Reports = new List<Report>() }
//            //};

//            //var transporters = new List<Transporter>
//            //{
//            //    new Transporter { Id = 1, Name = "Company Miljöhantering AB", Adress = "Skoftesta Gård", City = "692 93 Kumla", CorporateIdentity = "556239-5383", Reports = new List<Report>() }
//            //};

//            //var recievers = new List<Reciever>
//            //{
//            //    new Reciever { Id = 1, Name = "Company Miljöhantering AB", Adress = "Skoftesta Gård", City = "692 93 Kumla", CorporateIdentity = "556239-5383", Reports = new List<Report>() }
//            //};

//            //var vessels = new List<Vessel>
//            //{
//            //    new Vessel {Id = 1, Type = "Box 500 lit", PalletSpace = 1},
//            //    new Vessel {Id = 2, Type = "Dunk", PalletSpace = 0},
//            //    new Vessel {Id = 3, Type = "Fat", PalletSpace = (decimal)0.5},
//            //    new Vessel {Id = 4, Type = "Fat lockat", PalletSpace = (decimal)0.5},
//            //    new Vessel {Id = 5, Type = "IBC 600 lit", PalletSpace = 1},
//            //    new Vessel {Id = 6, Type = "IBC 1000 lit", PalletSpace = (decimal)1.5},
//            //    new Vessel {Id = 7, Type = "K-1300", PalletSpace = (decimal)1.5},
//            //    new Vessel {Id = 8, Type = "Kartong", PalletSpace = 0},
//            //    new Vessel {Id = 9, Type = "Kärl 190 lit", PalletSpace = (decimal)0.5},
//            //    new Vessel {Id = 10, Type = "Kärl 21 lit", PalletSpace = 0},
//            //    new Vessel {Id = 11, Type = "Kärl 370 lit", PalletSpace = (decimal)0.5},
//            //    new Vessel {Id = 12, Type = "Kärl 40 lit", PalletSpace = 0},
//            //    new Vessel {Id = 13, Type = "Kärl 829 lit", PalletSpace = (decimal)1.5},
//            //    new Vessel {Id = 14, Type = "M-800", PalletSpace = 1},
//            //    new Vessel {Id = 15, Type = "Wofe 1000 lit", PalletSpace = 1},
//            //    new Vessel {Id = 16, Type = "Maxibox", PalletSpace = (decimal)1.5},
//            //    new Vessel {Id = 17, Type = "Miljöbox", PalletSpace = 1},
//            //    new Vessel {Id = 18, Type = "Miljöförråd", PalletSpace = 6},
//            //    new Vessel {Id = 19, Type = "Miljöskåp mellan", PalletSpace = 4},
//            //    new Vessel {Id = 20, Type = "Miljöskåp lilla", PalletSpace = 2},
//            //    new Vessel {Id = 21, Type = "Nätvagn", PalletSpace = 1},
//            //    new Vessel {Id = 22, Type = "Pall", PalletSpace = 1},
//            //    new Vessel {Id = 23, Type = "Slambox", PalletSpace = (decimal)1.5},
//            //    new Vessel {Id = 24, Type = "Säck", PalletSpace = 1},
//            //    new Vessel {Id = 25, Type = "Annat", PalletSpace = 0},
//            //};

//            //var reports = new List<Report>
//            //{
//            //    new Report
//            //    {
//            //        Id = 1, Approved = false, CreatedBy = users.Find(x => x.Id == 8), Region = regions.Find(x => x.Id == 3), LastEditBy = "micish",
//            //        CustomerId = customers.Find(x => x.Id == 1).Id, CreatedDate = DateTime.Now, RemovedDate = null, EditedDate = DateTime.Now,
//            //        OrderedDate = DateTime.Now, Info = "Report1", RecieverId = 1, TransporterId = 1
//            //    },
//            //    new Report
//            //    {
//            //        Id = 2, Approved = false, CreatedBy = users.Find(x => x.Id == 8), Region = regions.Find(x => x.Id == 4), LastEditBy = "micish",
//            //        CustomerId = customers.Find(x => x.Id == 2).Id, CreatedDate = DateTime.Now, RemovedDate = null, EditedDate = DateTime.Now,
//            //        OrderedDate = DateTime.Now, Info = "Report2", RecieverId = 1, TransporterId = 1
//            //    },
//            //    new Report
//            //    {
//            //        Id = 3, Approved = false, CreatedBy = users.Find(x => x.Id == 8), Region = regions.Find(x => x.Id == 5), LastEditBy = "micish",
//            //        CustomerId = customers.Find(x => x.Id == 3).Id, CreatedDate = DateTime.Now, RemovedDate = null, EditedDate = DateTime.Now,
//            //        OrderedDate = DateTime.Now, Info = "Test", RecieverId = 1, TransporterId = 1
//            //    },
//            //    new Report
//            //    {
//            //        Id = 4, Approved = false, CreatedBy = users.Find(x => x.Id == 8), Region = regions.Find(x => x.Id == 6), LastEditBy = "rickam",
//            //        CustomerId = customers.Find(x => x.Id == 3).Id, CreatedDate = DateTime.Now, RemovedDate = null, EditedDate = DateTime.Now,
//            //        OrderedDate = DateTime.Now, Info = "Super rapporten.", RecieverId = 1, TransporterId = 1
//            //    }
//            //};



//            //customers.ForEach(x => context.Customers.Add(x));
//            //transporters.ForEach(x => context.Transporters.Add(x));
//            //recievers.ForEach(x => context.Recievers.Add(x));
//            //regions.ForEach(x => context.Regions.Add(x));
//            users.ForEach(x => context.Users.Add(x));
//            //reports.ForEach(x => context.Reports.Add(x));
//            //vessels.ForEach(x => context.Vessels.Add(x));

//            context.SaveChanges();
//        }
//    }
//}
