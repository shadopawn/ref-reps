using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveData
{
    private String _saveFile;

    private JObject _saveDataJObject = new JObject();
    
    public SaveData()
    {
        String saveDirectory = Application.dataPath + "/SaveData";
        _saveFile = saveDirectory + "/userInfo.json";
        
        Directory.CreateDirectory(saveDirectory);
        if (!File.Exists(_saveFile))
        {
            File.Create(_saveFile).Dispose();
        }
        else
        {
            String saveFileText = File.ReadAllText(_saveFile);
            if (!String.IsNullOrEmpty(saveFileText))
            {
                _saveDataJObject = JObject.Parse(saveFileText);
            }
        }
    }
    
    public void CompleteLessonPair(string lessonPackName, string lessonPairName)
    {
        File.WriteAllText(_saveFile, _saveDataJObject.ToString());
    }
}