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
        
        [SetUp]
        public void Setup()
        {
            _achievements = new Achievements("TestAchievements");
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

        [TearDown]
        public void TearDown()
        {

        }
    }
}

