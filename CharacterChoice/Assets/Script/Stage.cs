using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stage : MonoBehaviour
{
    Object RightButton;
    Object LeftButton;
    int value = 0;
    float turn = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RightButton)
        {
            Debug.Log("Right");
            value += 90;
        }

        if (LeftButton)
        {
            Debug.Log("Left");
            value -= 90;
        }

        turn.eulerAngles = new Vector3(0, value, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion)turn, Time.deltaTime * 5.0f);
    }
}
