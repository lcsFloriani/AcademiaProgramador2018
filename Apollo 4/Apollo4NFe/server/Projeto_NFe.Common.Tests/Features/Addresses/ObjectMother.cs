using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{ 
    public partial class ObjectMother
    {
        public static Address GetAddress()
        {
            return new Address()
            {
                Street = "ABC",
                Number = 12,
                Neighbourhood = "Coral",
                City = "Lages",
                State = State.SC
            };
        }

        public static Address GetAddressInvalidStreet()
        {
            return new Address()
            {
                Street = "",
                Number = 12,
                Neighbourhood = "Coral",
                City = "Lages",
                State = State.SC
            };
        }

        public static Address GetAddressInvalidNeighbourhood()
        {
            return new Address()
            {
                Street = "ABC",
                Number = 12,
                Neighbourhood = "",
                City = "Lages",
                State = State.SC
            };
        }

        public static Address GetAddressInvalidCity()
        {
            return new Address()
            {
                Street = "ABC",
                Number = 12,
                Neighbourhood = "Coral",
                City = "",
                State = State.SC
            };
        }

        public static Address GetAddressInvalidNumber()
        {
            return new Address()
            {
                Street = "ABC",
                Number = -1,
                Neighbourhood = "Coral",
                City = "Lages",
                State = State.SC
            };
        }

        public static Address GetAddressInvalidState()
        {
            return new Address()
            {
                Street = "ABC",
                Number = 1,
                Neighbourhood = "Coral",
                City = "Lages",
                State = State.DEFAULT
            };
        }
    }
}
