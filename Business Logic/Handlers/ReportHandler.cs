using System;
using Data_Service.Unit_of_Work;
using DataService;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Data_Service.Info_Flex.Repositories;
using Mappers;
using Models;

namespace Business_Logic.Handlers
{
    public class ReportHandler
    {
        private readonly UnitOfWork _uow;
        private readonly WasteRepository _wasteRepo;

        public ReportHandler()
        {
            _wasteRepo = new WasteRepository();
            _uow = new UnitOfWork(new DataContext());
        }

        public List<ReportContract> Get()
        {
            return _uow.ReportRepository.GetAll().ToContracts();
        }

        public ReportContract Get(int id)
        {
            return _uow.ReportRepository.Get(x => x.Id == id).FirstOrDefault().ToContract();
        }

        public List<ReportContract> GetReportsFromCustomerNameSearch(string customerName, int fromHistory)
        {
            return fromHistory == 1 ? _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Customer.Name.ToLower().Contains(customerName.ToLower())).ToList() : 
                _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Customer.Name.ToLower().Contains(customerName.ToLower()) && x.Approved == false).ToList();
        }

        public List<ReportContract> GetReportsFromCustomerCitySearch(string customerCity, int fromHistory)
        {
            return fromHistory == 1 ? _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Customer.City.ToLower().Contains(customerCity.ToLower())).ToList() : 
                _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Customer.City.ToLower().Contains(customerCity.ToLower()) && x.Approved == false).ToList();
        }

        public List<ReportContract> GetReportsFromInfoSearch(string info, int fromHistory)
        {
            return fromHistory == 1 ? _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Info.ToLower().Contains(info.ToLower())).ToList() : 
                _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Info.ToLower().Contains(info.ToLower()) && x.Approved == false).ToList();
        }

        public List<ReportContract> GetReportsFromIdSearch(string id, int fromHistory)
        {
            return fromHistory == 1 ? _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Id.ToString().Contains(id)).ToList() : 
                _uow.ReportRepository.GetAll().ToContracts().Where(x => x.Id.ToString().Contains(id) && x.Approved == false).ToList();
        }

        public void Post(ReportContract reportContract)
        {
            var dbReport = reportContract.ToEntity();

            dbReport.CustomerId = DoesCustomerExist(reportContract.Customer);
            dbReport.RecieverId = DoesRecieverExist(reportContract.Reciever);
            dbReport.TransporterId = DoesTransporterExist(reportContract.Transporter);

            if (reportContract.Id != 0)
            {
                EditArticles(dbReport);
            }

            _uow.ReportRepository.CreateOrUpdate(dbReport);
        }

        public ReportContract EditReportRegion(int reportId, int regionId)
        {
            var reportToEdit = _uow.ReportRepository.Get(filter: x => x.Id == reportId).FirstOrDefault();
            var newRegion = _uow.RegionRepository.Get(filter: x => x.Id == regionId).FirstOrDefault();

            if (reportToEdit == null && newRegion == null) return null;

            var reportContract = reportToEdit.ToContract();
            var regionContract = newRegion.ToContract();

            reportContract.Region.Id = regionContract.Id;

            _uow.ReportRepository.CreateOrUpdate(reportContract.ToEntity());
            return reportContract;
        }

        public void EditArticles(Report report)
        {
            //var reportToEdit = _uow.ReportRepository.Get(filter: x => x.Id == reportContract.Id).FirstOrDefault();

            if (report != null)
            {
                foreach (var article in report.Articles)
                {
                    article.ReportId = report.Id;
                    _uow.ArticleRepository.CreateOrUpdate(article);
                }
            }
        }

        public int DoesRecieverExist(RecieverContract reciever)
        {
            var currentReciever = _uow.RecieverRepository.Get(p => p.CorporateIdentity == reciever.CorporateIdentity)
                .LastOrDefault();

            if (currentReciever == null ||
                !string.Equals(currentReciever.Name, reciever.Name, StringComparison.CurrentCultureIgnoreCase) ||
                !string.Equals(currentReciever.Adress, reciever.Adress, StringComparison.CurrentCultureIgnoreCase) ||
                !string.Equals(currentReciever.City, reciever.City, StringComparison.CurrentCultureIgnoreCase))
            {
                var newReciever = new Reciever
                {
                    Adress = reciever.Adress,
                    City = reciever.City,
                    CorporateIdentity = reciever.CorporateIdentity,
                    Name = reciever.Name
                };
                _uow.RecieverRepository.CreateOrUpdate(newReciever);
                return newReciever.Id;
            }
            return reciever.Id;
        }

        public int DoesCustomerExist(CustomerContract customer)
        {
            var currentCustomer = _uow.CustomerRepository.Get(p => p.CustNumber == customer.CustNumber)
                .LastOrDefault();

            if (currentCustomer == null ||
                !string.Equals(currentCustomer.Name, customer.Name, StringComparison.CurrentCultureIgnoreCase) ||
                !string.Equals(currentCustomer.Adress, customer.Adress, StringComparison.CurrentCultureIgnoreCase) ||
                !string.Equals(currentCustomer.City, customer.City, StringComparison.CurrentCultureIgnoreCase))
            {
                var newCustomer = new Customer
                {
                    Adress = customer.Adress,
                    City = customer.City,
                    CorporateIdentity = customer.CorporateIdentity,
                    Name = customer.Name,
                    CustNumber = customer.CustNumber,
                    Tel = customer.Tel
                };
                _uow.CustomerRepository.CreateOrUpdate(newCustomer);
                return newCustomer.Id;
            }
            return currentCustomer.Id;
        }

        public int DoesTransporterExist(TransporterContract transporter)
        {
            var currentTransporter = _uow.TransporterRepository.Get(p => p.CorporateIdentity == transporter.CorporateIdentity)
                .LastOrDefault();

            if (currentTransporter == null ||
                !string.Equals(currentTransporter.Name, transporter.Name, StringComparison.CurrentCultureIgnoreCase) ||
                !string.Equals(currentTransporter.Adress, transporter.Adress, StringComparison.CurrentCultureIgnoreCase) ||
                !string.Equals(currentTransporter.City, transporter.City, StringComparison.CurrentCultureIgnoreCase))
            {
                var newTransporter = new Transporter
                {
                    Adress = transporter.Adress,
                    City = transporter.City,
                    CorporateIdentity = transporter.CorporateIdentity,
                    Name = transporter.Name
                };
                _uow.TransporterRepository.CreateOrUpdate(newTransporter);
                return newTransporter.Id;
            }
            return transporter.Id;
        }

        public ReportContract GetFromReport(int reportId)
        {
            var reportContract = _uow.ReportRepository.Get().FirstOrDefault(x => x.Id == reportId).ToContract();

            //var list = new List<WasteContract>();
            foreach (var article in reportContract.Articles)
            {
                article.Waste =
                    _wasteRepo.Get().FirstOrDefault(x => x.ARTNR == article.WasteId).ToContract();
            }
            return reportContract;
        }
    }
}

