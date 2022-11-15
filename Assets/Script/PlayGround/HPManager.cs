using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPManager : MonoBehaviour
{
    public static int hp = 3;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    // Use this for initialization
    void Start()
    {
        life1.GetComponent<Image>().enabled = true;
        life2.GetComponent<Image>().enabled = true;
        life3.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 2:
                life3.GetComponent<Image>().enabled = false;
                break;
            case 1:
                life2.GetComponent<Image>().enabled = false;
                break;
            case 0:
                life1.GetComponent<Image>().enabled = false;

                Invoke("Respone", 2f);
                hp = 3;
                life1.GetComponent<Image>().enabled = true;
                life2.GetComponent<Image>().enabled = true;
                life3.GetComponent<Image>().enabled = true;
                //game over
                break;
        }
    }
}