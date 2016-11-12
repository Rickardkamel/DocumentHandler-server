using Contracts;
using Data_Service.Unit_of_Work;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mappers;

namespace Business_Logic.Handlers
{
    public class RegionHandler
    {

        private readonly UnitOfWork _uow;
        private List<ReportContract> reports;

        public RegionHandler()
        {
            _uow = new UnitOfWork(new DataContext());
            reports = new List<ReportContract>();
        }

        public List<RegionContract> Get()
        {
            return _uow.RegionRepository.GetAll().ToContracts();
        }

        public RegionContract Get(int id)
        {
            return _uow.RegionRepository.Get(id).ToContract();
        }

        public RegionContract Post(RegionContract regionContract)
        {
            _uow.RegionRepository.CreateOrUpdate(regionContract.ToEntity());

            return regionContract;
        }

        public void Delete(RegionContract regionContract)
        {
            _uow.RegionRepository.Delete(regionContract.ToEntity());
        }

        public List<ReportContract> RegionReports(int regionId)
        {
            return _uow.ReportRepository.Get(x => x.Region.Id == regionId).Where(c => c.Approved != true).ToList().ToContracts();
        }

        public List<RegionDetailContract> GetDetailedRegionContract()
        {
            reports = _uow.ReportRepository.GetAll().ToContracts();

            var regions = Get();

            return (from region in regions
                let reportsForRegion = reports.Where(x => x.Region.Id == region.Id && x.Approved == false).ToList()
                select new RegionDetailContract
                {
                    Id = region.Id,
                    Name = region.Name,
                    TotalReports = CountTotalReports(region),
                    TotalOldReports = CountOldReports(reportsForRegion, 14),
                    TotalPalletSpace = CountPalletSpace(reportsForRegion)
                }).ToList();
        }

        private int CountTotalReports(RegionContract region)
        {
            return reports.Where(c => c.Approved == false).Count(x => x.Region.Id == region.Id);
        }

        private int CountOldReports(List<ReportContract> reports, int daysToBecomeOld)
        {
            return reports.Count(report => (DateTime.Now - report.CreatedDate).TotalDays > daysToBecomeOld);
        }

        private decimal CountPalletSpace(List<ReportContract> reports)
        {
            decimal totalSum = 0;
            decimal reportSum = 0;

            foreach (var report in reports)
            {
                //if(report.Region.Name == "Linköping")
                //{
                //    var p = " ;";
                //}
                foreach (var article in report.Articles)
                {
                    reportSum += article.Vessel.PalletSpace * (decimal)article.Quantity;
                }
                totalSum += reportSum;
                reportSum = 0;
            }

            return totalSum;
        }
    }
}
