using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Domain.Features.Functionaries
{
    public class Functionary
    {
        public long Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public bool Status { set; get; }
        public OfficeEnum Office { set; get; }

        public void ChangeStatus(bool newStatus)
        {
            Status = newStatus;
        }

        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
