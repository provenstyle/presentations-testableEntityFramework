using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Highway.Data;

namespace Data.Mappings
{
    public class ConferenceDemoMappingConfiguration : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Talk>();
            modelBuilder.Entity<Speaker>();
        }
    }
}
