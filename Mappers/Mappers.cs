using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Contracts;
using Enums;
using FlexInfoModels;

namespace Mappers
{
    public static class Mappers
    {
        #region Contracts

        #region ToContract
        public static UserContract ToContract(this User user)
        {

            return new UserContract
            {
                Username = user.Username,
                Permission = user.Permission,
                Id = user.Id
            };
        }

        public static RecieverContract ToContract(this Reciever reciever)
        {

            return new RecieverContract
            {
                Id = reciever.Id,
                Name = reciever.Name,
                City = reciever.City,
                Adress = reciever.Adress,
                CorporateIdentity = reciever.CorporateIdentity
            };
        }

        public static TransporterContract ToContract(this Transporter transporter)
        {

            return new TransporterContract
            {
                Id = transporter.Id,
                Name = transporter.Name,
                City = transporter.City,
                Adress = transporter.Adress,
                CorporateIdentity = transporter.CorporateIdentity
            };
        }

        public static CustomerContract ToContract(this Customer customer)
        {
            return new CustomerContract
            {
                Id = customer.Id,
                Name = customer.Name,
                City = customer.City,
                Adress = customer.Adress,
                CustNumber = customer.CustNumber,
                CorporateIdentity = customer.CorporateIdentity,
                Tel = customer.Tel
            };
        }

        public static RegionContract ToContract(this Region region)
        {

            return new RegionContract
            {
                Id = region.Id,
                Name = region.Name
            };
        }

        public static VesselContract ToContract(this Vessel vessel)
        {

            return new VesselContract
            {
                Id = vessel.Id,
                Type = vessel.Type,
                PalletSpace = vessel.PalletSpace
            };
        }

        public static ArticleContract ToContract(this Article article)
        {
            return new ArticleContract
            {
                Id = article.Id,
                Info = article.Info,
                Exchange = article.Exchange,
                Quantity = article.Quantity,
                WasteId = article.WasteId,
                Vessel = article.Vessel.ToContract(),
                ReportId = article.ReportId   
                // WasteObject??
            };
        }

        public static ReportContract ToContract(this Report report)
        {
            return new ReportContract
            {
                Id = report.Id,
                Approved = report.Approved,
                Articles = report.Articles.ToContracts(),
                CreatedByUserName = report.CreatedByUserName,
                CreatedDate = report.CreatedDate,
                Customer = report.Customer.ToContract(),
                EditedDate = report.EditedDate,
                Info = report.Info,
                LastEditBy = report.LastEditBy,
                OrderedDate = report.OrderedDate,
                Region = report.Region.ToContract(),
                Transporter = report.Transporter.ToContract(),
                Reciever = report.Reciever.ToContract(),
                RemovedDate = report.RemovedDate
            };
        }

        public static WasteContract ToContract(this ARTIKLAR waste)
        {
            return new WasteContract
            {
                Id = waste.ARTNR,
                Text = waste.TEXT,
                EuropeanWasteCatalogueCode = waste.SOKTEXT2,
                UnTextGroup = waste.unTextGroup,
            };
        }

        public static InfoFlexCustomerContract ToContract(this KUNDER infoFlexCustomer)
        {
            return new InfoFlexCustomerContract
            {
                CustNumber = infoFlexCustomer.KUNDNR,
                Name = infoFlexCustomer.LevNamn,
                City = infoFlexCustomer.LevPOSTADR,
                Adress = infoFlexCustomer.LevADR,
                CorporateIdentity = infoFlexCustomer.ORGNR,
                Tel = infoFlexCustomer.TEL
            };
        }

        #endregion
        ///////////////////////////////////////////////
        #region ToContracts
        public static List<UserContract> ToContracts(this List<User> users)
        {
            return users.ConvertAll(x => new UserContract
            {
                Username = x.Username,
                Permission = x.Permission,
                Id = x.Id
            });
        }

        public static List<RecieverContract> ToContracts(this List<Reciever> recievers)
        {
            return recievers.ConvertAll(x => new RecieverContract
            {
                Id = x.Id,
                City = x.City,
                Name = x.Name,
                Adress = x.Adress,
                CorporateIdentity = x.CorporateIdentity
            });
        }

        public static List<TransporterContract> ToContracts(this List<Transporter> transporters)
        {
            return transporters.ConvertAll(x => new TransporterContract
            {
                Id = x.Id,
                City = x.City,
                Name = x.Name,
                Adress = x.Adress,
                CorporateIdentity = x.CorporateIdentity
            });
        }

        public static List<CustomerContract> ToContracts(this List<Customer> customers)
        {
            return customers.ConvertAll(x => new CustomerContract
            {
                Id = x.Id,
                City = x.City,
                Name = x.Name,
                Adress = x.Adress,
                CustNumber = x.CustNumber,
                CorporateIdentity = x.CorporateIdentity,
                Tel = x.Tel
            });
        }

