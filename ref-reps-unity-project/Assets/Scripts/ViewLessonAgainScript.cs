using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewLessonAgainScript : MonoBehaviour
{
    public void buttonExecute(){
        SceneManager.LoadScene("MainScene");
    }
}
