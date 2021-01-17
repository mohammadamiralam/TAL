using System;
using System.Collections.Generic;
using System.Text;

namespace TAL.Core.ViewModels
{
    public class UserDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public Occupation Occupation { get; set; }
        public double SumInsured { get; set; }
    }


}
