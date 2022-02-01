using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture;

public record struct Arc
{
    public Arc(int angle, int length)
    {
        Angle = angle;
        Length = length;
    }
    int Angle { get; }
    int Length { get;  }


    // Don't do this!!!!
    //public void ZeroOut()
    //{
    //    Angle = 0;
    //}
}

[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class MyTestClass
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
    public void MyTestMethod()
    {
        Arc arc     = new Arc();
        arc.ZeroOut();
    }
}
