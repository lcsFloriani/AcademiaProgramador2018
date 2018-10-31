using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.Querys;
using Enedir.MF7.Domain.Exceptions;
using Enedir.MF7.Domain.Features.Functionaries;

namespace Enedir.MF7.Application.Features.Functionaries
{
    public class FunctionaryService : IFunctionaryService
    {
        private IFunctionaryRepository _repository;

        private long _lessThan = 1;

        public FunctionaryService(IFunctionaryRepository repository)
        {
            _repository = repository;
        }

        public long Add(FunctionaryRegisterCommand command)
        {
            Functionary functionary = command.ConvertToObject();

            var newFunctionary = _repository.Save(functionary);

            return newFunctionary.Id;
        }

        public bool ChangeStatus(FunctionaryChangeStatusCommand command)
        {
            Functionary functionary = command.ConvertToObject();

            var register = GetById(functionary.Id);

            register.ChangeStatus(functionary.Status);

            return _repository.Update(register);
        }

        public bool CredentialVerify(string user, string password)
        {
            return _repository.CheckCredential(user, password);
        }

        public IQueryable<Functionary> GetAll(FunctionaryQuery query)
        {
            return _repository.GetAll(query.Quantity);
        }

        public Functionary GetById(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return _repository.GetById(id);
        }

        public bool Remove(FunctionaryDeleteCommand command)
        {
            var deleteFunctionary = _repository.GetById(command.Id);

            if (CheckDependecy(deleteFunctionary))
                return _repository.Update(deleteFunctionary);

            return _repository.Delete(deleteFunctionary);
        }

        public bool Update(FunctionaryUpdateCommand command)
        {
            Functionary functionary = command.ConvertToObject();

            return _repository.Update(functionary);
        }

        private bool CheckDependecy(Functionary functionary)
        {

            bool hasDependency = _repository.HasDependency(functionary);

            if (hasDependency)
            {
                functionary.Status = false;
                functionary.ChangeStatus(functionary.Status);
            }

            return hasDependency;

        }
    }
}
