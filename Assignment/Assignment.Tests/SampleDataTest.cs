using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTest
    {
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_UsingHardcodedList_Success()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<string> list = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            //Console.WriteLine(list);

            // convert into IEnumerable<Address>
            // IEnumerable<Address> sampleDataAddresses = 
            // remove non-Spokane addresses from list

            // check Spokane addresses are in list
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsDistinct()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<string> list = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            int expected = list.Distinct().Count();

            Assert.AreEqual(expected, list.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<string> list = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // get unsorted list
            IEnumerable<string> unsortedList = sampleData.CsvRows.Select(
                item =>
                item.Split(',')[6]).ToList();

            Assert.AreNotEqual(unsortedList, list);
            Assert.AreNotEqual(unsortedList.First(), list.First());
        }

        //private IEnumerable<Address> GetSpokaneAddresses()
        //{
        //    IEnumerable<Address> list = new List<Address>();

        //    list.Append<Address>(new Address("53 Grim Point", "Spokane", "WA", "99022"));
        //    list.Append<Address>(new Address("1 Rutledge Point", "Spokane", "WA", "99021"));
        //    list.Append<Address>(new Address("6487 Pepper Wood Court", "Spokane", "WA", "99021"));

        //    return list;
        //}
    }
}
