using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbControlService
{
    public partial class StationContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //以builder建立連線字串增加安全性
            System.Data.SqlClient.SqlConnectionStringBuilder builder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder["Data Source"] = "(localdb)\\mssqllocaldb";
            builder["Database"] = "Station";
            builder["Trusted_Connection"] = "True";
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
    }
}
