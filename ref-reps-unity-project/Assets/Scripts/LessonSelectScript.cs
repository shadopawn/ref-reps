using System;
using System.IO;
using System.Collections;
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

    private String _lessonPackName;
    private List<LessonPairData> _lessonPairDataList;
    
    private LessonModuleController _lessonModuleController;


    // Start is called before the first frame update
    void Start()
    {
        LessonTitle = GameObject.Find("LessonTitle");
        PinWheelCompoonenet = GameObject.Find("PinWheel")?.GetComponent<PinWheel>();
        LessonBackground = GameObject.Find("LessonBackground");
        
        _lessonModuleController = GameObject.Find("LessonModuleController").GetComponent<LessonModuleController>();

        _lessonPackName = GetComponentInChildren<Text>().text;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void titleExecute(){
        LessonTitle.GetComponent<Text>().text = _lessonPackName;
        
        PinWheelCompoonenet.DestroyChildren();
        for(int i = 0; i < _lessonPairDataList.Count(); i++)
        {
            CreatPinWheelButton(i);
        }
        
        LessonBackground.GetComponent<Animator>().SetBool("isSelected", true);
        thisButton.GetComponent<Animator>().SetBool("isSelected", true);
        
        _lessonModuleController.SetLessonPairDataList(_lessonPairDataList);
        _lessonModuleController.SetLessonPackName(_lessonPackName);
    }
    
    public void SetLessonPairDataList(List<LessonPairData> lessonPairData)
    {
        _lessonPairDataList = lessonPairData;
    }
    
    private GameObject CreatPinWheelButton(int index)
    {
        LessonPairData lessonPairData = _lessonPairDataList[index];
        
        GameObject pinButton = Instantiate(PinWheelButton, transform.position, Quaternion.identity, PinWheelCompoonenet.transform);
        Text buttonText = pinButton.GetComponentInChildren<Text>();
        if (string.IsNullOrEmpty(lessonPairData.lessonPairName))
        {
            lessonPairData.lessonPairName = "Video " + (index + 1);
        }
        buttonText.text = lessonPairData.lessonPairName;
        
        pinButton.GetComponent<WatchLessonScript>().LessonParent = LessonParent;


        String lessonPackName = LessonTitle.GetComponent<Text>().text;
        String description = getDescription(buttonText.text, lessonPackName );
        Text buttonDescriptionText = pinButton.transform.FindChild("DescriptionText").GetComponent<Text>();
        buttonDescriptionText.text = description;

        return pinButton;
    }


    private String getDescription(String buttonName, string lessonName)
    {
        SaveData data = new SaveData();

        if (data.IsLessonPairComplete(lessonName, buttonName))
        {
            return "Complete";
        }
        return "Incomplete";

       
    }
}
