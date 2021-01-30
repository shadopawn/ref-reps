using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
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
        List<(String name, JToken lessonPairs)> lessonPacks = _jsonParser.GetLessonPacks(json);

        foreach (var lessonPack in lessonPacks)
        {
            CreateNewButton(lessonPack.name);
        }
    }

    private void CreateNewButton(String buttonText)
    {
        GameObject newButton = Instantiate(lessonPackButtonPrefab, transform);
        Text buttonTextComponent = newButton.GetComponentInChildren<Text>();
        buttonTextComponent.text = buttonText;
    }

    public List<GameObject> CreateLessonPairs()
    {
        return null;
    }
}
