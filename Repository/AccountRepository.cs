using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Account>> AccountsByOwnerAsync(Guid ownerId)
        {
            var account = await FindByConditionAsync(a => a.OwnerId.Equals(ownerId));
            return account.OrderBy(x => ownerId);
        }
    }
}