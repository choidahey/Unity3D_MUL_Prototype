using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lib_OnClick : MonoBehaviour
{
    GameObject ExitButton;

    public void OnClick_ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
