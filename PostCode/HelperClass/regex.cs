using PostCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostCode.HelperClass
{
    public class regex : Iregex
    {
        public bool validatePostCode(string pc)
        {
            return Regex.IsMatch(pc, "(^[A-Za-z][1-9] [1-9][A-Za-z]{2}$)");
        }
    }
}
