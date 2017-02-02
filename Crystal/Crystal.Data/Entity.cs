using Crystal.Meta;
using System;
using System.Collections.Generic;

namespace Crystal.Data
{
    public class Entity
    {
        public Guid Guid { get; set; }
        public DefEntity DefEntity { get; set; }
        public Dictionary<DefField, object> FieldValues = new Dictionary<DefField, object>();

        public Entity()
        {

        }

        public Entity(DefEntity defEntity)
        {
            this.DefEntity = defEntity;
            Guid = Guid.NewGuid();
        }

        public void AddValue(DefField field, object value)
        => FieldValues.Add(field, value);

        public object TryGetValue(DefField defField, object defaultValue = null)
        {
            object value = defaultValue;
            FieldValues.TryGetValue(defField, out value);
            return value;
        }
    }
}