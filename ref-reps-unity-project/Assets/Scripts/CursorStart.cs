using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CursorStart : MonoBehaviour
{
    Transform cursorStart;
    public Transform cursorNode;

    // Start is called before the first frame update
    void Start()
    {
        cursorStart = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //cursorStart.position = new Vector2(transform.parent.transform.position.x - transform.parent.GetComponent<RectTransform>().rect.width/2, transform.parent.transform.position.y);
        //cursorNode.position = cursorStart.position;
    }
}
