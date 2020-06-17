using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanRza.Extensions
{
    public static class StringExtensions
    {
        public static string GetMultipleAndLowerCase(this string str)
        {
            if (str == null) return null;
            else return str.ToLower() + "s";
        }
    }
}
