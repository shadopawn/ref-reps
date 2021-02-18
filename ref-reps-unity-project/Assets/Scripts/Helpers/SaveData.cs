using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveData
{
    private string saveFile = Application.dataPath + "/SaveData/userInfo.json";
    private string saveDivectory = Application.dataPath + "/SaveData";

    public SaveData()
    {
        FileInfo fileInfo = new FileInfo(saveDivectory);
        if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
    }
    
    public void CompleteLessonPair(string lessonPackName, string lessonPairName)
    {
        
    }
}