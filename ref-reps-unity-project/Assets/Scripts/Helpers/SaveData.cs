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
    
    public SaveData(String filePath = "")
    {
        String saveDirectory = Application.dataPath + "/SaveData";
        _saveFile = saveDirectory + "/userInfo.json";
        if (filePath != "")
        {
            saveDirectory = Path.GetDirectoryName(filePath);
            _saveFile = filePath;
        }

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

        if (_saveDataJObject[lessonPackName]?[lessonPairName] is JObject lessonPackJObject)
        {
            lessonPackJObject["completed"] = true;
        }

        if (_saveDataJObject[lessonPackName] == null)
        {
            _saveDataJObject[lessonPackName] = new JObject
            {
                {
                    lessonPairName,
                    new JObject
                    {
                        { "completed", true }
                    }
                }
            };
        }
        else
        {
            _saveDataJObject[lessonPackName][lessonPairName] = new JObject
            {
                {"completed", true}
            };
        }
        
        File.WriteAllText(_saveFile, _saveDataJObject.ToString());
    }
}