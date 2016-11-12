using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataService;
using Data_Service.Info_Flex.Repositories;
using Data_Service.Unit_of_Work;
using Mappers;

namespace Business_Logic.Handlers
{
    public class FlexCustomerHandler
    {
        private readonly CustomerRepository _customerRepo;

        public FlexCustomerHandler()
        {
            _customerRepo = new CustomerRepository();
        }

        public List<InfoFlexCustomerContract> Get()
        {
            return _customerRepo.Get().ToContracts();
        }

        public InfoFlexCustomerContract Get(string custNumber)
        {
            return _customerRepo.Get().FirstOrDefault(x => x.KUNDNR == custNumber).ToContract();
        }
    }
}
