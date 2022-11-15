using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpdateDelete : MonoBehaviour
{
    [SerializeField] GameObject obj;

    public void DestroyObj()
    {   
        Destroy(obj);
    }
}

