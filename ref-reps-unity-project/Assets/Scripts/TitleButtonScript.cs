using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonScript : MonoBehaviour
{
    bool cursorSelected;
    bool mouseDown;
    public bool otherSelected;

    public Transform SlideBar;

    public GameObject cursor;
    GameObject[] swipeButtons;

    public Transform CursorStart;

    float mouseDist;
    float mouseX;
    float doubleClickTimer;

    // Start is called before the first frame update
    void Start()
    {
        swipeButtons = GameObject.FindGameObjectsWithTag("swipeButton");
        cursor = GameObject.Find("HandCursor");
        otherSelected = false;
        ResetPos();
    }

    //Handle Mouse Events
    public void pointerDown(){
        mouseDown = true;
    }

    public void pointerUp(){
        mouseDown = false;
        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        //Set Cursor's Start Position to then end of the SlideButton
        float w = transform.parent.GetComponent<RectTransform>().rect.width;
        //Vector2 pos = new Vector2(Mathf.Clamp(transform.position.x, CursorStart.position.x ,CursorStart.position.x + w/2),CursorStart.position.y);
        //transform.position = pos;
        //Get the Mouse's Position
        mouseX = Input.mousePosition.x;

        //Test if any other buttons have already been activated
        int selectNum = 0;
        foreach(GameObject swipeButton in swipeButtons){
            if(swipeButton != this.gameObject){
                if(swipeButton.GetComponent<TitleButtonScript>().cursorSelected || swipeButton.GetComponent<TitleButtonScript>().cursorSelected){
                    selectNum++;
                }
            }
            if(selectNum > 0){
                otherSelected = true;
            }else{
                otherSelected = false;
            }
        }
        

        //Handle Button Selection
        if(otherSelected == false){


            //Mouse Action
            if(mouseDown){
                if(mouseX >= CursorStart.position.x){
                    transform.position = new Vector2(Mathf.Clamp(mouseX + mouseDist, 0f ,CursorStart.position.x + w/2), transform.position.y);
                }
            }
            mouseDist = (mouseX - transform.position.x) * -1;
            //


            //Kinect Cursor Action
            if(cursorSelected){
                if(cursor.transform.position.x >= CursorStart.position.x){
                    transform.position = new Vector2(cursor.transform.position.x, transform.position.y);
                }

                if(cursor.transform.position.x < CursorStart.position.x -250 || cursor.transform.position.y > CursorStart.transform.position.y + 250 || cursor.transform.position.y < CursorStart.transform.position.y - 250){
                    // cursorSelected = false;
                    ResetPos();
                }
            }
            //


            //Handle Cursor Select Animation
            GetComponent<Animator>().SetBool("isSelected", cursorSelected || mouseDown );
        }


        //Handle Button Execution
        float xMoved = transform.position.x;
        float barWidth = w;
        if(SlideBar.transform.position.x >= transform.parent.transform.position.x - 100){
            Execute();    
        }
        
    }



    //Kinect CursorSelection
    public void buttonExecute(){
        cursorSelected = !otherSelected;
    }
    
    //ButtonExecution
    void Execute(){
        this.gameObject.SendMessage("titleExecute", SendMessageOptions.DontRequireReceiver);
        
        ResetPos();
    }

    //ButtonDontExecute
    void DontExecute(){
        // mouseDown = false;
        // cursorSelected = false;
        ResetPos();
    }

    void ResetPos(){
        mouseDown = false;
        cursorSelected = false;
        transform.position = new Vector2(CursorStart.position.x, transform.position.y);
    }   
}
