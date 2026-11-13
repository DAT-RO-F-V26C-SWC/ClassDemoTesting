using ClassDemoTesting.model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoTesting.database
{
    public class PersonRepo
    {
        private readonly SqlConnection _conn;
        private readonly string _tableName;

        public PersonRepo(bool testing = false)
        {
            _tableName = testing ? "PersontestKopi" : "Persontest";

            
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
                .Build();

            string connectionKey = testing ? "developmentConnectionString" : "productionConnectionString";
            string connString = config[connectionKey];
            _conn = new SqlConnection(connString);
        }


        /*
         * nogle crud metoder til at hente data fra databasen
         */

        public List<Person> GetAll()
        {
            _conn.Open();

            string sql = $"SELECT Name, Phone, City FROM {_tableName}";
            List<Person> persons = new List<Person>();

            SqlCommand cmd = new SqlCommand(sql, _conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Person person = new Person()
                {
                    Name = reader.GetString(0),
                    Phone = reader.GetString(1),
                    City = reader.GetString(2)
                };
                persons.Add(person);
            }

            _conn.Close();
            return persons;
        }

        public Person Add(Person person)
        {
            _conn.Open();

            string sql = $"Insert into {_tableName} (Name, Phone, City) VALUES (@Name, @Phone, @City)";
            List<Person> persons = new List<Person>();

            SqlCommand cmd = new SqlCommand(sql, _conn);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Phone", person.Phone);
            cmd.Parameters.AddWithValue("@City", person.City);


            int row = cmd.ExecuteNonQuery();
            _conn.Close();

            if (row == 0)
            {
                throw new Exception("Person not inserted");
            }
            return person;
        }



        // property for testing purposes
        public SqlConnection Connection
        {
            get { return _conn; }
        }
    }
}
