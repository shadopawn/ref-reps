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
            var testValue = await _database.ReadTestValue();
            Assert.AreEqual(testValue, "test");
        }
        
        [UnityTest]
        public async Task TestGetVideoURL()
        {
            var testValue = await _database.GetVideoURL("test.mp4");
            Assert.NotNull(testValue);
        }
        
        [UnityTest]
        public async Task TestGetVideoURL2()
        {
            var testValue = await _database.GetVideoURL("ForcePlaySlideAnalysis.mp4");
            Assert.NotNull(testValue);
        }
        
        [UnityTest]
        public async Task TestDatabaseFailToGetVideoURL()
        {
            var testValue = await _database.GetVideoURL("nonExistent.mp4");
            Assert.AreEqual(testValue, "");
        }

        [UnityTest]
        public async Task TestDatabaseGetLessonPacksJson()
        {
            var json = await _database.GetLessonPacksJson();
            Assert.NotNull(json);
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
