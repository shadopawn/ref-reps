using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLessonScript : MonoBehaviour
{
    public GameControllerScript GameController;
    LessonModuleController LessonModuleController;

    void Start(){
        LessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();
        GameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();

        // if(LessonModuleController.lessonNum >= LessonModuleController.lessons.Count - 1){
        //     this.gameObject.SetActive(true);
        // }else{
        //     this.gameObject.SetActive(false);
        // }
    }


    public void buttonExecute(){
        // GameController.ForwardLesson();
        SceneManager.LoadScene("VideoSelectScreen");
    }
}
