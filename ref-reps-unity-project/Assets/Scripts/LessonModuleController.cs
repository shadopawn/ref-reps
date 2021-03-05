using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        _saveData.CompleteLessonPair(lessonPackName, GetCurrentLessonPairName());
    }

    public void SaveMakeCorrectCall()
    {
        _saveData.MakeCorrectCall(lessonPackName, GetCurrentLessonPairName());
    }
    
    public void SaveMakeIncorrectCall()
    {
        _saveData.MakeIncorrectCall(lessonPackName, GetCurrentLessonPairName());
    }

    public void SaveAnalysisView()
    {
        _saveData.AddAnalysisView(lessonPackName, GetCurrentLessonPairName());
    }
}
