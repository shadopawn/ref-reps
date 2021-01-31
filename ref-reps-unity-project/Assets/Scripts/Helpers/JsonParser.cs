using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JsonParser
{
    private Database _database = new Database();
    
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
    
    public async Task<List<LessonPairData>> CreateLessonPairs(JToken lessonPairs)
    {
        List<LessonPairData> lessonPairDataList = new List<LessonPairData>();

        foreach (JToken lessonPair in lessonPairs)
        {
            LessonPairData lessonPairData = ScriptableObject.CreateInstance<LessonPairData>();
            foreach (JToken lessonPairChild in lessonPair.Children())
            {
                String callVideoFileName = lessonPairChild.Value<String>("call_video");
                String analysisVideoFileName = lessonPairChild.Value<String>("analysis_video");
                String callVideoURL = await _database.GetVideoURL(callVideoFileName);
                String analysisVideoURL = await _database.GetVideoURL(analysisVideoFileName);

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
