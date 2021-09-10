using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _keepsRepo;

        public KeepsService(KeepsRepository keepsRepo)
        {
            _keepsRepo = keepsRepo;
        }

        internal Keep Create(Keep newKeep)
        {
            Keep keep = _keepsRepo.Create(newKeep);
            return keep;
        }

    }
}