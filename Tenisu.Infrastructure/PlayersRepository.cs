using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tenisu.Domain;
using Tenisu.Domain;

namespace Tenisu.Infrastructure
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly string _connectionString;

        public PlayersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            var players = new List<Player>();
        
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM players", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        players.Add(new Player
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                            Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                            Shortname = reader.GetString(reader.GetOrdinal("shortname")),
                            Sex = reader.GetString(reader.GetOrdinal("sex")),
                            Country = new Country
                            {
                                Code = reader.GetString(reader.GetOrdinal("country_code")),
                                Picture = reader.GetString(reader.GetOrdinal("country_picture"))
                            },
                            Picture = reader.GetString(reader.GetOrdinal("picture")),
                            Data = new Data
                            {
                                Rank = reader.GetInt32(reader.GetOrdinal("rank")),
                                Points = reader.GetInt32(reader.GetOrdinal("points")),
                                Weight = reader.GetInt32(reader.GetOrdinal("weight")),
                                Height = reader.GetInt32(reader.GetOrdinal("height")),
                                Age = reader.GetInt32(reader.GetOrdinal("age")),
                                Last = await GetPlayerLastResultsAsync(reader.GetInt32(reader.GetOrdinal("id")))
                            }
                        });
                    }
                }
            }

            return players;
        }

        public async Task<Player> GetPlayerByIdAsync(int playerid)
        {
            Player player = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM players WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", playerid);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        player = new Player
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Firstname = reader.GetString(reader.GetOrdinal("firstname")),
                            Lastname = reader.GetString(reader.GetOrdinal("lastname")),
                            Shortname = reader.GetString(reader.GetOrdinal("shortname")),
                            Sex = reader.GetString(reader.GetOrdinal("sex")),
                            Country = new Country
                            {
                                Code = reader.GetString(reader.GetOrdinal("country_code")),
                                Picture = reader.GetString(reader.GetOrdinal("country_picture"))
                            },
                            Picture = reader.GetString(reader.GetOrdinal("picture")),
                            Data = new Data
                            {
                                Rank = reader.GetInt32(reader.GetOrdinal("rank")),
                                Points = reader.GetInt32(reader.GetOrdinal("points")),
                                Weight = reader.GetInt32(reader.GetOrdinal("weight")),
                                Height = reader.GetInt32(reader.GetOrdinal("height")),
                                Age = reader.GetInt32(reader.GetOrdinal("age")),
                                Last = await GetPlayerLastResultsAsync(reader.GetInt32(reader.GetOrdinal("id")))
                            }
                        };
                    }
                }
            }

            return player;
        }



        private async Task<List<double>> GetPlayerLastResultsAsync(int playerId)
        {
            var results = new List<double>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("SELECT result FROM player_last_results WHERE player_id = @playerId ORDER BY result_index", connection))
                {
                    command.Parameters.AddWithValue("@playerId", playerId);

                    using (var resultReader = await command.ExecuteReaderAsync())
                    {
                        while (await resultReader.ReadAsync())
                        {
                            results.Add(resultReader.GetInt32(resultReader.GetOrdinal("result")));
                        }
                    }
                }
            }

            return results;
        }

    }
}