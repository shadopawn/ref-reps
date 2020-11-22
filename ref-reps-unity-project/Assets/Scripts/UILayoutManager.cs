using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILayoutManager : MonoBehaviour
{
    public GameObject SeeAnalysisButton;
    public GameObject NextLessonButton;
    public GameObject ExitLessonButton;
    public GameObject UIBAR;
    public GameObject YMTCIcon;
    public GameObject VideoControllerUI;

    public int[] states = {0, 1};
    public int currentState;

    void Start()
    {
        currentState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the Layout of each UI element based on the CurrentState
        if(currentState == 0){
            //UIBAR
            UIBAR.GetComponent<RectTransform>().anchoredPosition = new Vector2(-700, 70);

            //YouMakeTheCallIcon
            YMTCIcon.GetComponent<Animator>().SetInteger("state", 0);

            //Sliding Tabs -- SeeAnalysis & NextLesson
            SeeAnalysisButton.GetComponent<Animator>().SetInteger("state", 0);
            NextLessonButton.GetComponent<Animator>().SetInteger("state", 0);
            ExitLessonButton.GetComponent<Animator>().SetInteger("state", 0);
        }
        else if(currentState == 1){
            //UIBAR
            UIBAR.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1230, 870);

            //YouMakeTheCallIcon
            YMTCIcon.GetComponent<Animator>().SetInteger("state", 1);

            //Sliding Tabs -- SeeAnalysis & NextLesson
            SeeAnalysisButton.GetComponent<Animator>().SetInteger("state", 1);
            NextLessonButton.GetComponent<Animator>().SetInteger("state", 1);
            ExitLessonButton.GetComponent<Animator>().SetInteger("state", 0);


        }
    }
}
