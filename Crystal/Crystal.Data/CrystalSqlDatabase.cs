using Crystal.Core;
using Crystal.Meta;
using System;
using System.Data.SqlClient;
using System.Text;

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

        public void Create(Entity entity)
        {
            var defEntity = entity.DefEntity;

            var cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("Guid", entity.Guid);

            string values = null;

            var table = defEntity.NamePlural;
            foreach (var fv in entity.FieldValues)
            {
                var name = fv.Key.Name;
                var value = fv.Value;

                if (values != null) values += ", ";
                values += "@" + name;

                cmd.Parameters.AddWithValue(name, value);
            }

            var fields = values.Replace("@", "");
            var sql = $"INSERT {table} (Guid, {fields}) VALUES (@Guid, {values});";

            cmd.Connection = cn;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
        }
    }
}