namespace DataService
{
    using Models;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("CompanyDatabase")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Reciever> Recievers { get; set; }

        public DbSet<Transporter> Transporters { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Vessel> Vessels { get; set; }

        public DbSet<Region> Regions { get; set; }
    }
}