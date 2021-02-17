using Crud_Using_Ajax.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Using_Ajax.Models
{
    public class EmpRepo
    
    {
        private readonly ApplicationDbContext _context;

        public EmpRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public EmployeeModel GetEmployee(int Id)
        {
            return _context.Employee.Find(Id);



        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _context.Employee;


        }

        public EmployeeModel AddEmployee(EmployeeModel addEmployee)
        {
            _context.Employee.Add(addEmployee);
            _context.SaveChanges();
            return addEmployee;


        }

        public EmployeeModel UpdateEmployee(EmployeeModel updateEmplyee)
        {
            var employee = _context.Employee.Attach(updateEmplyee);

            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateEmplyee;
        }

        public EmployeeModel DeleteEmployee(int Id)
        {
            EmployeeModel employee = _context.Employee.Find(Id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            return employee;

        }

    }
}
