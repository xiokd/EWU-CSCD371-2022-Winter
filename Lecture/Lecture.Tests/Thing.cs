using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Tests
{
    internal class Thing : ISavable
    {
        public string Name { get; set; }

        public Thing(string name)
        {
            Name=name;
        }

        public string ToText()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }
}
