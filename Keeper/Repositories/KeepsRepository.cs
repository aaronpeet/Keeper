using System.Data;
using Dapper;
using Keeper.Models;
using System.Linq;
using System.Collections.Generic;

namespace Keeper.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps(name, description, img, views, shares, keeps, creatorId)
            VALUES
            (@Name, @Description, @Img, @Views, @Shares, @Keeps, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }

        public List<Keep> Get()
        {
            string sql = "SELECT * FROM keeps;";
            return _db.Query<Keep>(sql).ToList();
        }

        public Keep GetById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @id;";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

    }
}