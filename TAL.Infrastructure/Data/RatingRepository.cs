using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tal.Core.Interfaces.Repo;
using TAL.Core.ViewModels;

namespace TAL.Infrastructure.Data
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IEnumerable<Rating> _ratings = null;
        public RatingRepository()
        {
            List<Rating> ratings = new List<Rating>();
            ratings.Add(new Rating() { Id = 1, Name = "Professional", Factor = 1.00 });
            ratings.Add(new Rating() { Id = 2, Name = "White Collar", Factor = 1.25 });
            ratings.Add(new Rating() { Id = 3, Name = "Light Manual", Factor = 1.50 });
            ratings.Add(new Rating() { Id = 4, Name = "Heavy Manual", Factor = 1.75 });
            _ratings = ratings;
        }

        public Rating GetRating(int id)
        {
            return _ratings.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Rating> GetRatings()
        {
            try
            {
                return _ratings.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
