using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ByteartRetail.DataObjects;
using Keasy5.Domain.Model;

namespace Keasy5.Application.Mapping
{
    public class InversedAddressResolver : ValueResolver<Address, AddressDataObject>
    {
        protected override AddressDataObject ResolveCore(Address source)
        {
            return new AddressDataObject
            {
                City = source.City,
                Country = source.Country,
                State = source.State,
                Street = source.Street,
                Zip = source.Zip
            };
        }
    }
}
