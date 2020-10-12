using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainScript : MonoBehaviour
{
    public void buttonExecute(){
        SceneManager.LoadScene("VideoSelectScreen");
    }
}
