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
    public class FilterOutWordsMiddleVowelTest
    {
        private Mock<IFilterFactory> _mockFilterFactory = new Mock<IFilterFactory>();
        private IFilterService service;

        [TestInitialize]
        public void Initialize()
        {
            _mockFilterFactory.Setup(mock => mock.Create(Enum.GetNames(typeof(EnumFilters))[0])).Returns(new FilterOutWordsMiddleVowel());
            service = new FilterService(_mockFilterFactory.Object);
        }

        [TestMethod]
        public void Apply_InputStringWithVowels_Filtered()
        {
            var text = "Jo has a nice shotmun in his car. He never uses it on animals though. Only on monsters!";
            var filteredText = service.FilterOutWordsContainsVowelsInMiddle(text);

            Assert.AreEqual("    shotmun   .  never    animals . Only  monsters!", filteredText);
        }

        [TestMethod]
        public void Apply_InputStringWithVowelsAndPunctuation_Filtered()
        {            
            var text = "<<<<<Hop!1 dsd iv 5?iv";
            var filteredText = service.FilterOutWordsContainsVowelsInMiddle(text);

            Assert.AreEqual("<<<<<!1 dsd  5?", filteredText);
        }

        [TestMethod]
        public void Apply_InputStringWithoutVowels_Unchanged()
        {            
            var text = "Hr sj DJ hrompvr";
            var filteredText = service.FilterOutWordsContainsVowelsInMiddle(text);

            Assert.AreEqual("Hr sj DJ hrompvr", filteredText);
        }
    }
}
