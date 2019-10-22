using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseApplication.DAL
{
    class Base
    {
        protected SqlConnection _conn;

        public Base()
        {
            _conn = new SqlConnection(Properties.Settings.Default.CourseConn);
        }
    }
}
