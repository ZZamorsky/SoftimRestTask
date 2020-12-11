using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SoftimRestTask.Models;

namespace SoftimRestTask.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public ArrayList Get()
        {
            CustomerPersistence customerPersistence = new CustomerPersistence();
            return customerPersistence.GetCustomers();
        }

        // GET: api/Customer/5
        //public Customer Get(long id)
        //{
        //    CustomerPersistence customerPersistence = new CustomerPersistence();
        //    Customer customer = customerPersistence.GetCustomer(id);
        //    return customer;
        //}

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody]List<Customer> value)
        {
            CustomerPersistence customerPersistence = new CustomerPersistence();
            customerPersistence.SaveCustomers(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            return response;
        }
    }
}
