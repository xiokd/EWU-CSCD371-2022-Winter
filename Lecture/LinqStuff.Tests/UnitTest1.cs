using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqStuff.Tests
{

    public static class IEnumerableEx
    {
        static public IEnumerable<T> Filter<T>(this IEnumerable<T> items /* lambda expression */)
        {

            return null;
        }
    }


    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void TestMethod1()
        {
            List<Person> kimList = new();
            List<Person> list = new();
            // ADd items
            IEnumerable<Person> persons = list;
            //persons.
            IEnumerable<string> firstNames = list.Where(item => item.LastName == "Kim")
                .Select(item => item.FirstName);

            IEnumerable<(string FirstName, string LastName)>? fullNameObjects = 
                list.Select(item => (item.FirstName, item.LastName));


            foreach (Person item in list)
            {
                if(item.LastName == "Kim")
                {
                    kimList.Add(item);
                }
            }
        }


        [TestMethod]
        public void TestMethod2()
        {
            List<string> kimList = new();
            List<Person> list = new();
            // ADd items
            foreach (Person item in list)
            {
                if (item.LastName == "Kim")
                {
                    kimList.Add(item.FirstName);
                }
            }
        }
    }
}