using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBarScript : MonoBehaviour
{
    public GameObject barGhosts;
    public bool isClick;
    public bool isOver;
    // Start is called before the first frame update
    void Start()
    {
        barGhosts.SetActive(false);
        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        barGhosts.SetActive(isClick);

        if(isClick){
            if(Input.GetMouseButton(0)){
            Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3);
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            this.transform.position = new Vector3(mouse.x, mouse.y, 0);
            }
        }
    }

    void OnMouseOver(){
        isOver = true;
    }

    void OnMouseDown(){
        if(isOver == true){
            isClick = true;
        }
    }

    void OnMouseUp(){
        isClick = false;
    }
}
