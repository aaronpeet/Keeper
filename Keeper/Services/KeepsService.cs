using Keeper.Models;
using Keeper.Repositories;
using System.Collections.Generic;

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

        internal List<Keep> Get()
        {
            return _keepsRepo.Get();
        }

        internal Keep GetById(int id)
        {
            Keep found = _keepsRepo.GetById(id);
            if(found == null)
            {
                throw new System.Exception("invalid id");
            }
            return found;
        }

    }
}