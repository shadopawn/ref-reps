using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LessonModuleController : MonoBehaviour
{
    public List<string> lessons;

    public String lessonPackName;
    public List<LessonPairData> lessonPairDataList;

    public int lessonNum = 1;
    
    private SaveData _saveData;

    private Achievements _achievements;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        _saveData = new SaveData();

        _achievements = new Achievements();
    }

    public void SetLessonPackName(String packName)
    {
        lessonPackName = packName;
    }

    public String GetLessonPackName()
    {
        return lessonPackName;
    }

    public void SetLessonPairDataList(List<LessonPairData> lessonPairData)
    {
        lessonPairDataList = lessonPairData;
    }

    public LessonPairData GetCurrentLessonPair()
    {
        return lessonPairDataList[lessonNum];
    }
    
    public String GetCurrentLessonPairName()
    {
        return lessonPairDataList[lessonNum].lessonPairName;
    }

    public int GetLessonPairCount()
    {
        return lessonPairDataList.Count;
    }

    public void SaveCompleteCurrentLessonPair()
    {
        if (_saveData.IsLessonPairComplete(lessonPackName, GetCurrentLessonPairName()) == false)
        {
            AnalyticsResult result = CustomAnalyticEvent("Complete Lesson Pair");
            Debug.Log("Complete Lesson Pair AnalyticsResult: " + result);
        }
        
        _achievements.CompleteAchievement("Finish One Lesson");
        
        _saveData.CompleteLessonPair(lessonPackName, GetCurrentLessonPairName());
    }

    public void SaveMakeCorrectCall()
    {
        _saveData.MakeCorrectCall(lessonPackName, GetCurrentLessonPairName());
        AnalyticsResult result = CustomAnalyticEvent("Make Correct Call");
        Debug.Log("Make Correct Call AnalyticsResult: " + result);
    }
    
    public void SaveMakeIncorrectCall()
    {
        _saveData.MakeIncorrectCall(lessonPackName, GetCurrentLessonPairName());
        AnalyticsResult result = CustomAnalyticEvent("Make Incorrect Call");
        Debug.Log("Make Incorrect Call AnalyticsResult: " + result);
    }

    public void SaveAnalysisView()
    {
        _saveData.AddAnalysisView(lessonPackName, GetCurrentLessonPairName());
        AnalyticsResult result = CustomAnalyticEvent("Analysis Video Viewed");
        Debug.Log("Analysis Video Viewed AnalyticsResult: " + result);
    }

    private AnalyticsResult CustomAnalyticEvent(String eventName)
    {
        return AnalyticsEvent.Custom(eventName, new Dictionary<string, object>
        {
            { "Lesson Pack Name", lessonPackName },
            { "Lesson Pair Name", GetCurrentLessonPairName() }
        });
    }
}
