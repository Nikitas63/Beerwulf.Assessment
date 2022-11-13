using NUnit.Framework;
using Review.API.AppStart;

namespace Review.UnitTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class AutoMappingTest
    {
        [Test]
        public void ShouldBeValid()
        {
            var actual = AutoMapperConfig.Configure();
            Assert.That(actual, Is.Not.Null);
            actual.AssertConfigurationIsValid();
        }
    }
}