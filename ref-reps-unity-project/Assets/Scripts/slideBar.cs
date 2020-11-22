using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class slideBar : MonoBehaviour
{
    RectTransform bodyTransform;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        bodyTransform = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        bodyTransform.sizeDelta = new Vector2(transform.parent.gameObject.GetComponent<RectTransform>().rect.width, transform.parent.gameObject.GetComponent<RectTransform>().rect.height);
    }
}
