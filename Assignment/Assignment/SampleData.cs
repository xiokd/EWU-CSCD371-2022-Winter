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

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            // format is Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
            // Distinct for Unique

            return CsvRows.Select(item => item.Split(',')[6]).Distinct().OrderBy(item => item);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            // return a string that contains a unique, comma separated list of states

            IEnumerable<string> list = GetUniqueSortedListOfStatesGivenCsvRows();
            var array = list.ToArray();

            return string.Join(",", array);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                // Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
                // 0     1        2        3        4         5     6    7
                // Person object has string FirstName, string LastName, IAddress Address, string EmailAddress
                // Address has string StreetAddress, string City, string State, string Zip

                // sort the list by State, City, Zip
                var sortedRows = CsvRows.Select(item => item.Split(',')
                    .OrderBy(item => item[6])
                    .ThenBy(item => item[5])
                    .ThenBy(item => item[7]));

                IEnumerable<Person> persons = 
                    from item in CsvRows
                    let line = item.Split(',')
                    select new Person(
                        firstName: line[1],
                        lastName: line[2],
                        emailAddress: line[3],
                        address: new Address(
                            streetAddress: line[4],
                            city: line[5],
                            state: line[6],
                            zip: line[7]
                            )
                        );

                // TODO: figure out how to use sortedRows in person selection
                return persons;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
