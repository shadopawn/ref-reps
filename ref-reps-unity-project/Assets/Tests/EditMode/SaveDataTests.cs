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
        
        private String _customFilePath = Application.dataPath + "/SaveData/testSave.json";

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
        public void TestCreateDirectoryCustomPath()
        {
            SaveData saveData = new SaveData(_customFilePath);
            String directory = Path.GetDirectoryName(_customFilePath);
            bool directoryExists = Directory.Exists(directory);
            Assert.True(directoryExists);
        }
        
        [Test]
        public void TestCreateSaveFileCustomPath()
        {
            SaveData saveData = new SaveData(_customFilePath);
            bool fileExists = File.Exists(_customFilePath);
            Assert.True(fileExists);
        }

        [Test]
        public void TestCompleteLessonPair()
        {
            SaveData saveData = new SaveData(_customFilePath);
            saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expecteText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'completed': true 
                    } 
                } 
            }";
            JObject saveFileJObject = JObject.Parse(saveFileText);
            JObject expectedJObject = JObject.Parse(expecteText);
            Assert.AreEqual(saveFileJObject, expectedJObject);
        }
        
        [Test]
        public void TestCompleteLessonPairMultipleUnique()
        {
            SaveData saveData = new SaveData(_customFilePath);
            saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            saveData.CompleteLessonPair("Lesson Pack 2", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expecteText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'completed': true 
                    } 
                },
                'Lesson Pack 2': {
                    'Video 2': {
                        'completed': true
                    }
                } 
            }";
            JObject saveFileJObject = JObject.Parse(saveFileText);
            JObject expectedJObject = JObject.Parse(expecteText);
            Assert.AreEqual(saveFileJObject, expectedJObject);
        }
        
        [Test]
        public void TestCompleteLessonPairMultipleInPack()
        {
            SaveData saveData = new SaveData(_customFilePath);
            saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            saveData.CompleteLessonPair("Lesson Pack 1", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expecteText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'completed': true 
                    },
                    'Video 2': { 
                        'completed': true 
                    },
                } 
            }";
            JObject saveFileJObject = JObject.Parse(saveFileText);
            JObject expectedJObject = JObject.Parse(expecteText);
            Assert.AreEqual(saveFileJObject, expectedJObject);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_customFilePath);
        }
    }
}
