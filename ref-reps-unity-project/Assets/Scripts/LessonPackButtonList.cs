using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        //set lessonPairPrefabs on LessonSelectScript attached to LessonPackButton 
        List<GameObject> lessonPairObjects = CreateLessonPairs(lessonPairs);
        lessonPackButton.GetComponent<LessonSelectScript>().SetLessonPairPrefabs(lessonPairObjects);
        
    }

    public List<GameObject> CreateLessonPairs(JToken lessonPairs)
    {
        List<GameObject> lessonPairObjects = new List<GameObject>();
        for (int i = 0; i < lessonPairs.Count(); i++)
        {
            //This game object just gets placed at the root of the tree
            GameObject lessonPairObject = new GameObject();
            LessonConstructorScript constructorScript = lessonPairObject.AddComponent<LessonConstructorScript>();
            //TODO: properly populate constructorScript info
            lessonPairObjects.Add(lessonPairObject);
        }
        return lessonPairObjects;
    }
}
