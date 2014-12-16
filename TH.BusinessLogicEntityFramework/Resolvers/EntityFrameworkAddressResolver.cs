using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Resolvers
{
    public class EntityFrameworkAddressResolver : ValueResolver<List<Domain.Address>, List<Address>>
    {
        protected override List<Address> ResolveCore(List<Domain.Address> source)
        {
            return source.Select(a => new Address
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
