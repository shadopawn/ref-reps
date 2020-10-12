using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButtonScript : MonoBehaviour
{
    videoPlayerScript vpScript;

    // Start is called before the first frame update
    void Start()
    {
        vpScript = GameObject.Find("VideoPlayer/CurrentVideo").GetComponent<videoPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.gameObject.name);
        vpScript.ReplayClip();
    }

    private void OnTriggerExit2D(Collider2D other){

    }
}
