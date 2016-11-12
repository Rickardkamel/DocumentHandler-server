using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataService;
using Data_Service.Unit_of_Work;
using Mappers;
using Models;

namespace Business_Logic.Handlers
{
    public class ArticleHandler
    {
        private readonly UnitOfWork _uow;

        public ArticleHandler()
        {
            _uow = new UnitOfWork(new DataContext());
        }

        public List<ArticleContract> Get()
        {
            return _uow.ArticleRepository.GetAll().ToContracts();
        }

        public ArticleContract Get(int id)
        {
            return _uow.ArticleRepository.Get(x => x.Id == id).FirstOrDefault().ToContract();
        }

        public void Post(ArticleContract articleContract)
        {
            _uow.ArticleRepository.CreateOrUpdate(articleContract.ToEntity());
        }

        public bool Delete(int articleId)
        {
            if (articleId != 0)
            {
                _uow.ArticleRepository.Delete(articleId);
                return true;
            }
            return false;
        }
    }
}
