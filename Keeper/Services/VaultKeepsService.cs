using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vaultKeepsRepo;
        public VaultKeepsService(VaultKeepsRepository vaultKeepsRepo)
        {
            _vaultKeepsRepo = vaultKeepsRepo;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _vaultKeepsRepo.Create(newVaultKeep);
        }

        private VaultKeep GetById(int id)
        {
            VaultKeep found = _vaultKeepsRepo.GetById(id);
            if(found == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return found;
        }

        internal void Delete(int id, string userId)
        {
            VaultKeep toDelete = GetById(id);
            if(toDelete.CreatorId != userId)
            {
                throw new System.Exception("Invalid access, this is not yours to delete.");
            }
            _vaultKeepsRepo.Delete(id);
        }
    }
}