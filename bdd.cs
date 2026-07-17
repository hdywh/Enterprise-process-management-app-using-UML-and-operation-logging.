using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Diplom
{

    internal class bdd
    {
        private readonly string connectionString =
            @"Data Source=aqua;Initial Catalog=УправлениеПроцессами;Integrated Security=True;Encrypt=False";

        public SqlConnection GetCon()
        {
            return new SqlConnection(connectionString);
        }
    }
}