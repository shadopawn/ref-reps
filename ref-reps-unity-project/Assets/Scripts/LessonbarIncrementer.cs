using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LessonbarIncrementer : MonoBehaviour
{
    private float value = 174.0F;
    public GameObject view;

    public void Increment()
    {
        var pos = view.transform.position;
        pos.y += value;
        view.transform.position = pos;
    }

    public void Decrement()
    {
        var pos = view.transform.position;
        pos.y -= value;
        view.transform.position = pos;
    }
}