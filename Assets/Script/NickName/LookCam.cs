using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cam;

    void Update()
    {
        transform.rotation = Cam.transform.rotation;
    }
}
