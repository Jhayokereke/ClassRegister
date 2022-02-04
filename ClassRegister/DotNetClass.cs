using System;

namespace ClassRegister
{
    public class DotNetClass 
    {
        public DotNetClass(Student[] students)
        {
            Students = students;
            ClassSize = students.Length;
        }

        public int ClassSize { get; }
        public Student[] Students { get; }

        public void PrintClassDetails()
        {
            foreach (Student dev in Students)
            {
                Console.WriteLine(dev.ToString());
            }
        }
    }
}

//class object
//field representing total number of students
//field representing the list of students in the class
//method to set the number of students
//method to add students to the class
//method to remove student from class
//class name
//class description


//student object
//student name
//student gender
//student gadgets
//student id