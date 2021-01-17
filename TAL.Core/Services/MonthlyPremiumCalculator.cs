using System;
using System.Collections.Generic;
using System.Text;
using Tal.Core.Interfaces.Repo;
using TAL.Core.Interfaces.Repo;
using TAL.Core.ViewModels;

namespace TAL.Core.Services
{
    public class MonthlyPremiumCalculator : IPremiumCalculator
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IOccupationRepository _occupationRepository;
        public MonthlyPremiumCalculator(IRatingRepository ratingRepository, IOccupationRepository occupationRepository)
        {
            _ratingRepository = ratingRepository;
            _occupationRepository = occupationRepository;
        }
        public double Calculate(UserDetails userDetails)
        {

            double factor = _ratingRepository.GetRating(userDetails.Occupation.RatingId).Factor;
            double premium = (userDetails.SumInsured * factor * userDetails.Age) / 1000 * 12;

            return premium;
        }
    }
}
