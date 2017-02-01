using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Data
{
    public class CrystalSqlAdapter
    {
        public CrystalSqlDatabase Connect(string database)
        {
            // Data Source=;
            // Initial Catalog=Crystal;
            // 
            var sb = new SqlConnectionStringBuilder();
            sb.InitialCatalog = database;
            sb.DataSource = "(localdb)\\MSSQLLocalDB";
            sb.IntegratedSecurity = true;
            sb.ConnectTimeout = 10;
            sb.Encrypt = false;
            sb.TrustServerCertificate = true;
            sb.ApplicationIntent = ApplicationIntent.ReadWrite;
            sb.MultiSubnetFailover = false;

            var cn = new SqlConnection(sb.ToString());
            return new CrystalSqlDatabase(cn);
        }
    }
}
