using ClassDemoTesting.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassDemoTesting.normal
{
    public class PlainClass
    {
        /*
         * checking int parameter is between 50 and 70
         */
        public void EnMetode(int parameter)
        {
            if (parameter < 50 || 70 < parameter)
            {
                throw new ArgumentOutOfRangeException(nameof(parameter), "Parameter must be between 50 and 70.");
            }

            // do something with the parameter
        }



        /*
         * checking string parameter is not null or empty
         * and the return values
         */
        private List<Person> persons = new List<Person>()
         {
             new Person("Alice", "1234567890", "Roskilde"),
            new Person("Bob", "0987654321", "København"),
            new Person("Charlie", "5555555555", "Roskilde"),
            new Person("David", "1111111111", "Roskilde"),
            new Person("Eve", "2222222222", "Århus")
         };    
        public List<Person> Search(string fromCity)
        {
            if (string.IsNullOrEmpty(fromCity))
            {
                throw new ArgumentException("City must be provided", nameof(fromCity));
            }
            Regex regex = new Regex(@"^[a-zA-ZæøåÆØÅ]+$"); // mindst 1 bogstav
            if (!regex.IsMatch(fromCity))
            {
                throw new ArgumentException("City must contain only letters", nameof(fromCity));
            }

            List<Person> result = new List<Person>();
            foreach(var person in persons)
            {
                if (person.City.Equals(fromCity, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(person);
                    
                }
            }

            return result;
        }




    }
}
