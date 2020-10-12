using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubNodeUIScript : MonoBehaviour
{
    private GameObject virtualCursor;
    private CornerUIHubScript cornerScript;

    // Start is called before the first frame update
    void Start()
    {
        cornerScript = this.gameObject.transform.parent.gameObject.GetComponent<CornerUIHubScript>();
        virtualCursor = GameObject.Find("HandCursor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject == virtualCursor){
            if(cornerScript.UIisUp == true){
                cornerScript.UIisUp = false;
            }
        }
    }
}
