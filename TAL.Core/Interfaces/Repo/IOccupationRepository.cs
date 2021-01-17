
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAL.Core.ViewModels;

namespace Tal.Core.Interfaces.Repo
{
    public interface IOccupationRepository
    {
        IEnumerable<Occupation> GetOccupations();
        Occupation GetOccupation(int id);
    }
}
