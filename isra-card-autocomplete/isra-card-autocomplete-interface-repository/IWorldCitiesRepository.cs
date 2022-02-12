using System;
using System.Collections.Generic;
using isra_card_autocomplete_entity;

namespace isra_card_autocomplete_interface_repository
{
    public interface IWorldCitiesRepository
    {
        IEnumerable<WorldCities> GetWorldCities(string filter);
        
    }
}
