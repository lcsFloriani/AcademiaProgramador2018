using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.infra.Util
{
    public static class NumberUtil
    {

        public static bool IsNumber(string value) {
            return Regex.IsMatch(value, @"^\d+$");
        }
    }
}
