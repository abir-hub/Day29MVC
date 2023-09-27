using System.Collections.Generic;
using System;
using SchoolPortalMVC.Controllers;

namespace SchoolPortalMVC.Models
{
    public class StudentList
    {
        public List<Student> students = new List<Student>();
        public StudentList(List<Student> students)
        {
            this.students = students;
        }

        public StudentList(Student student) { this.students.Add(student); }
        public StudentList()
        {
            this.AddStudent(new Student(101, "Name1", "Engg", 4, 2023, 1000 ));
            this.AddStudent(new Student(101, "Name2", "MBA", 2, 2023, 1020));
        }
        public void AddStudent(Student student) { this.students.Add(student); }
        public void DispStudent(List<Student> stds)
        {
            foreach (Student s in stds)
            {
                Console.WriteLine(s);
            }
        }
        public void UpdateStudent(int id, string name)
        {
            Student empUp = students.Find(student => student.id == id);
            if (empUp != null)
            {
                empUp.name = name;
            }


        }

        public List<Student> SearchStudent(int id)
        {
            List<Student> searchStudent = students.FindAll(student => student.id == id);
            return searchStudent;
        }

        public Student getStudent(int id)
        {
            //int id, string name, string course,int duration,int year,double fees
            Student e = new Student(100, "default", "default", 0, 0, 0);
            foreach (Student ee in students)
            {
                if (ee.id.Equals(id))
                {
                    e = ee;
                }
            }

            Student e2 = students.Find(ee => ee.id.Equals(id));
            return e;
        }


        public void deleteStudent(int id)
        {
            
        }
    }

    
}

