using Keeper.Models;
using Keeper.Repositories;
using System.Collections.Generic;

namespace Keeper.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vaultsRepo;
        public VaultsService(VaultsRepository vaultsRepo)
        {
            _vaultsRepo = vaultsRepo;
        }

        internal Vault Create(Vault newVault)
        {
            return _vaultsRepo.Create(newVault);
        }

        internal Vault GetById(int id)
        {
            Vault found = _vaultsRepo.GetById(id);
            if(found == null)
            {
                throw new System.Exception("Invalid id");
            }
            return found;
        }

        internal List<Vault> GetProfileVaults(string id)
        {
            List<Vault> vaults = _vaultsRepo.GetProfileVaults(id);
            return vaults;
        }

        internal void Delete(int vaultId, string userId)
        {
            Vault toDelete = GetById(vaultId);
            if(toDelete.CreatorId != userId)
            {
                throw new System.Exception("Thats not your vault.");
            }
            _vaultsRepo.Delete(vaultId);
        }

        internal Vault Edit(Vault updatedVault)
        {
            Vault original = GetById(updatedVault.Id);
            if(original.CreatorId != updatedVault.CreatorId)
            {
                throw new System.Exception("Hands off Buddy!");
            }
            original.Name = updatedVault.Name != null ? updatedVault.Name : original.Name;
            original.Description = updatedVault.Description != null ? updatedVault.Description : original.Description;
            original.IsPrivate = updatedVault.IsPrivate != null ? updatedVault.IsPrivate : original.IsPrivate;
            _vaultsRepo.Edit(original);
            return original;
        }

    }
}