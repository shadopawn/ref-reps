using System;
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

    private void CreateNewButton(String lessonPackName, JToken lessonPairs)
    {
        GameObject lessonPackButton = Instantiate(lessonPackButtonPrefab, transform);
        Text buttonTextComponent = lessonPackButton.GetComponentInChildren<Text>();
        buttonTextComponent.text = lessonPackName;
        
        List<LessonPairData> lessonPairObjects = _jsonParser.CreateLessonPairs(lessonPairs);
        lessonPackButton.GetComponent<LessonSelectScript>().SetLessonPairDataList(lessonPairObjects);

        Transform CursorStart = lessonPackButton.transform.GetChild(4);
        Transform CursorNode = lessonPackButton.transform.GetChild(3);

        CursorNode.GetComponent<TitleButtonScript>().SlideBar = lessonPackButton.transform.GetChild(2).GetChild(0);
        Vector2 handPosition = new Vector2(lessonPackButton.transform.position.x-50-lessonPackButton.GetComponent<RectTransform>().rect.width/2,lessonPackButton.transform.position.y);
        CursorStart.position = handPosition;
        
    }
    
}
