using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO
    {
        protected readonly string _connString;
        //protected readonly SqlConnection _connection;
        public BaseADO()
        {
            //_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            //_connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            _connString = @"Data Source=LAPTOP-6JLD6U9U\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
    }
}
