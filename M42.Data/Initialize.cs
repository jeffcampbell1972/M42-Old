using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace M42.Data
{
    public class Initialize
    {
        public static M42Context GetContext()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=M42Db;Trusted_Connection=True;";

            DbContextOptionsBuilder<M42Context> options = new DbContextOptionsBuilder<M42Context>();
            options.UseSqlServer(connectionString);

            return new M42Context(options.Options);
        }
    }
}
