using System;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            Customer customer = new Customer();
            customer.Id = id;
            customer.VisitDateTime = DateTime.Parse("2020/02/12");
            customer.WasSatisfied = true;
            customer.Age = 12;
            customer.Sex = "M"; 
            
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
