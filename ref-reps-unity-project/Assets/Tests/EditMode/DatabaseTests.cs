using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class DatabaseTests
    {

        private Database _database;
        
        
        [SetUp]
        public void Setup()
        {
            _database = new Database();
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
        
    }
}
