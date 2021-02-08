using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class LessonPairDataTests
    {

        private LessonPairData _lessonPairData;

        [SetUp]
        public void Setup()
        {
            _lessonPairData = ScriptableObject.CreateInstance<LessonPairData>();
        }

        [Test]
        public void TestLessonPairDataCreation()
        {
            Assert.NotNull(_lessonPairData);
        }
        
        [Test]
        public void TestLessonPairDataPlayVideoUrl()
        {
            _lessonPairData.playVideoUrl = "test";
            Assert.AreEqual(_lessonPairData.playVideoUrl, "test");
        }
        
        [Test]
        public void TestLessonPairDataAnalysisVideoUrl()
        {
            _lessonPairData.analysisVideoUrl = "test";
            Assert.AreEqual(_lessonPairData.analysisVideoUrl, "test");
        }
        
        [Test]
        public void TestLessonPairDataSport()
        {
            _lessonPairData.sport = "test";
            Assert.AreEqual(_lessonPairData.sport, "test");
        }
        
        [Test]
        public void TestLessonPairDataCalls()
        {
            Assert.NotNull(_lessonPairData.calls);
        }
        
        [Test]
        public void TestLessonPairDataCalls1()
        {
            _lessonPairData.calls.Add("test");
            Assert.AreEqual(_lessonPairData.calls[0], "test");
        }
        
        [Test]
        public void TestLessonPairDataCorrectCall()
        {
            _lessonPairData.correctCall = "test";
            Assert.AreEqual(_lessonPairData.correctCall, "test");
        }
    }
}

