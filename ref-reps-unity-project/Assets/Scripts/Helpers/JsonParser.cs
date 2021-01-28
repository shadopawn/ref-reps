using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class JsonParser
{

    public List<String> GetLessonPackNames(String json)
    {
        JObject lessonPacks = JObject.Parse(json);

        List<String> lessonPackNames = new List<string>();
        foreach (KeyValuePair<string, JToken> lessonPack in lessonPacks)
        {
            lessonPackNames.Add(lessonPack.Value["name"]?.ToString());
            JToken lessonPairs = lessonPack.Value["lesson_pairs"];
        }

        return lessonPackNames;
    }
}
