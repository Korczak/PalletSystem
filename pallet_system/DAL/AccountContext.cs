using Microsoft.EntityFrameworkCore;
using pallet_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pallet_system.DAL
{
    /// <summary>
    /// Database for accounts
    /// </summary>
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        public virtual DbSet<WebUser> WEBUSERS { get; set; }
        public virtual DbSet<WebRole> WEBROLES { get; set; }
        public virtual DbSet<WebUserInRole> WEBUSERINROLES { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
