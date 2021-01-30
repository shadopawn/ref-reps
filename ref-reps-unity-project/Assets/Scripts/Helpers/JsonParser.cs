using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class JsonParser
{

    public List<(String name, JToken lessonPairs)> GetLessonPacks(String json)
    {
        JObject lessonPacks = JObject.Parse(json);

        List<(String, JToken)> LessonPacks = new List<(String, JToken)>();
        foreach (KeyValuePair<string, JToken> lessonPack in lessonPacks)
        {
            String name = lessonPack.Value["name"]?.ToString();
            JToken lessonPairs = lessonPack.Value["lesson_pairs"];
            (String, JToken) nameAndPairs = (name, lessonPairs);
            LessonPacks.Add(nameAndPairs);
        }

        return LessonPacks;
    }
}
