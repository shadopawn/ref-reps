using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptManager : MonoBehaviour
{
    public GameObject pauseText;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doPauseAction(){
        pauseText.gameObject.SetActive(true);
        isPlaying = false;
    }

    public void doPlayAction(){
        pauseText.gameObject.SetActive(false);
        isPlaying = true;
    }

}
