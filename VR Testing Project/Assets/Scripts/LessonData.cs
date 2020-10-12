using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LessonData
{
    public int callTime;
    public string sport;
    public string[] calls;
    public string correctCall;

    public LessonData (LessonConstructorScript lesson){
        callTime = lesson.calltime;
        sport = lesson.sport;
        calls = lesson.calls;
        correctCall = lesson.correctCall;
    }
}
