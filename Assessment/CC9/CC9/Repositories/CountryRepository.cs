using CC9.Models;
using System.Collections.Generic;
using System.Linq;

namespace CC9.Repositories
{
    public class CountryRepository
    {

        private static readonly List<Country> _countries = new List<Country>
         {
             new Country { Id = 1, CountryName = "India", Capital = "New Delhi" },
             new Country { Id = 2, CountryName = "USA", Capital = "Washington, D.C." }
         };

        public IEnumerable<Country> GetAll() => _countries;

        public Country Get(int id) => _countries.FirstOrDefault(c => c.Id == id);

        public Country Add(Country c)
        {
            var nextId = _countries.Count == 0 ? 1 : _countries.Max(x => x.Id) + 1;
            c.Id = nextId;
            _countries.Add(c);
            return c;
        }

        public bool Update(int id, Country updated)
        {
            var existing = Get(id);
            if (existing == null) return false;
            existing.CountryName = updated.CountryName;
            existing.Capital = updated.Capital;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = Get(id);
            if (existing == null) return false;
            _countries.Remove(existing);
            return true;
        }
    }
}
