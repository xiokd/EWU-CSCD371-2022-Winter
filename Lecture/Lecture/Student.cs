using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public class Student : Person
    {

        public Grade Grade { get; set; }

        public Student(string name):base(name)
        {
            Name = name;
        }
    }
}
