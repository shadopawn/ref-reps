using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class VideoSelection : MonoBehaviour
{

    private Database _database = new Database();
    // Start is called before the first frame update
    async void Start()
    {
        var json = await _database.GetLessonPacksJson();
        
        JObject lessonPacks = JObject.Parse(json);
        JToken lessonPairs = lessonPacks["lesson_pack0"]?["lesson_pairs"];
        if (lessonPairs != null)
            foreach (JToken lessonPair in lessonPairs)
            {
                foreach (JToken videos in lessonPair.Children())
                {
                    Debug.Log(videos.Value<String>("call_video"));
                    Debug.Log(videos.Value<String>("analysis_video"));
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
