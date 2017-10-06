using System;
using Microsoft.Extensions.Configuration;
using Domains;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Datas
{
    //Db上下文
    public class VueDbContext:DbContext
    {
        public VueDbContext(DbContextOptions<VueDbContext> options) :base(options)
        { 

        }
        
        //问候语
        public DbSet<Greeting> Greetings { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<Greeting>().HasKey(m => m.Id); 
            base.OnModelCreating(builder); 
        } 
    }
}