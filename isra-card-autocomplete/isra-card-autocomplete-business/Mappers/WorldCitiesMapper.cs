using System;
using System.Collections.Generic;
using isra_card_autocomplete_dto;
using isra_card_autocomplete_entity;

namespace isra_card_autocomplete_business.Mappers
{
    public class WorldCitiesMapper
    {
        public WorldCitiesDto EntityToDto(WorldCities worldCity)
        {
            if (worldCity != null)
            {
                return new WorldCitiesDto()
                {
                    Name = worldCity.Name,
                    Country = worldCity.Country,
                    SubCountry = worldCity.SubCountry,
                    GeonameId = worldCity.GeonameId
                };
            }
            return null;
        }
        public List<WorldCitiesDto> ListEntityToListDto(IEnumerable<WorldCities> worldCities)
        {
            List<WorldCitiesDto> dtos = new List<WorldCitiesDto>();
            foreach (var worldCity in worldCities)
            {
                dtos.Add(EntityToDto(worldCity));

            }
            return dtos;
        }

        public WorldCities DtoToEntity(WorldCitiesDto worldCity)
        {
            if (worldCity != null)
            {
                return new WorldCities()
                {
                    Name = worldCity.Name,
                    Country = worldCity.Country,
                    SubCountry = worldCity.SubCountry,
                    GeonameId = worldCity.GeonameId
                };
            }
            return null;
        }

        public List<WorldCities> ListDtoToListEntity(IEnumerable<WorldCitiesDto> worldCities)
        {
            List<WorldCities> dtos = new List<WorldCities>();
            foreach (var worldCity in worldCities)
            {
                dtos.Add(DtoToEntity(worldCity));

            }
            return dtos;
        }
    }
}

