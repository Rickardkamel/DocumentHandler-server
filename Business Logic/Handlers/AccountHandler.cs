using Data_Service.Unit_of_Work;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Mappers;
using Data_Service;


namespace Business_Logic.Handlers
{
    public class AccountHandler
    {
        private readonly UnitOfWork _uow;

        public AccountHandler()
        {
            _uow = new UnitOfWork(new DataContext());
        }

        public UserContract Login(LoginContract loginContract)
        {

            var userToCheck =_uow.UserRepository.Get(filter: x => x.Username == loginContract.Username).FirstOrDefault();
            if (userToCheck == null) return null;

            var inputFromUserHashPassword = loginContract.Password.GenerateHash(userToCheck.Salt);
            if (inputFromUserHashPassword != userToCheck.Password) return null;

            return userToCheck.ToContract();
        }
    }
}
