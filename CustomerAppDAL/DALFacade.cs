
using CustomerAppDAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Context;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public ICustomerRepository CustomerRepository
        {
            //get { return new CustomerRepositoryFakeDB(); }
            get
            {
                return new CustomerRepositoryEFMemory(
                    new InMemoryContext());
            }

        }

        public IUnitOfWork UnitOfWork
        {
            
            get
            {
                return new UnitOfWorkMem();
            }

        }
    }
}
