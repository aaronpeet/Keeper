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
            return GetById(newKeep.Id);
        }

        public List<Keep> Get()
        {
            string sql = @"
            SELECT
            a.*,
            k.*
            FROM keeps k
            JOIN accounts a ON a.id = k.creatorId
            ;";
            return _db.Query<Profile, Keep, Keep>(sql, (prof, keep)=>{
                keep.Creator = prof;
                return keep;
            }, splitOn:"id").ToList();
        }

            public List<Keep> GetProfileKeeps(string id)
        {
            string sql = @"
            SELECT
            a.*,
            k.*
            FROM keeps k
            JOIN accounts a ON a.id = k.creatorId
            WHERE k.creatorId = @id
            ;";
            return _db.Query<Profile, Keep, Keep>(sql, (prof, keep)=>{
                keep.Creator = prof;
                return keep;
            }, new {id}, splitOn:"id").ToList();
        }

        public List<VaultKeepViewModel> GetByVaultId(int vaultId)
        {
            string sql = @"
          SELECT
          a.*,
          k.*,
          vk.id AS vaultKeepId
          FROM vaultKeeps vk
          JOIN keeps k ON vk.keepId = k.id
          JOIN accounts a ON k.creatorId = a.id
          WHERE vk.vaultId = @vaultId
          ;";
            return _db.Query<Profile, VaultKeepViewModel, VaultKeepViewModel>(sql, (prof, vkvm) =>
            {
                vkvm.Creator = prof;
                return vkvm;
            }, new { vaultId }, splitOn: "id").ToList();
        }

        public Keep GetById(int id)
        {
            string sql = @"
            SELECT
             a.*,
             k.* 
             FROM keeps k 
             JOIN accounts a ON a.id = k.creatorId
             WHERE k.id = @id;
            UPDATE keeps
             SET views = views + 1
             WHERE id = @id;";
            return _db.Query<Profile, Keep, Keep>(sql, (prof, keep)=>{
                keep.Creator = prof;
                return keep;
            }, new { id }, splitOn:"id").FirstOrDefault();
        }

        public Keep Edit(Keep updatedKeep)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
            WHERE id = @id
            ;";
            _db.Execute(sql, updatedKeep);
            return updatedKeep;
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

    }
}