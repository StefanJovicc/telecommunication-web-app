using Microsoft.AspNetCore.Mvc;
using SOAPDemo;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelecommunicationWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            // Getting data from SOAP and importing/mapping it into database
            Person[] people = new Person[10]; 
            SOAPDemo.SOAPDemoSoapClient SoapClient = new SOAPDemo.SOAPDemoSoapClient();
            for (int i = 1; i <= 10; i++)
            {
                Task<Person> task = SoapClient.FindPersonAsync(i.ToString());
                task.Wait();
                people[i - 1] = task.Result;
            }

            return Ok(people);
        }
    }
}
