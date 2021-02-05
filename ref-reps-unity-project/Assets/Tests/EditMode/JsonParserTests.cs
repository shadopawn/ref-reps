using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Newtonsoft.Json.Linq;

namespace Tests
{
    public class JsonParserTests
    {
        private JsonParser _jsonParser;

        [SetUp]
        public void Setup()
        {
            _jsonParser = new JsonParser();
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonReturn()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : '','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            Assert.NotNull(lessonPacksList);
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonType()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : '','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            List<(String, JToken)> expectedOutput = new List<(String, JToken)>();
            Assert.IsInstanceOf(lessonPacksList.GetType(), expectedOutput);
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonCorrectName()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : '','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var nameOfPack = lessonPacksList[0].name;
            Assert.AreEqual(nameOfPack, "lesson_pack_1");
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonCallVideo()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : '','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            String callVideoName = "";
            foreach (JToken lessonPairChild in lessonPacksList[0].lessonPairs.Children().Children())
            {
                callVideoName = lessonPairChild.Value<String>("call_video");
            }
            Assert.AreEqual(callVideoName, "Force Play Slide Rule_Umpire Glasses_Trim.mp4");
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonAnalysisVideo()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : '','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            String analysisVideoName = "";
            foreach (JToken lessonPairChild in lessonPacksList[0].lessonPairs.Children().Children())
            {
                analysisVideoName = lessonPairChild.Value<String>("analysis_video");
            }
            Assert.AreEqual(analysisVideoName, "ForcePlaySlideAnalysis.mp4");
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonAnalysisUrl()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            String analysisVideoURL = "";
            foreach (JToken lessonPairChild in lessonPacksList[0].lessonPairs.Children().Children())
            {
                analysisVideoURL = lessonPairChild.Value<String>("analysis_url");
            }
            Assert.AreEqual(analysisVideoURL, "test.com");
        }

        [Test]
        public void TestJsonParserGetLessonPacksJsonCallUrl()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            String callVideoURL = "";
            foreach (JToken lessonPairChild in lessonPacksList[0].lessonPairs.Children().Children())
            {
                callVideoURL = lessonPairChild.Value<String>("call_url");
            }
            Assert.AreEqual(callVideoURL, "test.net");
        }

        [Test]
        public void TestJsonParserCreateLessonPairsReturns()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            Assert.NotNull(lessonPairList);
        }

        [Test]
        public void TestJsonParserCreateLessonPairsType()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : '','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : '','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            List<LessonPairData> expectedOutput = new List<LessonPairData>();
            Assert.IsInstanceOf(lessonPairList.GetType(), expectedOutput);
        }

        [Test]
        public void TestJsonParserCreateLessonPairsPlayVideoUrl()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var playVideoUrl = lessonPairList[0].playVideoUrl;
            Assert.AreEqual(playVideoUrl, "test.net");
        }

        [Test]
        public void TestJsonParserCreateLessonPairsAnalysisVideoUrl()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var analysisVideoUrl = lessonPairList[0].analysisVideoUrl;
            Assert.AreEqual(analysisVideoUrl, "test.com");
        }

        [Test]
        public void TestJsonParserCreateLessonPairsSport()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var sport = lessonPairList[0].sport;
            Assert.AreEqual(sport, null);
        }

        [Test]
        public void TestJsonParserCreateLessonCorrectCall()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var correctCall = lessonPairList[0].correctCall;
            Assert.AreEqual(correctCall, "TechnicalFoul1.png");
        }

        [Test]
        public void TestJsonParserCreateLessonCall0()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var calls0 = lessonPairList[0].calls[0];
            Assert.AreEqual(calls0, "DoubleFoul.png");
        }

        [Test]
        public void TestJsonParserCreateLessonCall1()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var calls1 = lessonPairList[0].calls[1];
            Assert.AreEqual(calls1, "Push.png");
        }

        [Test]
        public void TestJsonParserCreateLessonCall2()
        {
            var testJson = "{'lesson_pack0' : {'index' : 0,'lesson_pairs' : {'lesson_pair0' : {'analysis_url' : 'test.com','analysis_video' : 'ForcePlaySlideAnalysis.mp4','call_url' : 'test.net','call_video' : 'Force Play Slide Rule_Umpire Glasses_Trim.mp4','calls' : {'false_call0' : 'DoubleFoul.png','false_call1' : 'Push.png','true_call' : 'TechnicalFoul1.png'}}}, 'name':'lesson_pack_1'}}";
            var lessonPacksList = _jsonParser.GetLessonPacks(testJson);
            var lessonPairList = _jsonParser.CreateLessonPairs(lessonPacksList[0].lessonPairs);
            var calls2 = lessonPairList[0].calls[2];
            Assert.AreEqual(calls2, "TechnicalFoul1.png");
        }
    }
}
