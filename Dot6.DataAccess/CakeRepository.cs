using Dapper;
using Dot6.DataModel;
using Dot6.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot6.DataAccess
{
    public class CakeRepository : ICakeRepository
    {
        private readonly IConfiguration _configuration;

        public CakeRepository(IConfiguration configuration)
        {
            _configuration= configuration;            
        }

        private IDbConnection Connection
        {
            get
            {
                var connString = _configuration.GetConnectionString("MyWorldDbConnection");
                return new SqlConnection(_configuration.GetConnectionString("MyWorldDbConnection"));
            }
        }
        public async Task<List<Cake>> FilterByName(string name)
        {
            using (var conn = Connection)
            {
                var query = "Select * from Cake where Name = @name";
                var cakes = await conn.QueryAsync<Cake>(query, new { name });
                return cakes.ToList();
            }
        }

        public async Task<List<Cake>> GetAll()
        {
            using (var conn = Connection)
            {
                var query = "Select * from Cake";
                var cakes = await conn.QueryAsync<Cake>(query);
                return cakes.ToList();
            }
        }

        public async Task<Cake> GetFirst()
        {
            using (var conn = Connection)
            {
                var query = "Select top 1 * from Cake";
                var cake = await conn.QueryAsync<Cake>(query);
                return cake.FirstOrDefault();
            }
        }

        public async Task<Cake> GetById(int Id)
        {
            using (var conn = Connection)
            {
                var query = "Select * from Cake where Id=@Id";
                var cake = await conn.QuerySingleAsync<Cake>(query, new {Id=Id});
                return cake;
            }
        }

        public async Task<int> SaveCake(Cake cake)
        {
            using (var conn = Connection)
            {
                var command = @"INSERT INTO Cake( Name, Price, Description)
                                VALUES ( @Name, @Price, @Description)";

                var saved = await conn.ExecuteAsync(command, param: cake);
                return saved;
            }
        }

        public async Task<Cake> UpdateCake(Cake cake)
        {
            using (var conn = Connection)
            {
                var command = @"UPDATE Cake
                                SET Name=@Name,Price=@Price,Description=@Description WHERE Id=@Id";

                var saved = await conn.ExecuteAsync(command, cake);
                return await GetById(cake.Id);
            }
        }

        public async Task<Cake> CreateUpdateCake(Cake cake)
        {
            using (var conn = Connection)
            {
                var res = await FilterByName(cake.Name);
                if (res == null)
                {
                    var command = @"INSERT INTO Cake( Name, Price, Description)
                                VALUES ( @Name, @Price, @Description)";

                    var saved = await conn.ExecuteAsync(command, param: cake);
                    return await GetById(saved); 
                }
                else
                {
                    var command = @"UPDATE Cake
                                SET Name=@Name,Price=@Price,Description=@Description WHERE Id=@Id";

                    var saved = await conn.ExecuteAsync(command, cake);
                    return await GetById(cake.Id);
                }
            }
        }

        public async Task<int> DeleteCake(int id)
        {
            using (var conn = Connection)
            {
                var command = @"DELETE Cake
                                where Id=@idToDelete;";

                var deleted = await conn.ExecuteAsync(command, new { idToDelete =id});
                return deleted;
            }
        }
    }
}
