using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Extension_Methods
{
    public static class DateHelper
    {
        public static bool CompareDateSmallerCurrent(this DateTime dt)
        {
            int result = DateTime.Compare(dt, DateTime.Now);
            if (result < 0)
            {
                return true;
            }

            return false;
        }

        public static bool CompareDateSmallerThan(this DateTime dt, DateTime dt2)
        {
            int result = DateTime.Compare(dt, dt2);
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
