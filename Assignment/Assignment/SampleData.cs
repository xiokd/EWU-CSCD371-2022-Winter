using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                string fileName = "People.csv";
                string buildPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string? directoryPath = Path.GetDirectoryName(buildPath);
                string fullFilePath = Path.Combine(directoryPath!, fileName); // TODO: temporary change, to be fixed.

                return File.ReadLines(fullFilePath).Skip(1);
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
