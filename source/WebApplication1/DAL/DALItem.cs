using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class DALItem
    {
        string connectionString = "";
        public DALItem()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;
        }

        public List<Modelo.Item> SelectAll()
        {

        }
    }
}