using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    internal abstract class BaseADO
    {
        protected readonly string _connString;
        public BaseADO()
        {
            _connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
    }
}
