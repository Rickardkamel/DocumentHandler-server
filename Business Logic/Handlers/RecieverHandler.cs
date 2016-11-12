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
    public class RecieverHandler
    {
        private readonly UnitOfWork _uow;

        public RecieverHandler()
        {
            _uow = new UnitOfWork(new DataContext());
        }

        public List<RecieverContract> Get()
        {
            return _uow.RecieverRepository.GetAll().ToContracts();
        }

        public RecieverContract Get(int id)
        {
            return _uow.RecieverRepository.Get(x => x.Id == id).FirstOrDefault().ToContract();
        }

        public void Post(RecieverContract recieverContract)
        {
            _uow.RecieverRepository.CreateOrUpdate(recieverContract.ToEntity());
        }
    }
}
