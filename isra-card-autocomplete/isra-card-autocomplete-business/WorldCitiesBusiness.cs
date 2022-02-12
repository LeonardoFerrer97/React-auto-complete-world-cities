using System;
using System.Collections.Generic;
using isra_card_autocomplete_business.Mappers;
using isra_card_autocomplete_dto;
using isra_card_autocomplete_entity;
using isra_card_autocomplete_interface_business;
using isra_card_autocomplete_interface_repository;

namespace isra_card_autocomplete_business
{
    public class WorldCitiesBusiness : IWorldCitiesBusiness
    {
        private readonly WorldCitiesMapper mapper = new WorldCitiesMapper();
        private readonly IWorldCitiesRepository _worldCitiesRepository;
        public WorldCitiesBusiness(IWorldCitiesRepository worldCitiesRepository)
        {
            _worldCitiesRepository = worldCitiesRepository;
        }
        public IEnumerable<WorldCitiesDto> GetWorldCities(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                throw new ArgumentException("Filter cannot be null");
            }
            if (filter.Length < 2)
            {
                throw new ArgumentException("Filter cannot be smaller than 3 characteres");
            }
            IEnumerable<WorldCities> worldCity = _worldCitiesRepository.GetWorldCities(filter);
            if (worldCity == null)
            {
                return new List<WorldCitiesDto>();
            }
            return mapper.ListEntityToListDto(worldCity);
        }
       
    }
}
