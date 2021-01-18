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
        //private readonly IOccupationRepository _occupationRepository;
        public MonthlyPremiumCalculator(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
            //_occupationRepository = occupationRepository;
        }
        public double Calculate(UserDetails userDetails)
        {
            if (userDetails == null)
                throw new ArgumentNullException("UserDetails class is null");
            if(userDetails.Age < 1)
                throw new ArgumentException("Age value should be > 0");
            if (userDetails.SumInsured < 1)
                throw new ArgumentException("SumInsured value should be > 0");
            if(userDetails.Occupation == null)
                throw new ArgumentNullException("Occupation is null");
            var rating = _ratingRepository.GetRating(userDetails.Occupation.RatingId);
            
            if (rating == null || rating.Factor < 1)
                throw new ArgumentException("Factor value should be > 0");
            double premium = (userDetails.SumInsured * rating.Factor * userDetails.Age) / 1000 * 12;

            return premium;
        }
    }
}
