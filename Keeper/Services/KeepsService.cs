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

        internal Keep Edit(Keep updatedKeep)
        {
            Keep original = GetById(updatedKeep.Id);
            if(original.CreatorId != updatedKeep.CreatorId)
            {
                throw new System.Exception("Hands off buddy.");
            }
            original.Name = updatedKeep.Name != null ? updatedKeep.Name : original.Name;
            original.Description = updatedKeep.Description != null ? updatedKeep.Description : original.Description;
            original.Img = updatedKeep.Img != null ? updatedKeep.Img : original.Img;
            original.Views = updatedKeep.Views != null ? updatedKeep.Views : original.Views;
            original.Shares = updatedKeep.Shares != null ? updatedKeep.Shares : original.Shares;
            original.Keeps = updatedKeep.Keeps != null ? updatedKeep.Keeps : original.Keeps;
            _keepsRepo.Edit(original);
            return original;
        }

    }
}