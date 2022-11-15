using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnoff : MonoBehaviour
{
    public GameObject GameObject;

    public void OnClickOnButton()
    {
        GameObject.SetActive(true);
    }
    public void OnClickOffButton()
    {
        GameObject.SetActive(false);
    }
    public void OnClickExitButton()
    {
        Application.Quit();
    }

}
