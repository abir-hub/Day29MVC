using System.Collections.Generic;
using System;

namespace Day30MVC.Models
{
    public class EmployeeList
    {
        public List<Employee> emps = new List<Employee>();
         
        public EmployeeList(List<Employee> emps) { this.emps = emps; }
        public EmployeeList(Employee emp) { this.emps.Add(emp); }
        public EmployeeList()
        {
            this.AddEmp(new Employee("abc", 101));
            this.AddEmp(new Employee("xyz", 102));
            this.AddEmp(new Employee("abcxyz", 103));
        }
        public void UpdateEmp(int id, string name)
        {

        }
        public void AddEmp(Employee emp) { this.emps.Add(emp); }
        public void DispEmp()
        {
            foreach (Employee e in emps)
            {
                Console.WriteLine(e);
            }
        }
        public Employee getEmp(string name)
        {
            Employee e = new Employee("default", 100);
            foreach (Employee ee in emps)
            {
                if (ee.name.Equals(name))
                {
                    e = ee;
                }
            }

            Employee e2 = emps.Find(ee => ee.name.Equals(name));
            return e;
        }
    }
}
