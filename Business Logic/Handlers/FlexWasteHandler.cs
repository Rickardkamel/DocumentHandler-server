using System.Collections.Generic;
using System.Linq;
using Contracts;
using Data_Service.Info_Flex.Repositories;
using Data_Service.Unit_of_Work;
using Mappers;
using Models;

namespace Business_Logic.Handlers
{
    public class FlexWasteHandler
    {
        private readonly WasteRepository _wasteRepo;

        public FlexWasteHandler()
        {
            _wasteRepo = new WasteRepository();
        }

        public List<WasteContract> Get()
        {
            return _wasteRepo.Get().ToContracts();
        }


        public WasteContract Get(string wasteId)
        {
            return _wasteRepo.Get().FirstOrDefault(x => x.ARTNR == wasteId).ToContract();
        }


    }
}
