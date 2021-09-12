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

    }
}