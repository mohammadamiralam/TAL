using System.Collections.Generic;
using TAL.Core.ViewModels;

namespace Tal.Core.Interfaces.Repo
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetRatings();
        Rating GetRating(int id);
    }
}
