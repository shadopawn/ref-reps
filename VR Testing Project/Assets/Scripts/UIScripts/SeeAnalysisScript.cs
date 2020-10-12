using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SeeAnalysisScript : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public UnityEngine.Video.VideoClip analysisClip;
    public LessonConstructorScript LessonObject;
    public GameObject cursorProgress;


    bool isEnter;
    float enterNum;

    // Start is called before the first frame update
    void Start()
    {
        LessonObject = GameObject.FindWithTag("Lesson").GetComponent<LessonConstructorScript>();
        videoPlayer = GameObject.Find("VideoPlayer/CurrentVideo").GetComponent<UnityEngine.Video.VideoPlayer>();
        analysisClip = LessonObject.analysisVideo;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isEnter == true){
            enterNum++;
        }else{
            enterNum = 0;
        }

        if(enterNum > 120){
            SeeAnalysis();
        }
        
        if(enterNum > 0){
            cursorProgress.transform.localScale = new Vector2(120/enterNum, 120/enterNum);
        }
        else{
            cursorProgress.transform.localScale = new Vector2(0,0);
        }
    }

    public void SeeAnalysis(){
        videoPlayer.clip = analysisClip;
        videoPlayer.Play();
        this.gameObject.SetActive(false);
        GameObject.Find("CallsCanvas").SetActive(false);
        isEnter = false;
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "cursor"){
            isEnter = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "cursor"){
            isEnter = false;
        }
    }
}
