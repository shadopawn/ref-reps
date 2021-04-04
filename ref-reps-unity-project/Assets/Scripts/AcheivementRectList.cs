using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcheivementRectList : MonoBehaviour
{
    public GameObject AcheivementRectPrefab;

    private Achievements _achievements = new Achievements();
    private JsonParser _jsonParser = new JsonParser();

    
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
        String CompletionText;
        GameObject AcheivementRect = Instantiate(AcheivementRectPrefab, transform);

        Text RectNameComponent = AcheivementRect.transform.GetChild(0).GetComponentInChildren<Text>();
        Text RectDescriptionComponent = AcheivementRect.transform.GetChild(1).GetComponentInChildren<Text>();
        Text RectCompletionComponent = AcheivementRect.transform.GetChild(2).GetComponentInChildren<Text>();

        RectNameComponent.text = name;
        RectDescriptionComponent.text = description;
        if(isCompleted)
        {
            CompletionText = "Completed";
        }
        else
        {
            CompletionText = "Not yet completed";
        }
        RectCompletionComponent.text = CompletionText;
       
    }
}
