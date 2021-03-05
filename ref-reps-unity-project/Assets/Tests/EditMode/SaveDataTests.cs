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
        
        private readonly string _customFilePath = Application.dataPath + "/SaveData/testSaveData.json";

        [SetUp]
        public void Setup()
        {
            _saveData = new SaveData(_customFilePath);

            _saveDirectory = Application.dataPath + "/SaveData";
            _saveFile = _saveDirectory + "/userInfo.json";
        }
        
        [Test]
        public void TestCreateDirectory()
        {
            SaveData defaultSaveData = new SaveData();
            bool directoryExists = Directory.Exists(_saveDirectory);
            Assert.True(directoryExists);
        }
        
        [Test]
        public void TestCreateSaveFile()
        {
            SaveData defaultSaveData = new SaveData();
            bool fileExists = File.Exists(_saveFile);
            Assert.True(fileExists);
        }
        
        [Test]
        public void TestCreateDirectoryCustomPath()
        {
            String directory = Path.GetDirectoryName(_customFilePath);
            bool directoryExists = Directory.Exists(directory);
            Assert.True(directoryExists);
        }
        
        [Test]
        public void TestCreateSaveFileCustomPath()
        {
            bool fileExists = File.Exists(_customFilePath);
            Assert.True(fileExists);
        }

        [Test]
        public void TestCompleteLessonPair()
        {
            _saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'completed': true 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestCompleteLessonPairMultipleUnique()
        {
            _saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            _saveData.CompleteLessonPair("Lesson Pack 2", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
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
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestCompleteLessonPairMultipleInPack()
        {
            _saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            _saveData.CompleteLessonPair("Lesson Pack 1", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'completed': true 
                    },
                    'Video 2': { 
                        'completed': true 
                    },
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestIsLessonPairCompleteFalse()
        {
            bool isComplete = _saveData.IsLessonPairComplete("test", "test");
            Assert.False(isComplete);
        }
        
        [Test]
        public void TestIsLessonPairCompleteTrue()
        {
            _saveData.CompleteLessonPair("Lesson Pack 1", "Video 1");
            bool isComplete = _saveData.IsLessonPairComplete("Lesson Pack 1", "Video 1");
            Assert.True(isComplete);
        }
        
        [Test]
        public void TestMakeCorrectCall()
        {
            _saveData.MakeCorrectCall("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'correct_calls': 1 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeTwoCorrectCalls()
        {
            _saveData.MakeCorrectCall("Lesson Pack 1", "Video 1");
            _saveData.MakeCorrectCall("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'correct_calls': 2 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeCorrectCallMultipleUnique()
        {
            _saveData.MakeCorrectCall("Lesson Pack 1", "Video 1");
            _saveData.MakeCorrectCall("Lesson Pack 2", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'correct_calls': 1
                    } 
                },
                'Lesson Pack 2': {
                    'Video 2': {
                        'correct_calls': 1
                    }
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeCorrectCallMultipleInPack()
        {
            _saveData.MakeCorrectCall("Lesson Pack 1", "Video 1");
            _saveData.MakeCorrectCall("Lesson Pack 1", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'correct_calls': 1
                    },
                    'Video 2': { 
                        'correct_calls': 1
                    },
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeIncorrectCall()
        {
            _saveData.MakeIncorrectCall("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'incorrect_calls': 1 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeTwoIncorrectCalls()
        {
            _saveData.MakeIncorrectCall("Lesson Pack 1", "Video 1");
            _saveData.MakeIncorrectCall("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'incorrect_calls': 2 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeIncorrectCallMultipleUnique()
        {
            _saveData.MakeIncorrectCall("Lesson Pack 1", "Video 1");
            _saveData.MakeIncorrectCall("Lesson Pack 2", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'incorrect_calls': 1
                    } 
                },
                'Lesson Pack 2': {
                    'Video 2': {
                        'incorrect_calls': 1
                    }
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestMakeIncorrectCallMultipleInPack()
        {
            _saveData.MakeIncorrectCall("Lesson Pack 1", "Video 1");
            _saveData.MakeIncorrectCall("Lesson Pack 1", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'incorrect_calls': 1
                    },
                    'Video 2': { 
                        'incorrect_calls': 1
                    },
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestAddAnalysisView()
        {
            _saveData.AddAnalysisView("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'analysis_views': 1 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestAddTwoAnalysisViews()
        {
            _saveData.AddAnalysisView("Lesson Pack 1", "Video 1");
            _saveData.AddAnalysisView("Lesson Pack 1", "Video 1");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'analysis_views': 2 
                    } 
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestAddAnalysisViewMultipleUnique()
        {
            _saveData.AddAnalysisView("Lesson Pack 1", "Video 1");
            _saveData.AddAnalysisView("Lesson Pack 2", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'analysis_views': 1
                    } 
                },
                'Lesson Pack 2': {
                    'Video 2': {
                        'analysis_views': 1
                    }
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestAddAnalysisViewMultipleInPack()
        {
            _saveData.AddAnalysisView("Lesson Pack 1", "Video 1");
            _saveData.AddAnalysisView("Lesson Pack 1", "Video 2");
            String saveFileText = File.ReadAllText(_customFilePath);
            String expectedText = @"{
                'Lesson Pack 1': {
                    'Video 1': { 
                        'analysis_views': 1
                    },
                    'Video 2': { 
                        'analysis_views': 1
                    },
                } 
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(saveFileText, expectedJObject.ToString());
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_customFilePath);
        }
    }
}
