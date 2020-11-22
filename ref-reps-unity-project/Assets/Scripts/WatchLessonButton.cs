using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WatchLessonButton : MonoBehaviour
{
    public LessonModuleController LessonModuleController;
    public GameObject LessonParent;
    GameObject PinWheel;

    void Start(){
        LessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();
        PinWheel = GameObject.Find("PinWheel");
    }

    void Update(){
        if(PinWheel.transform.childCount > 0){
            LessonParent = PinWheel.GetComponent<PinWheel>().wheelObjects[PinWheel.GetComponent<PinWheel>().frontObject].GetComponent<WatchLessonScript>().LessonParent;
        }
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
