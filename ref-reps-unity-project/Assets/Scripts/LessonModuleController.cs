using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonModuleController : MonoBehaviour
{
    public List<string> lessons;
    
    [SerializeField]
    private List<GameObject> lessonPairPrefabs;

    public int lessonNum = 1;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLessonPairPrefabs(List<GameObject> prefabs)
    {
        lessonPairPrefabs = prefabs;
    }
}
