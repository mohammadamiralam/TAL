using System;
using System.Collections.Generic;
using System.Text;
using TAL.Core.ViewModels;

namespace TAL.Core.Interfaces.Repo
{
    public interface IPremiumCalculator
    {
        double Calculate(UserDetails userDetails);
    }
}
