using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonConstructorScript : MonoBehaviour
{
    public UnityEngine.Video.VideoClip playVideo;
    // public string url;
    public UnityEngine.Video.VideoClip analysisVideo;
    public int calltime;
    public int analysisEndTime;
    public string sport;
    public string[] calls;
    public string correctCall;

    public void SaveLesson(){
        SaveScript.SaveLesson(this);
    }
}
