using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public int points;
    public float pTime;
    public Transform progressBar;
    public string callName;
    public UIScriptManager UIScriptManager;
    public videoPlayerScript vpScript;

    public void AddPoint(){
        points++;
    }

    public void RemovePoint(){
        points--;
    }

    private void Update() {
        if(UIScriptManager.isPlaying == false){
            if(points >= 4){
                pTime++;
                if(pTime > 150f){
                    Debug.Log(callName);
                    FinishCall();
                    points = 0;
                    pTime = 0;
                }
            }else{
                pTime = 0;
            }

            if(pTime < 150f){
                progressBar.localScale = new Vector3(1, pTime/150f, 1);
            }else{
                progressBar.localScale = new Vector3(1,1,1);
            }
        }
    }


    public void FinishCall(){
        // UIScriptManager.pauseText.text = callName;
        // UIScriptManager.pauseText.text.SetActive(true);
    }
}
