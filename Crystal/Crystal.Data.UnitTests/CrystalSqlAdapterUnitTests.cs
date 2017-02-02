using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crystal.Data;
using Crystal.Meta;

namespace Crystal.Data.UnitTests
{
    [TestClass]
    public class CrystalSqlAdapterUnitTests
    {
        private CrystalSqlDatabase db;

        public CrystalSqlAdapterUnitTests()
        {
            var adapter = new CrystalSqlAdapter();
            db = adapter.Connect(database: "Crystal");
        }

        [TestMethod]
        public void AddPerson()
        {
            var tText = new DefFieldTypeText { MaxLength = 50 };

            var ePerson = new DefEntity { Name = "Person", NamePlural = "People" };
            var fPerson_Name = ePerson.AddField(name: "Name", type: tText);
            var fPerson_Color = ePerson.AddField(name: "Color", type: tText);

            var values = new Entity(ePerson);
            values.AddValue(fPerson_Name, "Justin");

            db.Create(values);
        }

        [TestMethod]
        public void CanEstablishConnectionToDatabase()
        {
            Assert.IsNotNull(db);
        }
    }
}
