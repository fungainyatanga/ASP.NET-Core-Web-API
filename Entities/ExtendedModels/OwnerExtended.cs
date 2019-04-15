using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.ExtendedModels
{
    //extended owner model (or DTO) which will help you return the owner with all related accounts to it.
    public class OwnerExtended
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public IQueryable<Account> Accounts { get; set; }

        public OwnerExtended(Owner owner)
        {
            Id = owner.Id;
            Name = owner.Name;
            DateOfBirth = owner.DateofBirth;
            Address = owner.Address;
        }
    }
}
