using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ShortenURLCoreApp.Models
{
    public class UrlDbContext:DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> option) : base(option)
        {
        }
        public DbSet<UrlModel> Url { get; set; }
       
       

    }
}
