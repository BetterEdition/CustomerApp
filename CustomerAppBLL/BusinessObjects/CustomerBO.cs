using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    public class CustomerBO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public String Address { get; set; }

        public int Id { get; set; }
    }
}
