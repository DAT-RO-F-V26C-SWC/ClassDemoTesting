using ClassDemoTesting.model;
using ClassDemoTesting.normal;

namespace TestingDemo
{
    public class UnitTestNormal
    {
        /*
         * testing the method EnMetode(int parameter) in PlainClass
         */
        [Theory]
        [InlineData(50)]
        [InlineData(70)]
        public void TestEnMetodeOK(int p)
        {
            // arrange 
            PlainClass pc = new PlainClass();

            // act
            pc.EnMetode(p);   // hvis der ikke er en exception er det OK 

            // assert
            Assert.True(true);
        }

        [Theory]
        [InlineData(49)]
        [InlineData(71)]
        [InlineData(-54)]
        public void TestEnMetodeFail(int p)
        {
            // arrange 
            PlainClass pc = new PlainClass();

            // act
            // part of assert

            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => pc.EnMetode(p));
        }



        /*
         * testing the method Search(string fromCity) in PlainClass
         */
        [Theory]
        [InlineData("a")]
        [InlineData("Roskilde")]
        public void TestSearchInputOK(string city)
        {
            // arrange 
            PlainClass pc = new PlainClass();

            // act
            pc.Search(city);   // hvis der ikke er en exception er det OK 

            // assert
            Assert.True(true);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("abc123")]
        public void TestSearcInputFail(string? city)
        {
            // arrange 
            PlainClass pc = new PlainClass();

            // act
            // part of assert

            // assert
            Assert.Throws<ArgumentException>(() => pc.Search(city));
        }

        /*
         * Checking output of Search(string fromCity) in PlainClass
         */
        [Theory]
        [InlineData("Ringsted",0)] // no persons in Ringsted
        [InlineData("Århus", 1)]    // 1 person in Århus
        [InlineData("Roskilde", 3)] // many persons in Roskilde
        public void TestSearchOutput(string city, int noOfPersons)
        {
            // arrange 
            PlainClass pc = new PlainClass();
            int expectedCount = noOfPersons;  // get the expected count of persons in the city

            // act
            List<Person> result =  pc.Search(city);   // hvis der ikke er en exception er det OK 
            int actualCount = result.Count;  // get the actual count of persons in the city

            // assert
            Assert.Equal(expectedCount, actualCount);
        }

    }
}
