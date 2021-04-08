using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcheivementRectList : MonoBehaviour
{
    public GameObject AcheivementRectPrefab;
    private Achievements _achievements = new Achievements();
    
    // Start is called before the first frame update
    void Start()
    {
        List<(String name, String description, bool isCompleted)> achievements = _achievements.GetAchievements();
        foreach (var achievement in achievements)
        {
            CreateNewRect(achievement.name, achievement.description, achievement.isCompleted);
        } 
    }

    private void CreateNewRect(String name, String description, bool isCompleted)
    {
        String CompletionText = "Completed";

        if(isCompleted == false){
            CompletionText = "Incomplete";
        }

        GameObject AcheivementRect = Instantiate(AcheivementRectPrefab, transform);

        Text RectNameComponent = AcheivementRect.transform.Find("AchievementName").GetComponent<Text>();
        Text RectDescriptionComponent = AcheivementRect.transform.Find("AchievementDescription").GetComponent<Text>();
        Text RectCompletionComponent = AcheivementRect.transform.Find("AchievementCompletion").GetComponent<Text>();

        RectNameComponent.text = name;
        RectDescriptionComponent.text = description;
        RectCompletionComponent.text = CompletionText;
    }
}
