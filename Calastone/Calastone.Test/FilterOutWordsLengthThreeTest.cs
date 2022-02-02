using Calastone.Application.Contracts;
using Calastone.Application.Enums;
using Calastone.Infrastructure.Filters;
using Calastone.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Calastone.Test
{
    [TestClass]
    public class FilterOutWordsLengthThreeTest
    {
        private Mock<IFilterFactory> _mockFilterFactory = new Mock<IFilterFactory>();
        private IFilterService service;

        [TestInitialize]
        public void Initialize()
        {
            _mockFilterFactory.Setup(mock => mock.Create(Enum.GetNames(typeof(EnumFilters))[1])).Returns(new FilterOutWordsLengthThree());
            service = new FilterService(_mockFilterFactory.Object);
        }

        [TestMethod]
        public void Apply_InputStringWithUnder3Letters_Filtered()
        {            
            var text = "Jo has a nice shotfun";
            var filteredText = service.FilterOutWordsLengthLessThanThree(text);

            Assert.AreEqual(" has  nice shotfun", filteredText);
        }

        [TestMethod]
        public void Apply_InputStringWithoutUnder3Letters_Unchanged()
        {
            var text = "Hrsdf ssdj DJsss hrompvr";
            var filteredText = service.FilterOutWordsLengthLessThanThree(text);

            Assert.AreEqual("Hrsdf ssdj DJsss hrompvr", filteredText);
        }

        [TestMethod]
        public void Apply_InputStringWithUnder3LettersAndPunctuation_Filtered()
        {
            var text = "<<<<<Hop!1 dsd having a good timeee iv 5?iv";
            var filteredText = service.FilterOutWordsLengthLessThanThree(text);

            Assert.AreEqual("<<<<<Hop! dsd having  good timeee  ?", filteredText);
        }
    }
}
