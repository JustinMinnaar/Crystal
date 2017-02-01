using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crystal.Data;

namespace Crystal.Data.UnitTests
{
    [TestClass]
    public class CrystalSqlAdapterUnitTests
    {
        [TestMethod]
        public void CanEstablishConnectionToDatabase()
        {
            var adapter = new CrystalSqlAdapter();

            var db = adapter.Connect(database: "Crystal");

            Assert.IsNotNull(db);
        }
    }
}
