using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallMake : MonoBehaviour
{   
    UIScriptManager UIScriptManager;
    videoPlayerScript vpScript;
    Scene scene;
    [HideInInspector]
    public bool pointsMet;
    GameObject optionObject;
    Transform progressBar;
    GameObject callUIObject;

    int goalTime = 125;
    float callTime;

    public string callName;
    public int optionNum;

    public void Start(){
        Scene scene = SceneManager.GetActiveScene();
        vpScript = GameObject.Find("CurrentVideo").GetComponent<videoPlayerScript>();
    }

    void Awake(){
        callUIObject = GameObject.Find("CallsCanvas/UIBAR/CallsPanel/" + callName + "Icon");
        this.gameObject.name = callName + "Node";
        progressBar = callUIObject.transform.Find("progressBar").transform;
        optionObject = this.transform.GetChild(0).gameObject;

        for(int i = 0; i < optionNum; i++){
            GameObject newOption = Instantiate(optionObject, this.transform.position, Quaternion.identity);
            newOption.transform.parent = this.transform;
            newOption.gameObject.name = "OptionObject" + (i + 1);
            newOption.SetActive(true);
            optionNum = i + 1;
        }
        Destroy(transform.GetChild(0).gameObject);
        // this.gameObject.SetActive(callUIObject.activeSelf);
    }


    private void FixedUpdate() {
        if(vpScript.isPaused == true){
            if(pointsMet){
                callTime++;
                if(callTime > goalTime){
                    FinishCall();
                    callTime = 0;
                }
            }else{
                callTime = 0;
            }

            if(callTime < goalTime){
                progressBar.localScale = new Vector3(1, callTime/goalTime, 1);
            }else{
                progressBar.localScale = new Vector3(1,1,1);
            }
        }
        
    }

    public void FinishCall(){
        vpScript.CheckCall(callName, callUIObject);
        Debug.Log(callName, callUIObject);
    }
}
