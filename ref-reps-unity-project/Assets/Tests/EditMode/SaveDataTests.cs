using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Newtonsoft.Json.Linq;

namespace Tests
{
    public class SaveDataTests 
    {
        private SaveData _saveData;
        
        private string _saveDirectory;
        private string _saveFile;

        [SetUp]
        public void Setup()
        {
            _saveData = new SaveData();
            
            _saveDirectory = Application.dataPath + "/SaveData";
            _saveFile = _saveDirectory + "/userInfo.json";
        }
        
        [Test]
        public void TestCreateDirectory()
        {
            bool directoryExists = Directory.Exists(_saveDirectory);
            Assert.True(directoryExists);
        }
        
        [Test]
        public void TestCreateSaveFile()
        {
            bool fileExists = File.Exists(_saveFile);
            Assert.True(fileExists);
        }

        [Test]
        public void TestCompleteLessonPair()
        {
            _saveData.CompleteLessonPair("", "");
            Assert.True(true);
        }
    }
}
