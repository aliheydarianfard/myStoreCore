using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Ahf.Data
{
	public class SqlServerApplicationContext:DbContext,IApplcationDbContext
	{
		public SqlServerApplicationContext(DbContextOptions option)
		   : base(option)
		{

		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MyStoreDB;Integrated Security=true;");
		//	base.OnConfiguring(optionsBuilder);
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerApplicationContext).Assembly);
            //modelBuilder.SetCreateOn();
            base.OnModelCreating(modelBuilder);
        }

        public override EntityEntry Update([NotNullAttribute] object entity)
        {

            return base.Update(entity);
        }
    }
}
