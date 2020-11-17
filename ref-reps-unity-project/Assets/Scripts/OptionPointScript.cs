using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPointScript : MonoBehaviour
{
    CallMake parentScript;
    public int optionNum;
    int currentPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        parentScript = this.transform.parent.parent.gameObject.GetComponent<CallMake>();
        Debug.Log(parentScript);
    }

    void Update(){
        if(currentPoints >= 4){
            parentScript.pointsMet = true;
        }else{
            parentScript.pointsMet = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //nuitrack
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "LeftHand" || other.gameObject.name == "LeftElbow" || other.gameObject.name == "RightHand" || other.gameObject.name == "RightElbow")
            currentPoints++;
        }

        //kinect
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "HandLeft" || other.gameObject.name == "ElbowLeft" || other.gameObject.name == "HandRight" || other.gameObject.name == "ElbowRight")
            currentPoints++;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        //nuitrack
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "LeftHand" || other.gameObject.name == "LeftElbow" || other.gameObject.name == "RightHand" || other.gameObject.name == "RightElbow")
            currentPoints--;
        }

        //kinect
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "HandLeft" || other.gameObject.name == "ElbowLeft" || other.gameObject.name == "HandRight" || other.gameObject.name == "ElbowRight")
            currentPoints--;
        }
    }
}