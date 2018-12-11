using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestGroupeClients
    {
        [TestMethod]
        public void TestConstructeur()
        {
            int nombre = 6;
            GroupeClients clients = new GroupeClients(nombre);
            Assert.AreEqual(nombre, clients.nombre);
        }
    }
}
