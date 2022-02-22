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
                string? directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                if(directoryPath is null) { throw new DirectoryNotFoundException("Directory was not found"); }
                string fullFilePath = Path.Combine(directoryPath, "People.csv");

                return File.ReadLines(fullFilePath).Skip(1);
            }
        }

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            // format is Id,FirstName,LastName,Email,StreetAddress,City,State,Zip

            return CsvRows.Select(item => item.Split(',')[6]).Distinct().OrderBy(item => item).ToList();
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
                IEnumerable<IPerson> people = CsvRows.Select(item => item.Split(','))
                    .OrderBy(item => item[6])
                    .ThenBy(item => item[5])
                    .ThenBy(item => item[7])
                    .Select(person =>
                        new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3]));

                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName, item.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return people.Select(item => item.Address.State).Distinct().Aggregate((stateList , nextState) => $"{stateList}, {nextState}");
        }
    }
}