        public static List<RegionContract> ToContracts(this List<Region> regions)
        {

            return regions.ConvertAll(x => new RegionContract
            {
                Id = x.Id,
                Name = x.Name,
            });
        }

        public static List<VesselContract> ToContracts(this List<Vessel> vessels)
        {

            return vessels.ConvertAll(x => new VesselContract
            {
                Id = x.Id,
                Type = x.Type,
                PalletSpace = x.PalletSpace,
            });
        }

        public static List<ArticleContract> ToContracts(this List<Article> articles)
        {

            return articles.ConvertAll(x => new ArticleContract
            {
                Id = x.Id,
                Exchange = x.Exchange,
                Info = x.Info,
                Quantity = x.Quantity,
                Vessel = x.Vessel.ToContract(),
                WasteId = x.WasteId,
                ReportId = x.ReportId


            });
        }

        public static List<ReportContract> ToContracts(this List<Report> reports)
        {
            return reports.ConvertAll(x => new ReportContract
            {
                Id = x.Id,
                Approved = x.Approved,
                Articles = x.Articles.ToContracts(),
                CreatedByUserName = x.CreatedByUserName,
                CreatedDate = x.CreatedDate,
                Customer = x.Customer.ToContract(),
                EditedDate = x.EditedDate,
                Info = x.Info,
                LastEditBy = x.LastEditBy,
                OrderedDate = x.OrderedDate,
                Region = x.Region.ToContract(),
                Transporter = x.Transporter.ToContract(),
                Reciever = x.Reciever.ToContract(),
                RemovedDate = x.RemovedDate,
            });
        }

         public static List<WasteContract> ToContracts(this List<ARTIKLAR> wastes)
        {
            return wastes.ConvertAll(x => new WasteContract
            {
                Id = x.ARTNR,
                Text = x.TEXT,
                EuropeanWasteCatalogueCode = x.SOKTEXT2,
                UnTextGroup = x.unTextGroup,
            });
        }

        public static List<InfoFlexCustomerContract> ToContracts(this List<KUNDER> infoFlexCustomers)
        {
            return infoFlexCustomers.ConvertAll(x => new InfoFlexCustomerContract
            {
                CustNumber = x.KUNDNR,
                Name = x.LevNamn,
                City = x.LevPOSTADR,
                Adress = x.LevADR,
                CorporateIdentity = x.ORGNR,
                Tel = x.TEL
            });
        }

        #endregion

        #region ToEntity

        public static User ToEntity(this UserContract user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Permission = user.Permission
            };
        }

        public static Reciever ToEntity(this RecieverContract reciever)
        {
            return new Reciever
            {
                Id = reciever.Id,
                Adress = reciever.Adress,
                City = reciever.City,
                CorporateIdentity = reciever.CorporateIdentity,
                Name = reciever.Name
            };
        }

        public static Transporter ToEntity(this TransporterContract transporter)
        {
            return new Transporter
            {
                Id = transporter.Id,
                Adress = transporter.Adress,
                City = transporter.City,
                CorporateIdentity = transporter.CorporateIdentity,
                Name = transporter.Name
            };
        }

        public static Customer ToEntity(this CustomerContract customer)
        {
            return new Customer
            {
                Id = customer.Id,
                City = customer.City,
                Name = customer.Name,
                Adress = customer.Adress,
                CustNumber = customer.CustNumber,
                CorporateIdentity = customer.CorporateIdentity,
                Tel = customer.Tel
            };
        }

        public static Region ToEntity(this RegionContract region)
        {
            return new Region
            {
                Id = region.Id,
                Name = region.Name,
            };
        }

        public static Vessel ToEntity(this VesselContract vessel)
        {
            return new Vessel
            {
                Id = vessel.Id,
                Type = vessel.Type,
                PalletSpace = vessel.PalletSpace,
            };
        }

        public static Article ToEntity(this ArticleContract article)
        {
            return new Article
            {
                Id = article.Id,
                Info = article.Info,
                Exchange = article.Exchange,
                Quantity = article.Quantity,
                VesselId = article.Vessel.Id,
                WasteId = article.Waste.Id,
                ReportId = article.ReportId
            };
        }

        public static Report ToEntity(this ReportContract report)
        {
            return new Report
            {
                Id = report.Id,
                Info = report.Info,
                Approved = report.Approved,
                CreatedDate = report.CreatedDate,
                EditedDate = report.EditedDate,
                LastEditBy = report.LastEditBy,
                OrderedDate = report.OrderedDate,
                RemovedDate = report.RemovedDate,
                Articles = report.Articles.ToEntities(),
                CreatedByUserName = report.CreatedByUserName,
                CustomerId = report.Customer.Id,
                RegionId = report.Region.Id,
                TransporterId = report.Transporter.Id,
                RecieverId = report.Reciever.Id,

            };
        }

