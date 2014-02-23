using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mwvlog.Models
{
    public class VlogDb : DbContext
    {

        public VlogDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<MoviePost> MoviePosts { get; set; }
    }
}