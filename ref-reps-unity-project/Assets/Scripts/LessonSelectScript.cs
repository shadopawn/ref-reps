using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LessonSelectScript : MonoBehaviour
{
    GameObject LessonBackground;
    public GameObject thisButton;
    GameObject PinWheel;
    public GameObject VideoParent;
    GameObject LessonTitle;
    public GameObject LessonParent;

    public GameObject PinWheelButton;
    
    public List<GameObject> lessonPairPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        LessonTitle = GameObject.Find("LessonTitle");
        PinWheel = GameObject.Find("PinWheel");
        LessonBackground = GameObject.Find("LessonBackground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void titleExecute(){
        LessonTitle.GetComponent<Text>().text = GetComponentInChildren<Text>().text;
        PinWheel.GetComponent<PinWheel>().DestroyChildren();
        for(int i = 0; i < lessonPairPrefabs.Count(); i++)
        {
            CreatPinWheelButton(i);
        }
        PinWheel.GetComponent<PinWheel>().FindChildren();
        LessonBackground.GetComponent<Animator>().SetBool("isSelected", true);
        thisButton.GetComponent<Animator>().SetBool("isSelected", true);
    }
    
    public void SetLessonPairPrefabs(List<GameObject> prefabs)
    {
        lessonPairPrefabs = prefabs;
    }

    private void CreatPinWheelButton(int index)
    {
        GameObject pinButton = Instantiate(PinWheelButton, transform.position, Quaternion.identity, PinWheel.transform);
        pinButton.GetComponent<WatchLessonScript>().LessonParent = LessonParent;
        Text buttonText = pinButton.GetComponentInChildren<Text>();
        buttonText.text = "Video " + index;
    }
}
