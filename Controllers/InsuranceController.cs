using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ReturnInsuranceProperty>> Get()
        {
            //return new string[] { "value1", "value2" };
            InsuranceDAL ob=new InsuranceDAL();
            return ob.GetAllInsurance();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Property data)
        {
            InsuranceDAL ob=new InsuranceDAL();
            ob.AddInsurance(data);
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Property data)
        {
            InsuranceDAL ob=new InsuranceDAL();
            ob.UpdateInsurance(id,data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             InsuranceDAL ob=new InsuranceDAL();
            ob.DeleteInsurance(id);
        }
    }
}
