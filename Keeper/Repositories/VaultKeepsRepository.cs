using System.Data;
using Keeper.Models;
using Dapper;

namespace Keeper.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultKeeps
            (creatorId, vaultId, keepId)
            VALUES
            (@CreatorId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID()
            ;";
            newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            return newVaultKeep;
        }

        internal VaultKeep GetById(int id)
        {
            string sql = "SELECT * FROM vaultKeeps WHERE id = @id;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultKeeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}