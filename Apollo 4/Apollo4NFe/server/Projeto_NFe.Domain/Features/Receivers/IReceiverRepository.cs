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
		bool Update(Receiver receiver);
		Receiver Get(long id);
		IQueryable<Receiver> GetAll();
		IQueryable<Receiver> GetAll(int size);
		bool Delete(long receiverId);
		bool CheckDependency(Receiver receiver);
	}
}
