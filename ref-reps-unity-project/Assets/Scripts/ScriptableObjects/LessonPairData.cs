using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonPairData : ScriptableObject
{
    public UnityEngine.Video.VideoClip playVideo;
    public string playVideoUrl;
    public UnityEngine.Video.VideoClip analysisVideo;
    public string analysisVideoUrl;
    public int calltime = Int32.MaxValue;
    public int analysisEndTime = Int32.MaxValue;
    public string sport;
    public List<String> calls = new List<string>();
    public string correctCall;
}
