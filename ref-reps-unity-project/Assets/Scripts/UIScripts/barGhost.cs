using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barGhost : MonoBehaviour
{
    UILayoutManager UILayoutManager;
    UIBarScript UIBarScript;

    public bool isOver;
    public int myState;
    // Start is called before the first frame update
    void Start()
    {
        UILayoutManager = GameObject.Find("UILayoutManager").GetComponent<UILayoutManager>();
        UIBarScript = GameObject.Find("UIBAR").GetComponent<UIBarScript>();
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp(){
        if(isOver){
            UILayoutManager.currentState = myState;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "UIBAR"){
            Debug.Log("ENTER");
            isOver = true;
            UILayoutManager.currentState = myState;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name == "UIBAR"){
            isOver = false;
            UILayoutManager.currentState = myState;
        }
    }


}
