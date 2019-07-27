using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using LostInTheWoods.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace LostInTheWoods.Factories
{
    public class TrailFactory
    {
        public TrailFactory(IOptions<MySqlOptions> options)
        {
            connectionString = options.Value.ConnectionString;
        }
        private string connectionString;
        internal IDbConnection Connection
        {
            get { return new MySqlConnection(connectionString); }
        }
        public Trail GetTrailById(int trailId)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sql = "SELECT * FROM Trails WHERE TrailId = @ID";
                var param = new {ID=trailId};
                var resultCollection = dbConnection.Query<Trail>(sql, param);
                return resultCollection.FirstOrDefault();
            }
        }
        public List<Trail> GetTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection
                    .Query<Trail>("SELECT * FROM Trails")
                    .ToList();
            }
        }
        public void Create(Trail newTrail)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sql = @"INSERT INTO Trails (Name, Length, Latitude, Longitude, ElevationGain, Description)
                    VALUES (@Name, @Length, @Latitude, @Longitude, @ElevationGain, @Description)
                ";
                dbConnection.Execute(sql, newTrail);
            }
        }
    }
}