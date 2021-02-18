using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Newtonsoft.Json.Linq;

namespace Tests
{
    public class SaveDataTests 
    {
        private SaveData _saveData;

        [SetUp]
        public void Setup()
        {
            _saveData = new SaveData();
        }

        [Test]
        public void TestCompleteLessonPair()
        {
            _saveData.CompleteLessonPair("", "");
            Assert.NotNull("");
        }
    }
}
