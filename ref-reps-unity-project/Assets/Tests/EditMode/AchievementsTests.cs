using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Newtonsoft.Json.Linq;
using UnityEngine.SocialPlatforms.Impl;

namespace Tests
{
    public class AchievementsTests 
    {
        private Achievements _achievements;
        
        private String _achievementsFilePath;

        private String _achievementsText;
        
        [SetUp]
        public void Setup()
        {
            _achievementsFilePath = Application.streamingAssetsPath + "/TestAchievements.json";
            _achievements = new Achievements(_achievementsFilePath);
            _achievementsText = File.ReadAllText(_achievementsFilePath);
        }
        
        [Test]
        public void TestCreateAchievementObject()
        {
            Assert.NotNull(_achievements);
        }
        
        [Test]
        public void TestNonExistentAchievementFile()
        {
            _achievements = new Achievements("NonExistentAchievementFile");
            LogAssert.Expect(LogType.Error, "Achievements file not found");
        }
        
        [Test]
        public void TestNonExistentAchievement()
        {
            _achievements.CompleteAchievement("NonExistentAchievement");
            LogAssert.Expect(LogType.Error, "Achievement not found");
        }
        
        [Test]
        public void TestCompleteAchievement()
        {
            _achievements.CompleteAchievement("Achievement Name");
            String achievementsFileText = File.ReadAllText(_achievementsFilePath);
            String expectedText = @"{
                'Achievement Name': {
                    'description': 'Short description about the achievement',
                    'completed': true
                },
                'Achievement Name 1': {
                    'description': 'Another description about the achievement',
                    'completed': false
                }
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(achievementsFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestCompleteAchievement1()
        {
            _achievements.CompleteAchievement("Achievement Name 1");
            String achievementsFileText = File.ReadAllText(_achievementsFilePath);
            String expectedText = @"{
                'Achievement Name': {
                    'description': 'Short description about the achievement',
                    'completed': false
                },
                'Achievement Name 1': {
                    'description': 'Another description about the achievement',
                    'completed': true
                }
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(achievementsFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestCompleteAchievementMultiple()
        {
            _achievements.CompleteAchievement("Achievement Name");
            _achievements.CompleteAchievement("Achievement Name 1");
            String achievementsFileText = File.ReadAllText(_achievementsFilePath);
            String expectedText = @"{
                'Achievement Name': {
                    'description': 'Short description about the achievement',
                    'completed': true
                },
                'Achievement Name 1': {
                    'description': 'Another description about the achievement',
                    'completed': true
                }
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(achievementsFileText, expectedJObject.ToString());
        }
        
        [Test]
        public void TestCompleteAchievementDuplicate()
        {
            _achievements.CompleteAchievement("Achievement Name");
            _achievements.CompleteAchievement("Achievement Name");
            String achievementsFileText = File.ReadAllText(_achievementsFilePath);
            String expectedText = @"{
                'Achievement Name': {
                    'description': 'Short description about the achievement',
                    'completed': true
                },
                'Achievement Name 1': {
                    'description': 'Another description about the achievement',
                    'completed': false
                }
            }";
            JObject expectedJObject = JObject.Parse(expectedText);
            Assert.AreEqual(achievementsFileText, expectedJObject.ToString());
        }

        [TearDown]
        public void TearDown()
        {
            File.WriteAllText(_achievementsFilePath, _achievementsText);
        }
    }
}

