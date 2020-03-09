﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity; //inheritance of DbContext from EntityFramework
using FSISSystem.ENTITIES;
#endregion

namespace FSISSystem.DAL
{
    internal class FSISContext : DbContext
    {
        public FSISContext() : base(FSIS_db)
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Guardian> Guardians { get; set; }

    }
}
