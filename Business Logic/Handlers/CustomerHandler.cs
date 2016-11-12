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
    public class CustomerHandler
    {
        private readonly UnitOfWork _uow;

        public CustomerHandler()
        {
            _uow = new UnitOfWork(new DataContext());
        }

        public List<CustomerContract> Get()
        {
            return _uow.CustomerRepository.GetAll().ToContracts();
        }

        public CustomerContract Get(int id)
        {
            return _uow.CustomerRepository.Get(x => x.Id == id).FirstOrDefault().ToContract();
        }

        public void Post(CustomerContract customerContract)
        {
            _uow.CustomerRepository.CreateOrUpdate(customerContract.ToEntity());
        }
    }
}
