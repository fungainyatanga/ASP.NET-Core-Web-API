using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /**context class, which has a middleware component for the communication with the database. 
     * It has DbSet properties which contain the table data from the database.
     * To enable communication between the .NET core part and the MySQL database, 
     * you’ll need to install a third-party library named Pomelo.EntityFrameworkCore.MySql
     */
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
       
    }
}
