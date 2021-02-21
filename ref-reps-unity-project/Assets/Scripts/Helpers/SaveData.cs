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
            //if pack and pair already exist set to complete
            lessonPackJObject["completed"] = true;
        }

        if (_saveDataJObject[lessonPackName] == null)
        {
            //if pack does not exist create new pack entry with completed lesson pair
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
            //if pack does exist overwrite or create new lesson pair and set to complete
            //this might remove other data stored under a lesson pair
            _saveDataJObject[lessonPackName][lessonPairName] = new JObject
            {
                {"completed", true}
            };
        }
        
        File.WriteAllText(_saveFile, _saveDataJObject.ToString());
    }

    public bool IsLessonPairComplete(string lessonPackName, string lessonPairName)
    {
        bool? isComplete = _saveDataJObject[lessonPackName]?[lessonPairName]?.Value<bool>("completed");

        return isComplete ?? false;
    }
}