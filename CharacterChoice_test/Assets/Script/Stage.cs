using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stage : MonoBehaviour
{
    public GameObject RightButton;
    public GameObject LeftButton;
    public int value = 0;
    Quaternion turn;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        turn.eulerAngles = new Vector3(0, value, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * 5.0f);

    }

    public void R_Button()
    {
        Debug.Log("Right" + value);
        value += 90;

        turn.eulerAngles = new Vector3(0, value, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * 5.0f);
        //transform.rotation = Quaternion.Euler(new Vector3(0, value, 0));
    }

    public void L_Button()
    {
        Debug.Log("Left" + value);
        value -= 90;

        //transform.rotation = Quaternion.Euler(new Vector3(0, value, 0));
    }
}
