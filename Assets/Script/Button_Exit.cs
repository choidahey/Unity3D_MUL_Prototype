using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Exit : MonoBehaviour
{
    public void QuitButton()
    {
        Debug.Log("종료 눌려짐");
        Application.Quit();
    }
}