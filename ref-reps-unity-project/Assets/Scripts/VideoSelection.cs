using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Serializable]
public class LessonPacks
{
    public LessonPack[] lessonPacksList;
}

[Serializable]
public class LessonPack
{
    public int level;
    public float timeElapsed;
    public string playerName;
}

public class VideoSelection : MonoBehaviour
{

    private Database _database = new Database();
    // Start is called before the first frame update
    async void Start()
    {
        var result = await _database.GetLessonPacks();
        
        JObject lessonPacksJson = JObject.Parse(result);
        Debug.Log((String)lessonPacksJson["lesson_pack0"]?["index"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
