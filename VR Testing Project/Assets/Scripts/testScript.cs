using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public bool isPlaying;
    public UnityEngine.Video.VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        vp = GameObject.Find("VideoPlayer/3PointVideo").GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            if(isPlaying == true){
                isPlaying = false;
                vp.Pause();
            }else if(isPlaying == false){
                isPlaying = true;
                vp.Play();
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log("hello");
    //     if(other.gameObject.tag == "3PointNode"){
    //         Debug.Log("Hit");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        // if(other.gameObject.tag == "3PointNode"){
            // Debug.Log("Hit");
            if(isPlaying == true){
                Debug.Log("Pause");
                isPlaying = false;
                vp.Pause();
            }else if(isPlaying == false){
                Debug.Log("Play");
                isPlaying = true;
                vp.Play();
            }
        // }
    }
}
