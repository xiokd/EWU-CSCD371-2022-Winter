using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_AssignGradeA_Success()
        {
            Student student = new Student("Princess Buttercup");
            student.Grade = Grade.A;

            Assert.AreEqual<Grade>(student.Grade, Grade.A);
        }

        [TestMethod]
        public void Student_AssignInteger42_Success()
        {
            Student student = new Student("Princess Buttercup");
            student.Grade = (Grade)42;

            Assert.AreEqual<Grade>(student.Grade, Grade.A);
        }
    }
}
