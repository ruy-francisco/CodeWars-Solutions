namespace CanViewAll_Tests
{
    using System.Linq;
    using NUnit.Framework;
    using CanViewAll.Classes;

    [TestFixture]
    public class MovieCheckerTester
    {
        [Test]
        [TestCase(new object[] { "1/1/2015 20:00-21:30", "1/1/2015 21:30-23:00", "1/1/2015 23:10-23:30" }, ExpectedResult = true)]
        [TestCase(new object[] { "2/1/2015 20:00-21:30", "1/1/2015 21:30-23:00", "1/1/2015 23:10-23:30" }, ExpectedResult = false)]
        [TestCase(new object[] { "1/1/2015 20:00-21:30", "2/1/2015 21:30-23:00", "1/1/2015 23:10-23:30" }, ExpectedResult = false)]
        [TestCase(new object[] { "1/1/2015 20:00-21:30", "1/1/2015 21:29-23:00", "1/1/2015 23:10-23:30" }, ExpectedResult = false)]
        [TestCase(new object[] { "1/1/2015 20:00-21:30", "1/1/2015 21:30-23:00", "1/1/2015 23:00-23:30" }, ExpectedResult = true)]
        [TestCase(new object[] { "1/1/2015 20:00-21:30", "1/1/2015 21:30-22:59", "1/1/2015 23:10-23:30" }, ExpectedResult = true)]
        public bool CanViewAll_ReturnsBoolean(object[] movies)
        {
            string[] strMovies = movies.Select(x => x.ToString()).ToArray();
            return MovieChecker.CanViewAll(strMovies);
        }
    }
}
