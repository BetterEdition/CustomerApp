
using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL
{
    public interface ICustomerRepository
    {
        //C
        Customer Create(Customer cust);

        //R
        List<Customer> GetAll();
        Customer Get(int Id);

        //No update for Repository, it will be a task for the unit of work 

        //D
        Customer Delete(int Id);
    }
}
