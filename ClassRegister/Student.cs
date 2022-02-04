using System;

namespace ClassRegister
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Lastname) ? $"{Lastname} {Firstname}" : Firstname;
            }
        }
        public Gender Gender { get; set; }
        public string[] Gadgets { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nFullname: {Fullname}\nGender: {Gender}\nGadgets: {string.Join(", ", Gadgets)}\n";
        }
    }
}