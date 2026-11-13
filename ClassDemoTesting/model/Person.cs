using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoTesting.model
{
    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public Person(string name, string phone, string city)
        {
            Name = name;
            Phone = phone;
            City = city;
        }
        public Person():this("dummy", "", "")
        {            
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Phone)}={Phone}, {nameof(City)}={City}}}";
        }
    }
}
