using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonPairData : ScriptableObject
{
    public String lessonPairName;
    public String playVideoUrl;
    public String analysisVideoUrl;
    public String sport;
    public List<String> calls = new List<string>();
    public String correctCall;
}
