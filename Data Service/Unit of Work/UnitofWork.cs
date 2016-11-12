using Data_Service.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Service.Unit_of_Work
{
    public class UnitOfWork
    {
        private readonly object _db;

        private GenericRepository<User> _userRepository;
        private GenericRepository<Report> _reportRepository;
        private GenericRepository<Article> _articleRepository;
        private GenericRepository<Vessel> _vesselRepository;
        private GenericRepository<Region> _regionRepository;
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Transporter> _transporterRepository;
        private GenericRepository<Reciever> _recieverRepository;


        public UnitOfWork(object db)
        {
            _db = db;
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_db);
                }
                return _userRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new GenericRepository<Customer>(_db);
                }
                return _customerRepository;
            }
        }

        public GenericRepository<Transporter> TransporterRepository
        {
            get
            {
                if (_transporterRepository == null)
                {
                    _transporterRepository = new GenericRepository<Transporter>(_db);
                }
                return _transporterRepository;
            }
        }

        public GenericRepository<Reciever> RecieverRepository
        {
            get
            {
                if (_recieverRepository == null)
                {
                    _recieverRepository = new GenericRepository<Reciever>(_db);
                }
                return _recieverRepository;
            }
        }

        public GenericRepository<Region> RegionRepository
        {
            get
            {
                if (_regionRepository == null)
                {
                    _regionRepository = new GenericRepository<Region>(_db);
                }
                return _regionRepository;
            }
        }

        public GenericRepository<Report> ReportRepository
        {
            get
            {
                if (_reportRepository == null)
                {
                    _reportRepository = new GenericRepository<Report>(_db);
                }
                return _reportRepository;
            }
        }

        public GenericRepository<Article> ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new GenericRepository<Article>(_db);
                }
                return _articleRepository;
            }
        }

        public GenericRepository<Vessel> VesselRepository
        {
            get
            {
                if (_vesselRepository == null)
                {
                    _vesselRepository = new GenericRepository<Vessel>(_db);
                }
                return _vesselRepository;
            }
        }
    }
}
