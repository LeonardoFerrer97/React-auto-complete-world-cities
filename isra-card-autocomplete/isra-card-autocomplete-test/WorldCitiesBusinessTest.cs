using System;
using System.Collections.Generic;
using System.Linq;
using isra_card_autocomplete_business;
using isra_card_autocomplete_entity;
using isra_card_autocomplete_interface_business;
using isra_card_autocomplete_interface_repository;
using Moq;
using Xunit;

namespace isra_card_autocomplete_test
{
    public class WorldCitiesBusinessTest
    {
        IWorldCitiesBusiness worldCitiesBusiness;
        private Mock<IWorldCitiesRepository> _mockRepository;
        [Theory]
        [InlineData(null)]
        public void GetWorldCitiesCannotBeNull(string filter)
        {
            _mockRepository = new Mock<IWorldCitiesRepository>();
            worldCitiesBusiness = new WorldCitiesBusiness(_mockRepository.Object);
            Assert.Throws<ArgumentException>(() => worldCitiesBusiness.GetWorldCities(filter));

        }
        [Theory]
        [InlineData("2c")]
        public void GetWorldCitiesCannotBeSmallerThanThreeChars(string filter)
        {
            _mockRepository = new Mock<IWorldCitiesRepository>();
            worldCitiesBusiness = new WorldCitiesBusiness(_mockRepository.Object);
            Assert.Throws<ArgumentException>(() => worldCitiesBusiness.GetWorldCities(filter));
        }
        [Theory]
        [InlineData("RightFilter")]
        public void GetWorldCitiesSuccess(string filter)
        {
            _mockRepository = new Mock<IWorldCitiesRepository>();
            _mockRepository.
              Setup(repo => repo.GetWorldCities(It.IsAny<string>())).
              Returns(new List<WorldCities>() { new WorldCities() {Name = "Kidsgrove", GeonameId = "2645721", SubCountry = "United Kingdom",Country = "United Kingdom" } });
            worldCitiesBusiness = new WorldCitiesBusiness(_mockRepository.Object);
            var result = worldCitiesBusiness.GetWorldCities(filter);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Kidsgrove",result.ToList()[0].Name);
        }


        [Theory]
        [InlineData("RightFilter")]
        public void GetWorldCitiesSuccessButWithoutCity(string filter)
        {
            _mockRepository = new Mock<IWorldCitiesRepository>();
            _mockRepository.
              Setup(repo => repo.GetWorldCities(It.IsAny<string>())).
              Returns(new List<WorldCities>());
            worldCitiesBusiness = new WorldCitiesBusiness(_mockRepository.Object);

            var result = worldCitiesBusiness.GetWorldCities(filter);
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
