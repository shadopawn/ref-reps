using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornerUIHubScript : MonoBehaviour
{
    private GameObject virtualCursor;
    // private GameObject cursorProgress;
    private Image spriteRen;
    private GameObject UINodeHub;
    private float enterNum = 0;
    public bool UIisUp = false;
    Animator activateAnimationOne;
    Animator activateAnimationTwo;

    // Start is called before the first frame update
    void Start()
    {
        virtualCursor = GameObject.Find("HandCursor");
        Debug.Log(virtualCursor.name);
        // cursorProgress = virtualCursor.transform.GetChild(0).gameObject;
        UINodeHub = this.gameObject.transform.GetChild(0).gameObject;
        // UINodeHub.SetActive(false);
        spriteRen = GetComponent<Image>();
        activateAnimationOne = transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Animator>();
        activateAnimationTwo = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(virtualCursor.transform.position, this.gameObject.transform.position);

        if(dist > .5f){
            spriteRen.color = new Color(1,1,1, 1/dist);
        }else{
            spriteRen.color = new Color(1,1,1,1);
        }

        // UINodeHub.SetActive(UIisUp);

        if(UIisUp == true){
            // UINodeHub.SetActive(true);
            activateAnimationOne.SetBool("isActive", true);
            activateAnimationTwo.SetBool("isActive", true);
        }else{
            // UINodeHub.SetActive(false);
            activateAnimationOne.SetBool("isActive", false);
            activateAnimationTwo.SetBool("isActive", false);
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == virtualCursor){
            UIisUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        // if(other.gameObject == virtualCursor){
        //     enterNum = 0;
        //     cursorProgress.transform.localScale = new Vector2(0,0);
        // }
        // UIisUp = false;
    }
}
