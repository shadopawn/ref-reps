using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LessonbarIncrementer : MonoBehaviour
{
    private float value = 80.0F;

    GameObject GetButtonRect()
    {
        return GameObject.Find("LessonPackButtonList");
    }

    public void Increment()
    {
        GameObject rect = GetButtonRect();
        var pos = rect.transform.position;
        pos.y += value;
        rect.transform.position = pos;
    }

    public void Decrement()
    {
        GameObject rect = GetButtonRect();
        var pos = rect.transform.position;
        pos.y -= value;
        rect.transform.position = pos;
    }
}