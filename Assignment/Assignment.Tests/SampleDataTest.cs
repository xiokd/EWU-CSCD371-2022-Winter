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
        public void CsvRows_SkipsFirstLineAndIteratesThroughCSVFile_Success()
        {
            SampleData sampleData = new();

            int result = sampleData.CsvRows.Count();

            Assert.AreEqual(50, result);
        }

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

            Assert.AreEqual<int>(expected, list.Count());
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

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ValidateSortedListOfStates_Success()
        {
            SampleData sampleData = new();
            string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual<string>(expected, result);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_Validate_Success()
        {
            SampleData sampleData = new();

            string csvRowsResult = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string givenPeopleResult = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            Assert.AreEqual<string>(csvRowsResult, givenPeopleResult);
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
