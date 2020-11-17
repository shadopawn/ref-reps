using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoSelectExitButton : MonoBehaviour
{
    private GameObject virtualCursor;
    private Image spriteRen;

    // Start is called before the first frame update
    void Start()
    {
        virtualCursor = GameObject.Find("HandCursor");
        spriteRen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(virtualCursor.transform.position, this.gameObject.transform.position);
        Debug.Log(dist);
        if(dist > .5f){
            spriteRen.color = new Color(1,1,1, 1 - (dist * .0055f));
        }else{
            spriteRen.color = new Color(1,1,1,1);
        }
    }

    public void buttonExecute(){
        SceneManager.LoadScene("TitleScreen");
    }
}
