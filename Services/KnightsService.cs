using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class KnightsService
    {

        private readonly KnightRepository _repo;

        public KnightsService(KnightRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Knight> Get()
        {
            return (_repo.Get());
        }

        internal Knight Get(int id)
        {
            return (_repo.Get(id));
        }

        internal Knight Create(Knight knight)
        {
            return (_repo.Create(knight));
        }

        internal Knight Edit(int id, Knight knight)
        {
            Knight original = Get(id);

            original.Name = knight.Name != null ? knight.Name : original.Name;
            original.Title = knight.Title != null ? knight.Title : original.Title;
            original.Age = knight.Age > -99 ? knight.Age : original.Age;

            return (_repo.Edit(original));
        }

        internal Knight Delete(int id)
        {
            Knight original = Get(id);
            _repo.Delete(id);
            return original;
        }

        internal IEnumerable<CastleKnight> GetByCastle(int id)
        {
            return (_repo.GetByCastle(id));
        }
    }
}