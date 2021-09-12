using System.Data;
using Dapper;
using Keeper.Models;
using System.Linq;

namespace Keeper.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Vault Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
            (name, description, isPrivate, creatorId)
            VALUES
            (@Name, @Description, @IsPrivate, @CreatorId);
            SELECT LAST_INSERT_ID()
            ;";
            newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
            return GetById(newVault.Id);
        }

            public Vault GetById(int id)
        {
            string sql = @"
            SELECT
            a.*,
            v.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.id = @id;";
            return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
            {
                vault.Creator = prof;
                return vault;
            }, new{id}, splitOn: "id").FirstOrDefault();
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}