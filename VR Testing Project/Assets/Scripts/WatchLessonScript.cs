using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WatchLessonScript : MonoBehaviour
{
    public LessonModuleController LessonModuleController;
    public GameObject LessonParent;
    GameObject PinWheel;
    // public List<string> lessons;

    void Start(){
        LessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();
        PinWheel = GameObject.Find("PinWheel");
    }

    public void titleExecute(){
        foreach(Transform child in LessonParent.transform){
            LessonModuleController.lessons.Add(child.gameObject.name);
        }
        StoreLessons();
    }

    void StoreLessons(){
        StartLesson();
    }

    void StartLesson(){
        LessonModuleController.lessonNum = PinWheel.GetComponent<PinWheel>().frontObject;
        SceneManager.LoadScene("MainScene");
    }
}
