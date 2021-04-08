using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class CastlesService
    {
        private readonly CastleRepository _repo;

        public CastlesService(CastleRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> Get()
        {
            return (_repo.Get());
        }

        internal Castle Get(int id)
        {
            return (_repo.Get(id));
        }

        internal Castle Create(Castle castle)
        {
            return (_repo.Create(castle));
        }

        internal Castle Edit(int id, Castle castle)
        {
            Castle original = Get(id);

            original.Name = castle.Name != null ? castle.Name : original.Name;
            original.Year = castle.Year > -999 ? castle.Year : original.Year;
            original.Size = castle.Size != null ? castle.Size : original.Size;
            original.KingName = castle.KingName != null ? castle.KingName : original.Size;
            return (_repo.Edit(original));
        }

        internal Castle Delete(int id)
        {
            Castle original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}