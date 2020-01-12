using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DanoSoldatBPV;
using System.Data.Entity.ModelConfiguration;

namespace DataClass
{
    class ArmyDBContext : DbContext
    {
        //static ArmyDBContext()
        //{
        //    Database.SetInitializer<ArmyDBContext>(new DBInit());
        //}
        public ArmyDBContext() : base("SoldeirDB")
        { }
        public DbSet<SoldierData> SoldierDatas { get; set; }
        public DbSet<PsychoTest> PsychoTests { get; set; }
    }

    //class DBInit: DropCreateDatabaseIfModelChanges<ArmyDBContext>
    //{ 

    //}
}
