using CORSImpliment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORSImpliment.Controllers
{
    
    public class CustomerController : ApiController
    {
        
        public List<Customer> GetUsers()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(1, "Omkar"));
            customers.Add(new Customer(2, "Arun"));
            return customers.ToList();
        }
    }
}
