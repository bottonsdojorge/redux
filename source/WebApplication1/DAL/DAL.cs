using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DAL
    {
        protected string connectionString = "";
        public DAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
        }
    }
}