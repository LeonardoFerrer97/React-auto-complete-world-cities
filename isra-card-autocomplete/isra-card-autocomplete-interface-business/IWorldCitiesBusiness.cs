using System;
using System.Collections.Generic;
using isra_card_autocomplete_dto;

namespace isra_card_autocomplete_interface_business
{
    public interface IWorldCitiesBusiness
    {
        IEnumerable<WorldCitiesDto> GetWorldCities(string filter);
    }
}
