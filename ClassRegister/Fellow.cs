using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegister
{
    public class Fellow
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; } = Gender.Other;
        public int StateId { get; set; }
        public State State { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nFirstname: {Firstname}\nMiddlename: {Middlename}\nLastname: {Lastname}\n" +
                $"Gender: {Gender}\nState: {State?.Name ?? "Unknown"}";
        }
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
    }
}
