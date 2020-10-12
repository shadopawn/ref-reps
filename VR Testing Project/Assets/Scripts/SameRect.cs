using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SameRect : MonoBehaviour
{
    public GameObject target;

    RectTransform bodyTransform;
    // Start is called before the first frame update
    void Start()
    {
        bodyTransform = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        bodyTransform.gameObject.transform.position = target.transform.position;
        bodyTransform.sizeDelta = new Vector2(target.GetComponent<RectTransform>().rect.width, target.GetComponent<RectTransform>().rect.height);
    }
}
