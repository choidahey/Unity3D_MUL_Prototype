using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isConnect = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        StartCoroutine(CreatePlayer());
    }

    IEnumerator CreatePlayer()
    {
        yield return new WaitUntil(() => isConnect);
        GameObject playerTemp = PhotonNetwork.Instantiate("Player", Vector3.one, Quaternion.identity, 0);
    }

}
