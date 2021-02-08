using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLessonScript : MonoBehaviour
{
    public GameControllerScript GameController;
    LessonModuleController LessonModuleController;

    void Start(){
        LessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();
        GameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        
        if(LessonModuleController.lessonNum >= LessonModuleController.lessonPairDataList.Count - 1){
            this.gameObject.SetActive(false);
        }
    }


    public void buttonExecute(){
        // GameController.ForwardLesson();
        LessonModuleController.lessonNum++;
        SceneManager.LoadScene("MainScene");
    }
}
