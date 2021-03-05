using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonParser
{
    public List<(String name, JToken lessonPairs)> GetLessonPacks(String json)
    {
        //instead of JToken possibly return scriptable object
        JObject lessonPacks = JObject.Parse(json);

        List<(String, JToken)> lessonPackList = new List<(String, JToken)>();
        foreach (KeyValuePair<string, JToken> lessonPack in lessonPacks)
        {
            String name = lessonPack.Value["name"]?.ToString();
            JToken lessonPairs = lessonPack.Value["lesson_pairs"];
            (String, JToken) nameAndPairs = (name, lessonPairs);
            lessonPackList.Add(nameAndPairs);
        }

        return lessonPackList;
    }
    
    public List<LessonPairData> CreateLessonPairs(JToken lessonPairs)
    {
        List<LessonPairData> lessonPairDataList = new List<LessonPairData>();

        foreach (JToken lessonPair in lessonPairs)
        {
            LessonPairData lessonPairData = ScriptableObject.CreateInstance<LessonPairData>();
            foreach (JToken lessonPairChild in lessonPair.Children())
            {
                lessonPairData.lessonPairName = lessonPairChild.Value<String>("name");
                
                String callVideoURL = lessonPairChild.Value<String>("call_url");
                String analysisVideoURL = lessonPairChild.Value<String>("analysis_url");

                lessonPairData.playVideoUrl = callVideoURL;
                lessonPairData.analysisVideoUrl = analysisVideoURL;

                JToken calls = lessonPairChild.Value<JToken>("calls");
                
                String falseCall0 = calls.Value<String>("false_call0");
                String falseCall1 = calls.Value<String>("false_call1");
                String trueCall = calls.Value<String>("true_call");
                
                lessonPairData.calls.Add(falseCall0);
                lessonPairData.calls.Add(falseCall1);
                lessonPairData.calls.Add(trueCall);

                lessonPairData.correctCall = trueCall;

            }
            lessonPairDataList.Add(lessonPairData);
        }
        
        return lessonPairDataList;
    }
}
