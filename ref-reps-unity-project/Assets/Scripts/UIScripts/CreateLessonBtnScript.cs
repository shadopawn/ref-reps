using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLessonBtnScript : MonoBehaviour
{
    bool panelActive = false;
    public GameObject CreateLessonPanel;

    // Start is called before the first frame update
    void Start()
    {
        // CreateLessonPanel = GameObject.Find("CreateLessonPanel");
    }

    // Update is called once per frame
    void Update()
    {
        CreateLessonPanel.SetActive(panelActive);
    }

    public void OnButtonPress(){
        panelActive = !panelActive;
    }
}
