using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEachScript : MonoBehaviour
{
    GameObject PointParent;
    int points;
    public bool pointsReached;

    // Start is called before the first frame update
    void Start()
    {
        PointParent = this.gameObject.transform.parent.gameObject;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if(points => 2){
        //     pointsReached = true;
        // }else{
        //     pointsReached = false;
        // }

        pointsReached = points >= 2 ? true:false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //nuitrack
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "LeftHand" || other.gameObject.name == "LeftElbow" || other.gameObject.name == "RightHand" || other.gameObject.name == "RightElbow")
            // PointParent.SendMessage("AddPoint");
            points++;
        }

        //kinect
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "HandLeft" || other.gameObject.name == "ElbowLeft" || other.gameObject.name == "HandRight" || other.gameObject.name == "ElbowRight")
            // PointParent.SendMessage("AddPoint");
            points++;
        }

        //kinectLegs
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "KneeLeft" || other.gameObject.name == "AnkleLeft" || other.gameObject.name == "KneeRight" || other.gameObject.name == "AnkleRight")
            // PointParent.SendMessage("AddPoint");
            points++;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        //nuitrack
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "LeftHand" || other.gameObject.name == "LeftElbow" || other.gameObject.name == "RightHand" || other.gameObject.name == "RightElbow")
            // PointParent.SendMessage("RemovePoint");
            points--;
        }

        //kinect
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "HandLeft" || other.gameObject.name == "ElbowLeft" || other.gameObject.name == "HandRight" || other.gameObject.name == "ElbowRight")
            // PointParent.SendMessage("RemovePoint");
            points--;
        }

        //kinectLegs
        if(other.gameObject.tag == "joint"){
            if(other.gameObject.name == "KneeLeft" || other.gameObject.name == "AnkleLeft" || other.gameObject.name == "KneeRight" || other.gameObject.name == "AnkleRight")
            // PointParent.SendMessage("AddPoint");
            points--;
        }
    }
}
