﻿using System.Configuration;
using Data.Mappings;
using Highway.Data;

namespace DataTestsMspec
{
    public static class Helper
    {
        public static IDataContext RealDataContext()
        {
            var connectionString = ConfigurationManager.AppSettings["connectionString"];
            return new DataContext(connectionString, new ConferenceDemoMappingConfiguration());
        }
    }
}