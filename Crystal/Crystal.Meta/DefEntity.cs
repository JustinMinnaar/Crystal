using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal.Meta
{
    public class DefEntity
    {
        private List<DefField> fields = new List<DefField>();

        public IEnumerable<DefField> Fields => fields;
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public DefField AddField(string name, DefFieldType type)
        {
            var field = new DefField { Name = name, Type = type };
            fields.Add(field);
            return field;
        }

        // Note: used for building names of tables in database
        public override string ToString() => NamePlural;
    }
}
