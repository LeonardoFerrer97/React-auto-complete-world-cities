using System;
namespace isra_card_autocomplete_utils.Queries
{
    public class WorldCitiesQueries
    {
        public static string GET_WORLD_CITY_LIKE_FILTER = "select w.name, w.country, w.subcountry, w.geonameid from public.worldcities w where w.name ilike '{0}%' or w.country ilike '{0}%' or w.subcountry ilike '{0}%' or w.geonameid ilike '{0}%' LIMIT 10";

    }
}
