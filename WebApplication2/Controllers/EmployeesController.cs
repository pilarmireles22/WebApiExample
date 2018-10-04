using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Repository;

namespace WebApplication2.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeRepository _repository = new EmployeeRepository();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return _repository.GetAllEmployees();
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = _repository.GetByEmployeeId(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            _repository.Update(employee);

            return Ok(employee);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(employee);

            return Ok(employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = _repository.GetByEmployeeId(id);
            if(employee == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return Ok();
        }
    }
}