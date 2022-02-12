using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using isra_card_autocomplete_entity;
using isra_card_autocomplete_interface_repository;
using isra_card_autocomplete_utils;
using isra_card_autocomplete_utils.Queries;
using Microsoft.Extensions.Options;
using Npgsql;

namespace isra_card_autocomplete_repository
{
    public class WorldCitiesRepository : IWorldCitiesRepository
    {
        private readonly IDbConnection conn;
        public string connectionString;
        public WorldCitiesRepository(IOptions<ConnectionString> config)
        {

            connectionString = config.Value.DbConnection;
            conn = new NpgsqlConnection(connectionString);
        }


        public IEnumerable<WorldCities> GetWorldCities(string filter)
        {
            var sb = new StringBuilder();
            var sql = sb.AppendFormat(WorldCitiesQueries.GET_WORLD_CITY_LIKE_FILTER, filter);
            return SqlMapper.Query<WorldCities>(conn, sql.ToString());

        }
    }
}
