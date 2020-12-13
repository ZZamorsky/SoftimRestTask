using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftimRestTask.Models
{
    /// <summary>
    /// Basic structure of Customer object
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Autoincrement ID in database
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Date of creating of Customer
        /// </summary>
        public DateTime VisitDateTime { get; set; }
        /// <summary>
        /// Customers Age (integer)
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Satisfy of Customer (true or false)
        /// </summary>
        public Boolean WasSatisfied { get; set; }
        /// <summary>
        /// Male "M" of Female "F"
        /// </summary>
        public String Sex { get; set; }
    }
}