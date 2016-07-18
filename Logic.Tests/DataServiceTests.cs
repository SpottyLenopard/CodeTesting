using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestFixture]
    class DataServiceTests
    {
        [Test]
        public void Ctr_When_capacity_is_less_than_zero_Then_throws_exception()
        {
            Assert.That(() => new DataService(-3), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
