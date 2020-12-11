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

        private Database _database;
        
        [SetUp]
        public void Setup()
        {
            _database = new Database();
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(true, true);
        }
        
        [UnityTest]
        public async Task RetrieveData()
        {
            var task = Task.Run(async () =>
            {
                return await _database.ReadTestValue();
            }).GetAwaiter().GetResult();
            Debug.Log(task);
            Assert.AreEqual(task, "test");
        }
        
        [Test]
        public void TestAwait()
        {
            var task = Task.Run(async () =>
            {
                return await GetTestTaskAsync();
            });
 
            Assert.AreEqual(1, task.Result);
        }
 
        public async Task<int> GetTestTaskAsync()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(200));
            return 1;
        }
    }
}
