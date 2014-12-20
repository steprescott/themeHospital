using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Resolvers
{
    public class DomainAddressResolver : ValueResolver<HashSet<Address>, List<Domain.Address>>
    {
        protected override List<Domain.Address> ResolveCore(HashSet<Address> source)
        {
            return source.Select(a => new Domain.Address
            {
                AddressId = a.AddressId,
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                AddressLine3 = a.AddressLine3,
                City = a.City,
                PostCode = a.PostCode,
                IsCurrentAddress = a.IsCurrentAddress
            }).ToList();
        }
    }
}
