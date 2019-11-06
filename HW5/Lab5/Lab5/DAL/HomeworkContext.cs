using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;
using System.Data.Entity;

namespace Lab5.DAL
{
    public class HomeworkContext : DbContext
    {
        public HomeworkContext() : base("name=ourHomeworkDB")
        {

        }

        public virtual DbSet<Homework> Homework { get; set; }

    }
}