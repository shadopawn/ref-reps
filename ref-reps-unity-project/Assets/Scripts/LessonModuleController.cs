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

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
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

    public int GetLessonPairCount()
    {
        return lessonPairDataList.Count;
    }
}
