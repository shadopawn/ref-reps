using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditorTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(true, true);
        }
        
        [Test]
        public async Task RetrieveData()
        {
            Database database = new Database();
            await database.ReadTestValue();
            
            Assert.AreEqual(database.GetTestValue(), "test");
        }
    }
}
