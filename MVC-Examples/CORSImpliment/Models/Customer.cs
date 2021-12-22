using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORSImpliment.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Customer(int customerID, string customerName)
        {
            CustomerId = customerID;
            CustomerName = customerName;
        }
        public Customer()
        {

        }
    }
}