using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Achievements
{
    
    private JObject _AchievementsJObject = new JObject();

    public Achievements(String achievementsFileName = null)
    {
        achievementsFileName = achievementsFileName ?? "Achievements";
        TextAsset achievementsTextAsset = Resources.Load<TextAsset>(achievementsFileName);
        if (achievementsTextAsset == null)
        {
            Debug.LogError("Achievements file not found");
        }
        else
        {
            _AchievementsJObject = JObject.Parse(achievementsTextAsset.text);
        }
    }

    public void CompleteAchievement(String achievementName)
    {
        
    }
    
    public List<(String name, String description, bool completed)> GetAchievements()
    {
        return new List<(string name, string description, bool completed)>();
    }
}
