using System;

namespace ClassRegister
{
    class Program
    {    

        static void Main()
        {
            Student student = new Student
            {
                Firstname = "Uzor",
                Lastname = "Nwachukwu",
                Gender = 0,
                Gadgets = new string[] { "Dell Laptop", "iPhone12 ProMax", "Backpack", "Face cap" }
            };

            Student student2 = new Student()
            {
                Firstname = "Isaac",
                Lastname = "Raphael",
                Gender = Gender.Male,
                Gadgets = new string[] { "Hp Laptop", "Nokia 3310", "Backpack" }
            };

            Student[] students = new Student[]
            {
                student,
                student2,
                new Student()
                {
                    Firstname = "Sarah",
                    Gender = Gender.Female,
                    Gadgets = new string[] { "Hp Laptop", "Samsung galaxy s12", "Handbag" }
                },
                
            };
            DotNetClass netClass = new DotNetClass(students);
            netClass.PrintClassDetails();
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