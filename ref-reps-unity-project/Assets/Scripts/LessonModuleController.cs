using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonModuleController : MonoBehaviour
{
    public List<string> lessons;
    
    public List<LessonPairData> lessonPairDataList;

    public int lessonNum = 1;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLessonPairDataList(List<LessonPairData> lessonPairData)
    {
        lessonPairDataList = lessonPairData;
    }
}
