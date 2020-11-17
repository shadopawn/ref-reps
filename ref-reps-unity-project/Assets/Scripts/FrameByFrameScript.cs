using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameByFrameScript : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer currentVideo;

    // Start is called before the first frame update
    void Start()
    {
        currentVideo = GameObject.Find("CurrentVideo").GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonExecute(){
        currentVideo.Stop();
        currentVideo.playbackSpeed = .1f;
        currentVideo.Play();
    }
}
