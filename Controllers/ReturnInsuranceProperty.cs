using System;

namespace Assignment.API.Controllers
{
    public class ReturnInsuranceProperty
    {
        
        public string CustomerName { get; set; }
         public string Address { get; set; }
          public DateTime DateofBirth { get; set; }
           public string Gender { get; set; }
           public string CustomerCountry { get; set; }
            public DateTime SaleDate { get; set; }

             public string CoveragePlan { get; set; }
           public double NetPrice { get; set; }

    }
}