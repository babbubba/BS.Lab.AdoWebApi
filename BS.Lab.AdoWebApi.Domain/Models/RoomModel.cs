using System.Collections.Generic;

namespace BS.Lab.AdoWebApi.Domain.Models
{
    public class RoomModel
    {

        private List<EmployeeModel> employees;

        public RoomModel(int id, string name)
        {
            Id = id;
            Name = name;
            // When u use a list u must initialize it before using it (add or remove elements)
            employees = new List<EmployeeModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeModel> Employees
        {
            get
            { 
                return employees; 
            }
        }
        public void AddEmployee(EmployeeModel employee)
        {
            //TODO: Add validation!
            employees.Add(employee);
        }

        public void RemoveEmployee(EmployeeModel employee)
        {
            //TODO: Add validation!
            employees.Remove(employee);
        }

    }
}
