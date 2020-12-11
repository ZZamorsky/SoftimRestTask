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
        public Customer Get(long id)
        {
            CustomerPersistence customerPersistence = new CustomerPersistence();
            Customer customer = customerPersistence.GetCustomer(id);
            return customer;
        }

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            CustomerPersistence customerPersistence = new CustomerPersistence();
            long id;
            id = customerPersistence.SaveCustomer(value);
            value.Id = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("Customer/{0}",id));
            return response;


        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
