using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addresses
{
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public Country Country { get => Country.Brasil; }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Street))
                throw new AddressStreetNullOrEmptyException();

            if (string.IsNullOrEmpty(Neighbourhood))
                throw new AddressNeighbourhoodNullOrEmptyException();

            if (string.IsNullOrEmpty(City))
                throw new AddressCityNullOrEmptyException();

            if (Number < 1)
                throw new AddressNumberLessThanOneException();

            if (State == State.DEFAULT)
                throw new AddressDefaultStateEnumException();
        }
    }
}
