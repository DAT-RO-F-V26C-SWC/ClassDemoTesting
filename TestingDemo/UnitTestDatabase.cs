using ClassDemoTesting.database;
using ClassDemoTesting.model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDemo
{
    public class UnitTestDatabase
    {
        /*
         * Opsætning af en database til test formål
         */
        private readonly PersonRepo _repo;
        public UnitTestDatabase() 
        {
            bool testing = true;
            _repo = new PersonRepo(testing);

            /*
             * opsæt mock data
             */
            ResetDatabase();
        }

        /*
         * testing the method GetAll() in PersonRepo
         */
        [Fact]
        public void TestGetAllPersons()
        {
            // arrange 
            int expectedCount = 5;

            // act
            int actualCount = _repo.GetAll().Count;

            // assert
            Assert.Equal(expectedCount, actualCount);
        }

        /*
         * testing the method Add(Person person) in PersonRepo
         */
        [Fact]
        public void TestAddPerson()
        {
            // arrange 
            Person newPerson = new Person("Frank", "33333333", "Odense");
            int expectedCount = 5 + 1;

            // act
            Person addedPerson = _repo.Add(newPerson);
            int actualCount = _repo.GetAll().Count;

            // assert
            Assert.Equal(newPerson.Name, addedPerson.Name);
            Assert.Equal(newPerson.Phone, addedPerson.Phone);
            Assert.Equal(newPerson.City, addedPerson.City);
            Assert.Equal(expectedCount, actualCount);
        }




        /*
         *  nulstil databasen til en kendt tilstand 
         *  5 personer i databasen alice, bob, charlie, david, eve
         */
        private static object _lock = new object();
        private void ResetDatabase()
        {
            lock (_lock)
            {
                SqlConnection conn = _repo.Connection;
                string sql = "DELETE FROM PersontestKopi";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                sql = "INSERT INTO PersontestKopi (Name, Phone, City) VALUES ('Alice', '1234567890', 'Roskilde'), ('Bob', '0987654321', 'København'), ('Charlie', '5555555555', 'Roskilde'), ('David', '1111111111', 'Roskilde'), ('Eve', '2222222222', 'Århus');";
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
    
}
