using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Tests
{
    [TestFixture]
    class MasterServiceTests
    {
        private readonly IDataService _dataService;
        private readonly IAlgoService _algoService;
        private readonly IMasterService _masterService;

        public MasterServiceTests()
        {
            _dataService = new DataService(3);
            _algoService = new AlgoService();
            _masterService = new MasterService(_algoService, _dataService);
        }

        [Test]
        public void GetDoubleSum_When_enumerable_is_not_filled_Then_throw_ex()
        {
            Assert.That(() => _masterService.GetDoubleSum(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void GetDoubleSum_When_enumerable_is_filled_Then_doublesum_is_calc()
        {
            if (_dataService.ItemsCount <= 0)
            {
                _dataService.AddItem(1);
                _dataService.AddItem(2);
                _dataService.AddItem(3);
            }

            var result = _masterService.GetDoubleSum();

            _dataService.ClearAll();

            Assert.That(result, Is.EqualTo(12));
        }

    }
}
