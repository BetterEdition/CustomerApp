
using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL
{ 
    public interface ICustomerService
    {
        //C
        CustomerBO Create(CustomerBO cust);

        //R
        List<CustomerBO> GetAll();
        CustomerBO Get(int Id);
        //U
        CustomerBO Update(CustomerBO cust);

        //D
        CustomerBO Delete(int Id);
    }
}
