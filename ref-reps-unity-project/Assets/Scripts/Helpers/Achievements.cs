using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Achievements
{
    
    private readonly JObject _achievementsJObject = new JObject();

    private readonly String _achievementsFilePath;

    public Achievements(String customFilePath = null)
    {
        String defaultFilePath = Application.streamingAssetsPath + "/Achievements.json";
        
        _achievementsFilePath = customFilePath ?? defaultFilePath;
        if (!File.Exists(_achievementsFilePath))
        {
            Debug.LogError("Achievements file not found");
        }
        else
        {
            String achievementsText = File.ReadAllText(_achievementsFilePath);
            _achievementsJObject = JObject.Parse(achievementsText);
        }
    }

    public void CompleteAchievement(String achievementName)
    {
        if (_achievementsJObject[achievementName] is JObject achievementJObject)
        {
            achievementJObject["completed"] = true;
            File.WriteAllText(_achievementsFilePath, _achievementsJObject.ToString());
        }
        else
        {
            Debug.LogError("Achievement not found");
        }
    }
    
    public List<(String name, String description, bool completed)> GetAchievements()
    {
        List<(string name, string description, bool completed)> achievementList  = new List<(string name, string description, bool completed)>();
        foreach (KeyValuePair<string, JToken> achievement in _achievementsJObject)
        {
            String name = achievement.Key;
            String description = achievement.Value["description"]?.ToString();
            bool completed = achievement.Value["completed"]?.ToObject<bool>() ?? false;
            (string name, string description, bool completed) achievementTuple = (name, description, completed);
            achievementList.Add(achievementTuple);
        }

        return achievementList;
    }
}
