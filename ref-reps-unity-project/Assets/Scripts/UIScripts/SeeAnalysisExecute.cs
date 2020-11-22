using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeAnalysisExecute : MonoBehaviour
{


    [Header("VideoManipulation")]
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public UnityEngine.Video.VideoClip analysisClip;

    CursorInteractionScript ciScript;
    public bool over;

    void Start(){
        ciScript  = GameObject.Find("HandCursor").GetComponent<CursorInteractionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(over == true && ciScript.press == true){
            buttonExecute();
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "HandCursor"){
            over = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name == "HandCursor"){
            over = false;
        }
    }

    public void buttonExecute(){
        videoPlayer.clip = analysisClip;
        videoPlayer.Play();
        this.gameObject.SetActive(false);
        GameObject.Find("CallsCanvas").SetActive(false);
    }
}
