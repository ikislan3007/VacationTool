using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationTool.DAL;
using VacationTool.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacationTool.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Employee> Get()
        {   
            return new List<Employee> { 
                new Employee { 
                    FirstName = "Vasilen", 
                    SecondName = "Vasilen", 
                    DateOfBirth = DateTime.Parse("27.10.1995"), 
                    DateOfHire = DateTime.Parse("27.10.2021"), 
                    Email = "vasilen@sharklazers.com", 
                    Position = "Senior Software Developer",
                    Gender = Gender.MALE
                }
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {

            using ( var ctx = new CompanyContext())
            {
                ctx.Employees.Add(employee);

                ctx.SaveChanges();
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
