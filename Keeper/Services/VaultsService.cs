using Keeper.Models;
using Keeper.Repositories;

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

        internal void Delete(int vaultId, string userId)
        {
            Vault toDelete = GetById(vaultId);
            if(toDelete.CreatorId != userId)
            {
                throw new System.Exception("Thats not your vault.");
            }
            _vaultsRepo.Delete(vaultId);
        }

    }
}