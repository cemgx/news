﻿using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<SubscribeMail> SubscribeMails { get; set; }
    }
}
