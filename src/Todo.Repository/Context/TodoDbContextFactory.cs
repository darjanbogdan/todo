using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Todo.Repository.Context
{
    public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        //Note: Change when possible, at the moment args param is not supported. https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
        public TodoDbContext CreateDbContext(string[] args)
        {
            string connectionString = ReadConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new TodoDbContext(optionsBuilder.Options);
        }

        internal string ReadConnectionString()
        {
            using (StreamReader streamReader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + "appsettings.json"))
            using (JsonReader settingsReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                AppSettings settings = serializer.Deserialize<AppSettings>(settingsReader);
                return settings.TodoDbContextConfiguration.ConnectionString;
            }
        }

        internal class AppSettings
        {
            public DbContextConfiguration TodoDbContextConfiguration { get; set; }

            internal class DbContextConfiguration
            {
                public string ConnectionString { get; set; }
            }
        }
    }
}
