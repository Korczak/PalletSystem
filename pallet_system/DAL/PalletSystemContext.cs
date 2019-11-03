using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pallet_system.Extensions;
using pallet_system.Interfaces;
using pallet_system.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace pallet_system.DAL
{
    /// <summary>
    /// Database of Pallet System
    /// </summary>
    public class PalletSystemContext : DbContext
    {
        public PalletSystemContext(DbContextOptions<PalletSystemContext> options) : base(options)
        {
        }

        public virtual DbSet<Pallet> PALLET { get; set; }
        public virtual DbSet<VirtualPallet> VIRTUAL_PALLET { get; set; }
        public virtual DbSet<ProgramData> PROGRAM { get; set; }
        public virtual DbSet<ProgramInfo> PROGRAM_INFO { get; set; }
        public virtual DbSet<StepData> STEP_DATA { get; set; }
        public virtual DbSet<Status> STATUS { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
