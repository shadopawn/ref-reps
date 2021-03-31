using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorNode : MonoBehaviour
{
    public GameObject parentButton;
    
    // Start is called before the first frame update
    public void titleExecute()
    {
        parentButton.GetComponent<LessonSelectScript>()?.titleExecute();
    }
}
