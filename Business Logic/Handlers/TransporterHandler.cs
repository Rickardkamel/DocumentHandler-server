using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataService;
using Data_Service.Unit_of_Work;
using Mappers;

namespace Business_Logic.Handlers
{
    public class TransporterHandler
    {
        private readonly UnitOfWork _uow;

        public TransporterHandler()
        {
            _uow = new UnitOfWork(new DataContext());
        }

        public List<TransporterContract> Get()
        {
            return _uow.TransporterRepository.GetAll().ToContracts();
        }

        public TransporterContract Get(int id)
        {
            return _uow.TransporterRepository.Get(x => x.Id == id).FirstOrDefault().ToContract();
        }

        public void Post(TransporterContract transporterContract)
        {
            _uow.TransporterRepository.CreateOrUpdate(transporterContract.ToEntity());
        }
    }
}
