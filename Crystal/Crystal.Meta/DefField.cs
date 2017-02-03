namespace Crystal.Meta
{
    public class DefField
    {
        public string Name { get; internal set; }
        public DefFieldType Type { get; internal set; }

        // Note: used for building names of columns in database
        public override string ToString() => Name;
    }
}