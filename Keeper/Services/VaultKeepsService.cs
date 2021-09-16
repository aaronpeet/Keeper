using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vaultKeepsRepo;
        private readonly VaultsRepository _vaultsRepo;
        public VaultKeepsService(VaultKeepsRepository vaultKeepsRepo, VaultsRepository vaultsRepo)
        {
            _vaultKeepsRepo = vaultKeepsRepo;
            _vaultsRepo = vaultsRepo;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            Vault vault = _vaultsRepo.GetById(newVaultKeep.VaultId);
            if(vault.CreatorId != newVaultKeep.CreatorId)
            {
                throw new System.Exception("You cannot add a Keep in here.");
            }
            //get the vault
            //if vault.creatorId != newVaultKeep.creatorId
            //throw new exception
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