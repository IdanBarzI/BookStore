using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Service
{
    public enum DbTechnology 
    {
        Sql,
        MongoDb
    }

    public class DbConfig
    {
        const string SQL_CONNECTION_STR = "Server=(localdb)\\BookStoreDb; Database=BookStoreDb;Trusted_Connection=True";

        public static string GetConnectionString(DbTechnology dbType)
        {
            switch (dbType)
            {
                case DbTechnology.Sql:
                    return SQL_CONNECTION_STR;
                case DbTechnology .MongoDb:
                    return "";
                default:
                    return "";
            }
        }
    }
}
