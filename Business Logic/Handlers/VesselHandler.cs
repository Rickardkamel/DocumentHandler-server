using System.Collections.Generic;
using Contracts;
using DataService;
using Data_Service.Unit_of_Work;
using Mappers;

namespace Business_Logic.Handlers
{
    public class VesselHandler
    {
        private readonly UnitOfWork _uow;

        public VesselHandler()
        {
            _uow = new UnitOfWork(new DataContext());
        }

        public List<VesselContract> Get()
        {
            return _uow.VesselRepository.GetAll().ToContracts();
        }
    }
}
