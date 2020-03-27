using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Data
{
    class DesignTimeIdentityDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {



        public AppDbContext CreateDbContext(string[] args)
        {


            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NV0GSA0\\SQLEXPRESS;Initial Catalog=UdemyNLayerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new AppDbContext(optionsBuilder.Options);





        }




    }
}
