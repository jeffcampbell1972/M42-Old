using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using M42.Data;
using M42.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M42.Data.Initializer
{
    public static class SqlService
    {
        public static void ExecuteSqlScript(M42Context context, string scriptName)
        {
            string sql = System.IO.File.ReadAllText(scriptName);

            context.Database.ExecuteSqlRaw(sql);
        }
    }
}