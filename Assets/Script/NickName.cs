using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NickName : MonoBehaviour
{

    //PlayerNameManager

    [SerializeField] Text IDtext;
    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = IDtext.text;
    }
}