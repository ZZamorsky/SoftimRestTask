using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftimRestTask.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public DateTime VisitDateTime { get; set; }
        public int Age { get; set; }
        public Boolean WasSatisfied { get; set; }
        public String Sex { get; set; }
    }
}