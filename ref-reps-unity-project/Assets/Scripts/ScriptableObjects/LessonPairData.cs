using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonPairData : ScriptableObject
{
    public string playVideoUrl;
    public string analysisVideoUrl;
    public string sport;
    public List<String> calls = new List<string>();
    public string correctCall;
}
