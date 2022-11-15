using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
