using NUnit.Framework;

namespace StringTests
{
    internal class Address
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class InClassLabTests
    {
        private const string ExpectedValue = "12345 College Blvd, Overland Park, KS 66210";
        private Address _address;

        [Test]
        public void PlusOverloadOperatorTest()
        {
            var actualAddress = _address.StreetNumber +
                                " " +
                                _address.StreetName +
                                ", " +
                                _address.City +
                                ", " +
                                _address.State +
                                " " +
                                _address.ZipCode;

            Assert.AreEqual(ExpectedValue, actualAddress);
        }

        // string.Concat()


        // string.Format()
        

        // StringBuilder class
        

        //string interperlation $""
    }
}