﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            CreateNewButton(lessonPack.name, lessonPack.lessonPairs);
        }
    }

    private void CreateNewButton(String buttonText, JToken lessonPairs)
    {
        GameObject lessonPackButton = Instantiate(lessonPackButtonPrefab, transform);
        Text buttonTextComponent = lessonPackButton.GetComponentInChildren<Text>();
        buttonTextComponent.text = buttonText;
        
        List<LessonPairData> lessonPairObjects = _jsonParser.CreateLessonPairs(lessonPairs);
        lessonPackButton.GetComponent<LessonSelectScript>().SetLessonPairDataList(lessonPairObjects);
        
    }
    
}
