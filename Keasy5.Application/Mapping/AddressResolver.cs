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
    public class AddressResolver : ValueResolver<AddressDataObject, Address>
    {
        protected override Address ResolveCore(AddressDataObject source)
        {
            return new Address
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
