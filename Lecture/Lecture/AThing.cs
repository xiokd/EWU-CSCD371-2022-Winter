using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture;

public abstract class AThing : ISavable
{
    public abstract string Name { get; set; }

    public AThing(string name)
    {
        Name=name;
    }

    public string ToText()
    {
        return $"{nameof(Name)}: {Name}";
    }
}

