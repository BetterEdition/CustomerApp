using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL;
using System.Linq;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;


namespace CustomerAppBLL.Services
{
    class CustomerService : ICustomerService
    {
        DALFacade facade;

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(Convert(cust));
                uow.Complete();
               
                return Convert(newCust);
            }
            
            
        }

       
        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return Convert(newCust);
            }
            
      
        }

        public CustomerBO Get(int Id)
        {
            
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.CustomerRepository.Get(Id));
            }

        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.CustomerRepository.GetAll();
                return uow.CustomerRepository.GetAll().Select(c => Convert(c)).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                customerFromDb.FirstName = cust.FirstName;
                customerFromDb.LastName = cust.LastName;
                customerFromDb.Address = cust.Address;
                uow.Complete();
                return Convert(customerFromDb);
            }
            
            


        }

        private Customer Convert(CustomerBO cust)
        {
            return new Customer()
            {
                Id = cust.Id,
                Address = cust.Address,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }

        private CustomerBO Convert(Customer cust)
        {
            return new CustomerBO()
            {
                Id = cust.Id,
                Address = cust.Address,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
