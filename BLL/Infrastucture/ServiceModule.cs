using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Infrastucture
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection = @"Server=(localdb)\mssqllocaldb;Database=TicketAirline;Trusted_Connection=True;")
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }

        public DAL.Repositories.EFUnitOfWork InitDatabase()
        {
            return new DAL.Repositories.EFUnitOfWork(connectionString);
        }
    }
}
