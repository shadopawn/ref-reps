using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchLessonText : MonoBehaviour
{
    GameObject PinWheel;
    // Start is called before the first frame update
    void Start()
    {
        PinWheel = GameObject.Find("PinWheel");
    }

    // Update is called once per frame
    void Update()
    {
        if(PinWheel.transform.childCount > 0){
            GetComponent<Text>().text = "Watch " + PinWheel.GetComponent<PinWheel>().wheelObjects[PinWheel.GetComponent<PinWheel>().frontObject].transform.Find("Text").GetComponent<Text>().text;
        }
    }
}
