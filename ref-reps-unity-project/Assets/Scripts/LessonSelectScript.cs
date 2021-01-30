using System.Collections;
using System.Collections.Generic;
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
        for(int i = 0; i < VideoParent.transform.childCount; i++){
            GameObject pinObject = Instantiate(VideoParent.transform.GetChild(i).gameObject, transform.position, Quaternion.identity);
            pinObject.transform.SetParent(PinWheel.transform);
            pinObject.SetActive(true);
            pinObject.GetComponent<WatchLessonScript>().LessonParent = LessonParent;
        }
        PinWheel.GetComponent<PinWheel>().FindChildren();
        LessonBackground.GetComponent<Animator>().SetBool("isSelected", true);
        thisButton.GetComponent<Animator>().SetBool("isSelected", true);
    }
}
