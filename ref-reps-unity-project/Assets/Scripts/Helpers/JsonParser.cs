using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        for (int i = 0; i < lessonPairs.Count(); i++)
        {
            LessonPairData lessonPairData = ScriptableObject.CreateInstance<LessonPairData>();
            //TODO: properly populate LessonPairData info
            lessonPairDataList.Add(lessonPairData);
        }
        return lessonPairDataList;
    }
}
