using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    LessonModuleController LessonModuleController;
    LessonConstructorScript LessonObject;
    GameObject callIcon;
    GameObject callsPanel;

    GameObject NextLessonTab;
    GameObject NextLessonButton;
    
    void Awake(){
        LessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();
        Instantiate(Resources.Load("Lessons/" + LessonModuleController.lessons[LessonModuleController.lessonNum]));

        NextLessonButton = GameObject.Find("TransitionScreenPanel/NextLessonButton");
        NextLessonTab = GameObject.Find("CallsCanvas/NexLessonButton");
    }

    // Start is called before the first frame update
    void Start()
    {
        LessonObject = GameObject.FindWithTag("Lesson").GetComponent<LessonConstructorScript>();
        Application.targetFrameRate = 300;
        callsPanel = GameObject.Find("CallsPanel");
        AddCallOptions();

        if(LessonModuleController.lessonNum >= LessonObject.calls.Length){
            NextLessonTab.SetActive(false);
            NextLessonButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            Application.Quit();
        }
    }

    public void ForwardLesson(){
        LessonModuleController.lessonNum++;
    }

    void AddCallOptions(){
        foreach(Transform child in callsPanel.transform){
            if(child.name == LessonObject.calls[0] + "Icon" || child.name == LessonObject.calls[1] + "Icon" || child.name == LessonObject.calls[2] + "Icon"){
                if(child.CompareTag(LessonObject.sport)){
                    child.gameObject.SetActive(true);
                }
            }
        }

        GameObject[] callNodes = GameObject.FindGameObjectsWithTag("callNode");
        foreach(GameObject callNode in callNodes){
            baseballPointScript pScript = callNode.GetComponent<baseballPointScript>();
            pScript.DetermineActive();
        }
    }
}
