using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonPackButtonList : MonoBehaviour
{

    public GameObject lessonPackButtonPrefab;
    
    private Database _database = new Database();
    private JsonParser _jsonParser = new JsonParser();

    async void Start()
    {
        String json = await _database.GetLessonPacksJson();
        List<String> lessonPackNames = _jsonParser.GetLessonPackNames(json);

        foreach (var lessonPackName in lessonPackNames)
        {
            print(lessonPackName);
            CreateNewButton(lessonPackName);
        }
    }

    private void CreateNewButton(String buttonText)
    {
        GameObject newButton = Instantiate(lessonPackButtonPrefab, transform);
        Text buttonTextComponent = newButton.GetComponentInChildren<Text>();
        buttonTextComponent.text = buttonText;
    }
}
