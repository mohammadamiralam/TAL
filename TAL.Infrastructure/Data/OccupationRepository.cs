using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tal.Core.Interfaces.Repo;
using TAL.Core.ViewModels;

namespace TAL.Infrastructure.Data
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly IEnumerable<Occupation> _occupations = null;
        public OccupationRepository()
        {
            List<Occupation> occupations = new List<Occupation>();
            occupations.Add(new Occupation() { Id = 1, Name = "Cleaner", RatingId = 3 });
            occupations.Add(new Occupation() { Id = 2, Name = "Doctor", RatingId = 1 });
            occupations.Add(new Occupation() { Id = 3, Name = "Author", RatingId = 2 });
            occupations.Add(new Occupation() { Id = 4, Name = "Farmer", RatingId = 4 });
            occupations.Add(new Occupation() { Id = 5, Name = "Mechanic", RatingId = 4 });
            occupations.Add(new Occupation() { Id = 6, Name = "Florist", RatingId = 3 });
            _occupations = occupations;
        }

        public Occupation GetOccupation(int id)
        {
            return _occupations.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Occupation> GetOccupations()
        {
            try
            {
                var occupation = _occupations
                    .ToList();
                return occupation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
