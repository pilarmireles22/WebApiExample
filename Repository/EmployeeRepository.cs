using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository
    {
        public MvcCrudDBEntities db = new MvcCrudDBEntities();

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public Employee GetByEmployeeId(int id)
        {
            var employee = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
            return employee;
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return db.Employees;
        }

        public void Delete(int id)
        {
            var employee = GetByEmployeeId(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
