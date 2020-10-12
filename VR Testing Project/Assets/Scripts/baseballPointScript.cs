using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class baseballPointScript : MonoBehaviour
{
    public int points;
    public float pTime;
    public Transform progressBar;
    public string callName;
    public UIScriptManager UIScriptManager;
    public videoPlayerScript vpScript;
    Scene scene;
    int barTime = 125;
    public GameObject callUIObject;
    int children;
    bool callMade;

    public void Start(){
        Scene scene = SceneManager.GetActiveScene();
    }

    void Awake(){
        callUIObject = GameObject.Find("CallsCanvas/UIBAR/CallsPanel/" + callName + "Icon");
        vpScript = GameObject.Find("CurrentVideo").GetComponent<videoPlayerScript>();
        if(callUIObject.transform.Find("progressBar").transform != null){
            progressBar = callUIObject.transform.Find("progressBar").transform;
        }
    }

    public void DetermineActive(){
        this.gameObject.SetActive(callUIObject.activeSelf);
    }

    void Update(){
        if(transform.childCount == 2){
            if(transform.GetChild(0).GetComponent<PointEachScript>().pointsReached == true && transform.GetChild(1).GetComponent<PointEachScript>().pointsReached == true){
                callMade = true;
            }else{
                callMade = false;
            }
        }

        if(transform.childCount == 4){
            if(transform.GetChild(0).GetComponent<PointEachScript>().pointsReached == true && transform.GetChild(1).GetComponent<PointEachScript>().pointsReached == true 
            || transform.GetChild(2).GetComponent<PointEachScript>().pointsReached == true && transform.GetChild(3).GetComponent<PointEachScript>().pointsReached == true){
                callMade = true;
            }else{
                callMade = false;
            }
        }
    }

    private void FixedUpdate() {
        if(vpScript.isPaused == true){
            if(callMade){
                pTime++;
                if(pTime > barTime){
                    FinishCall();
                    points = 0;
                    pTime = 0;
                }
            }else{
                pTime = 0;
            }

            if(pTime < barTime){
                progressBar.localScale = new Vector3(1, pTime/barTime, 1);
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
