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
    public class FilterOutWordsWithLetterTTest
    {
        private Mock<IFilterFactory> _mockFilterFactory = new Mock<IFilterFactory>();
        private IFilterService service;

        [TestInitialize]
        public void Initialize()
        {
            _mockFilterFactory.Setup(mock => mock.Create(Enum.GetNames(typeof(EnumFilters))[2])).Returns(new FilterOutWordsWithLetterT());
            service = new FilterService(_mockFilterFactory.Object);
        }

        [TestMethod]
        public void Apply_InputStringWithLetterT_Filtered()
        {            
            var text = "Meaningful text t explaining the power of the mind";
            var filteredText = service.FilterOutWordsContainsLetterT(text);

            Assert.AreEqual("Meaningful   explaining  power of  mind", filteredText);
        }

        [TestMethod]
        public void Apply_InputStringWithLetterTAndPunctuation_Filtered()
        {            
            var text = "<<<<<Hop!1 hopity you efford is my property iv 5?itv";
            var filteredText = service.FilterOutWordsContainsLetterT(text);

            Assert.AreEqual("<<<<<Hop!1  you efford is my  iv 5?", filteredText);
        }

        [TestMethod]
        public void Apply_InputStringWithoutLetterT_Unchanged()
        {
            var text = "Hr sj DJ hrompvr no leder d";
            var filteredText = service.FilterOutWordsContainsLetterT(text);

            Assert.AreEqual("Hr sj DJ hrompvr no leder d", filteredText);
        }
    }
}
