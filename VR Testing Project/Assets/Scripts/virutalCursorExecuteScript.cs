using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virutalCursorExecuteScript : MonoBehaviour
{
    private GameObject virtualCursor;
    CursorInteractionScript ciScript;
    private GameObject cursorProgress;
    public bool over;
    public float exectuteNum = 120;
    
    // Start is called before the first frame update
    void Start()
    {
        virtualCursor = GameObject.Find("HandCursor");
        ciScript = virtualCursor.GetComponent<CursorInteractionScript>();
        // cursorProgress = virtualCursor.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(over == true && ciScript.press == true){
            this.gameObject.SendMessage("buttonExecute", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == virtualCursor){
            over = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject == virtualCursor){
            over = false;
        }
    }
}