        public static ARTIKLAR ToEntity(this WasteContract wasteContract)
        {
            return new ARTIKLAR
            {
                ARTNR = wasteContract.Id,
                TEXT = wasteContract.Text,
                SOKTEXT2 = wasteContract.EuropeanWasteCatalogueCode,
                unTextGroup = wasteContract.UnTextGroup,
            };
        }

        public static KUNDER ToEntity(this InfoFlexCustomerContract infoFlexCustomerContract)
        {
            return new KUNDER
            {
                KUNDNR = infoFlexCustomerContract.CustNumber.ToString(),
                LevNamn = infoFlexCustomerContract.Name,
                LevPOSTADR = infoFlexCustomerContract.City,
                LevADR = infoFlexCustomerContract.Adress,
                ORGNR = infoFlexCustomerContract.CorporateIdentity,
                TEL = infoFlexCustomerContract.Tel
            };
        }

        #endregion
        //////////////////////////////////////////////////
        #region ToEntities

        public static List<User> ToEntities(this List<UserContract> users)
        {
            return users.ConvertAll(x => new User
            {
                Id = x.Id,
                Username = x.Username,
                Permission = x.Permission
            });
        }

        public static List<Reciever> ToEntities(this List<RecieverContract> recievers)
        {
            return recievers.ConvertAll(x => new Reciever
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Adress = x.Adress,
                CorporateIdentity = x.CorporateIdentity,
            });
        }

        public static List<Transporter> ToEntities(this List<TransporterContract> transporters)
        {
            return transporters.ConvertAll(x => new Transporter
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Adress = x.Adress,
                CorporateIdentity = x.CorporateIdentity,
            });
        }

        public static List<Customer> ToEntities(this List<CustomerContract> customers)
        {
            return customers.ConvertAll(x => new Customer
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Adress = x.Adress,
                CorporateIdentity = x.CorporateIdentity,
                CustNumber = x.CustNumber,
                Tel = x.Tel,
            });
        }

        public static List<Region> ToEntities(this List<RegionContract> regions)
        {
            return regions.ConvertAll(x => new Region
            {
                Id = x.Id,
                Name = x.Name,
            });
        }

        public static List<Vessel> ToEntities(this List<VesselContract> vessels)
        {
            return vessels.ConvertAll(x => new Vessel
            {
                Id = x.Id,
                Type = x.Type,
                PalletSpace = x.PalletSpace,
            });
        }

        public static List<Article> ToEntities(this List<ArticleContract> articles)
        {
            if (articles.Any(x => x.Vessel == null))
            {
                return null;
            }
            return articles.ConvertAll(x => new Article
            {
                Id = x.Id,
                Info = x.Info,
                Exchange = x.Exchange,
                Quantity = x.Quantity,
                VesselId = x.Vessel.Id,
                WasteId = x.Waste.Id,
                ReportId = x.ReportId
            });
        }

        public static List<Report> ToEntities(this List<ReportContract> reports)
        {
            return reports.ConvertAll(x => new Report
            {
                Id = x.Id,
                Info = x.Info,
                Approved = x.Approved,
                CreatedDate = x.CreatedDate,
                EditedDate = x.EditedDate,
                LastEditBy = x.LastEditBy,
                OrderedDate = x.OrderedDate,
                RemovedDate = x.RemovedDate,
                Articles = x.Articles.ToEntities(),
                CreatedByUserName = x.CreatedByUserName,
                CustomerId = x.Customer.Id,
                RegionId = x.Region.Id,
                TransporterId = x.Transporter.Id,
                RecieverId = x.Reciever.Id,
            });
        }

        public static List<ARTIKLAR> ToEntities(this List<WasteContract> wasteContracts)
        {
            return wasteContracts.ConvertAll(x => new ARTIKLAR
            {
                ARTNR = x.Id,
                TEXT = x.Text,
                SOKTEXT2 = x.EuropeanWasteCatalogueCode,
                unTextGroup = x.UnTextGroup
            });
        }

        public static List<KUNDER> ToEntities(this List<InfoFlexCustomerContract> infoFlexCustomerContracts)
        {
            return infoFlexCustomerContracts.ConvertAll(x => new KUNDER
            {
                KUNDNR = x.CustNumber.ToString(),
                LevNamn = x.Name,
                LevPOSTADR = x.City,
                LevADR = x.Adress,
                ORGNR = x.CorporateIdentity,
                TEL = x.Tel
            });
        }
        #endregion

        #endregion
    }
}
