using System.Collections.Generic;
using isra_card_autocomplete_dto;
using isra_card_autocomplete_interface_business;
using Microsoft.AspNetCore.Mvc;

namespace isra_card_autocomplete.Controllers
{
    [Route("[controller]")]
    public class WorldCitiesController : ControllerBase
    {
        private readonly IWorldCitiesBusiness _worldCitiesBusiness;
        public WorldCitiesController(IWorldCitiesBusiness worldCitiesBusiness)
        {
            _worldCitiesBusiness = worldCitiesBusiness;
        }

        [HttpGet("{filter}")]
        public ActionResult<IEnumerable<WorldCitiesDto>> GetTweets([FromRoute] string filter)
        {
            return Ok(_worldCitiesBusiness.GetWorldCities(filter));
        }
    }
}
