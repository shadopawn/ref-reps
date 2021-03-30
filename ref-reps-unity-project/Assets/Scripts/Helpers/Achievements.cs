using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Achievements
{
    
    private JObject _AchievementsJObject = new JObject();

    private String _achievementsFilePath;

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
            _AchievementsJObject = JObject.Parse(achievementsText);
        }
    }

    public void CompleteAchievement(String achievementName)
    {
        if (_AchievementsJObject[achievementName] is JObject achievementJObject)
        {
            achievementJObject["completed"] = true;
            File.WriteAllText(_achievementsFilePath, _AchievementsJObject.ToString());
        }
        else
        {
            Debug.LogError("Achievement not found");
        }
    }
    
    public List<(String name, String description, bool completed)> GetAchievements()
    {
        return new List<(string name, string description, bool completed)>();
    }
}
