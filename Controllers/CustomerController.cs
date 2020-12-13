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
    /// <summary>
    /// Controller for REST method
    /// </summary>
   
    public class CustomerController : ApiController
    {

        /// <summary>
        /// Loading All users from database sorted bz ID
        /// </summary>
        /// <returns></returns>
        public ArrayList Get()
        {
            CustomerPersistence customerPersistence = new CustomerPersistence();
            return customerPersistence.GetCustomers();
             
        }

        /// <summary>
        /// Insert values in list into a database (must be a list of Customers)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]List<Customer> value)
        {
            CustomerPersistence customerPersistence = new CustomerPersistence();
            customerPersistence.SaveCustomers(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            return response;
        }
    }
}
