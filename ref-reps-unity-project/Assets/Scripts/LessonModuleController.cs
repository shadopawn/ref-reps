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

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        _saveData = new SaveData();
    }

    public void SetLessonPackName(String packName)
    {
        lessonPackName = packName;
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
            AnalyticsResult result = CustomAnalyticEvent("CompleteLessonPair");
            Debug.Log("SaveCompleteCurrentLessonPair AnalyticsResult: " + result);
        }
        
        _saveData.CompleteLessonPair(lessonPackName, GetCurrentLessonPairName());
    }

    public void SaveMakeCorrectCall()
    {
        _saveData.MakeCorrectCall(lessonPackName, GetCurrentLessonPairName());
        AnalyticsResult result = CustomAnalyticEvent("MakeCorrectCall");
        Debug.Log("SaveMakeCorrectCall AnalyticsResult: " + result);
    }
    
    public void SaveMakeIncorrectCall()
    {
        _saveData.MakeIncorrectCall(lessonPackName, GetCurrentLessonPairName());
        AnalyticsResult result = CustomAnalyticEvent("MakeIncorrectCall");
        Debug.Log("SaveMakeIncorrectCall AnalyticsResult: " + result);
    }

    public void SaveAnalysisView()
    {
        _saveData.AddAnalysisView(lessonPackName, GetCurrentLessonPairName());
        AnalyticsResult result = CustomAnalyticEvent("AnalysisVideoViewed");
        Debug.Log("SaveAnalysisView AnalyticsResult: " + result);
    }

    private AnalyticsResult CustomAnalyticEvent(String eventName)
    {
        return AnalyticsEvent.Custom(eventName, new Dictionary<string, object>
        {
            { "lessonPackName", lessonPackName },
            { "lessonPairName", GetCurrentLessonPairName() }
        });
    }
}
