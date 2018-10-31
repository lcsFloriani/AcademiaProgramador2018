using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Receivers
{
    public interface IReceiverRepository
    {
       Receiver Save(Receiver receiver);
       Receiver Update(Receiver receiver);
       Receiver Get(long id);
       IEnumerable<Receiver> GetAll();
       void Delete(Receiver receiver);
       bool CheckDependency(Receiver receiver);
    }
}
