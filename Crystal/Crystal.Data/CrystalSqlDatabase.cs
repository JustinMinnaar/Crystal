using System.Data.SqlClient;

namespace Crystal.Data
{
    public class CrystalSqlDatabase
    {
        private SqlConnection cn;

        public CrystalSqlDatabase(SqlConnection cn)
        {
            this.cn = cn;
            cn.Open();
        }
    }
}