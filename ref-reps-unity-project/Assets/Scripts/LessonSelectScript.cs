﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LessonSelectScript : MonoBehaviour
{
    GameObject LessonBackground;
    public GameObject thisButton;
    PinWheel PinWheelCompoonenet;
    public GameObject VideoParent;
    GameObject LessonTitle;
    public GameObject LessonParent;

    public GameObject PinWheelButton;
    
    private List<LessonPairData> _lessonPairDataList;
    
    private LessonModuleController _lessonModuleController;


    // Start is called before the first frame update
    void Start()
    {
        LessonTitle = GameObject.Find("LessonTitle");
        PinWheelCompoonenet = GameObject.Find("PinWheel")?.GetComponent<PinWheel>();
        LessonBackground = GameObject.Find("LessonBackground");
        
        _lessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void titleExecute(){
        LessonTitle.GetComponent<Text>().text = GetComponentInChildren<Text>().text;
        
        PinWheelCompoonenet.DestroyChildren();
        for(int i = 0; i < _lessonPairDataList.Count(); i++)
        {
            CreatPinWheelButton(i);
        }
        
        LessonBackground.GetComponent<Animator>().SetBool("isSelected", true);
        thisButton.GetComponent<Animator>().SetBool("isSelected", true);
        
        _lessonModuleController.SetLessonPairDataList(_lessonPairDataList);
    }
    
    public void SetLessonPairDataList(List<LessonPairData> lessonPairData)
    {
        _lessonPairDataList = lessonPairData;
    }

    private GameObject CreatPinWheelButton(int index)
    {
        GameObject pinButton = Instantiate(PinWheelButton, transform.position, Quaternion.identity, PinWheelCompoonenet.transform);
        pinButton.GetComponent<WatchLessonScript>().LessonParent = LessonParent;
        Text buttonText = pinButton.GetComponentInChildren<Text>();
        buttonText.text = "Video " + index;
        return pinButton;
    }
}
