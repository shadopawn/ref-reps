using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class handScript : MonoBehaviour
{
    public bool isPlaying;
    public UnityEngine.Video.VideoPlayer vp;
    public GameObject UIScriptManager;

    // Start is called before the first frame update
    void Awake()
    {
        isPlaying = true;
        vp = GameObject.Find("VideoPlayer/CurrentVideo").GetComponent<UnityEngine.Video.VideoPlayer>();
        UIScriptManager = GameObject.Find("UIScriptManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Head"){
            Debug.Log("Hit");
            if(isPlaying == true){
                isPlaying = false;
                vp.Pause();
                UIScriptManager.SendMessage("doPauseAction");
            }
            else if(isPlaying == false){
                isPlaying = true;
                vp.Play();
                UIScriptManager.SendMessage("doPlayAction");
            }
        }
        if(other.gameObject.name == "StartTrainingButton"){
            SceneManager.LoadScene("MainScene");
        }
        if(other.gameObject.name == "QuitButton"){
            Application.Quit();
        }
    }
}
