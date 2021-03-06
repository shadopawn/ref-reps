﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class videoPlayerScript : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer vPlayer;
    UnityEngine.Video.VideoClip playClip;
    LessonConstructorScript LessonObject;
    public Image MakeTheCallUI;
    public GameObject SeeAnalysis;
    public bool isPaused;
    public bool callMade;
    Animator MakeTheCallAnim;
    Animator SeeAnalysisAnim;
    Animator NextLessonAnim;
    Animator EndLessonAnim;
    public GameObject TransitionPanel;
    public GameObject ModuleCompletePanel;
    public LessonModuleController LessonModuleController;

    private LessonPairData lessonPairData;

    // Start is called before the first frame update
    void Start()
    {
        LessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();
        lessonPairData = LessonModuleController.GetCurrentLessonPair();
        LessonObject = GameObject.FindWithTag("Lesson").GetComponent<LessonConstructorScript>();
        vPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        //playClip = LessonObject.playVideo;
        vPlayer.url = lessonPairData.playVideoUrl;
        //vPlayer.clip = playClip;
        vPlayer.Play();
        MakeTheCallAnim = MakeTheCallUI.GetComponent<Animator>();
        isPaused = false;
        SeeAnalysisAnim = SeeAnalysis.GetComponent<Animator>();
        NextLessonAnim = GameObject.Find("NextLessonButton").GetComponent<Animator>();
        EndLessonAnim = GameObject.Find("EndLessonButton").GetComponent<Animator>();
        TransitionPanel = GameObject.Find("TransitionScreenPanel");
        TransitionPanel.SetActive(false);
        
        vPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer videoPlayer)
    {
        if(vPlayer.url == lessonPairData.playVideoUrl){
            vPlayer.Pause();
            MakeTheCall();
            isPaused = true;
            callMade = true;
        }
        
        if(vPlayer.url == lessonPairData.analysisVideoUrl){
            Debug.Log("Analysis Video Done");
            
            LessonModuleController.SaveAnalysisView();
            
            vPlayer.Pause();
            if(LessonModuleController.lessonNum < LessonModuleController.GetLessonPairCount() - 1){
                TransitionPanel.SetActive(true);
                TransitionPanel.transform.parent.gameObject.SetActive(true);
            }
            if(LessonModuleController.lessonNum >= LessonModuleController.GetLessonPairCount() - 1)
            {
                LessonPackCompleted();
            }
        }
        
    }

    public void LessonPackCompleted()
    {
        TransitionPanel.transform.parent.gameObject.SetActive(true);
        ModuleCompletePanel.SetActive(true);
        
        AnalyticsEvent.Custom("Lesson Pack Completed", new Dictionary<string, object>
        {
            { "Lesson Pack Name", LessonModuleController.GetLessonPackName() }
        });
    }

    public void ReplayClip(){
        vPlayer.Stop();
        vPlayer.Play();
        callMade = false;
        isPaused = false;
    }

    void MakeTheCall(){
        MakeTheCallAnim.SetBool("isActive", true);
    }

    public void CheckCall(string callName, GameObject callUIObject){
        if(callMade == true){
            SeeAnalysisAnim.SetBool("isActive", true);
            NextLessonAnim.SetBool("isActive",true);
            EndLessonAnim.SetBool("isActive", true);
            if(callName == lessonPairData.correctCall){
                callUIObject.transform.Find("Correct").gameObject.SetActive(true);
                
                LessonModuleController.SaveMakeCorrectCall();
            }else{
                callUIObject.transform.Find("Incorrect").gameObject.SetActive(true);
                
                LessonModuleController.SaveMakeIncorrectCall();
            }
            callMade = false;
            
            LessonModuleController.SaveCompleteCurrentLessonPair();
        }
    }
}
