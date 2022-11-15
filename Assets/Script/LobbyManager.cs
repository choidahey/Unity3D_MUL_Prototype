using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Button loginBtn;
    public Text IDtext;
    public Text ConnectionStatus;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        loginBtn.interactable = false;
        ConnectionStatus.text = "Master Server에 연결 중입니다.";
    }


    public void Connect()
    {
        if (IDtext.text.Equals(""))
        {
            return;
        }
        else
        {
            PhotonNetwork.LocalPlayer.NickName = IDtext.text;
            loginBtn.interactable = false;
            if (PhotonNetwork.IsConnected)
            {
                ConnectionStatus.text = "입장 확인 중...";
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                ConnectionStatus.text = "Offline : 네트워크 연결 실패, 네트워크를 확인해주세요.\n다시 연결 중...";
                PhotonNetwork.ConnectUsingSettings();
            }

        }

    }
    public override void OnConnectedToMaster()
    {
        loginBtn.interactable = true;
        ConnectionStatus.text = "정보를 입력해 주세요.";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        loginBtn.interactable = false;
        ConnectionStatus.text = "Offline : 네트워크 연결 실패, 네트워크를 확인해주세요.\n다시 연결 중...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //ConnectionStatus.text = "No empty room. creating new room...";
        ConnectionStatus.text = "입장 확인 중입니다.";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }
    public override void OnJoinedRoom()
    {
        ConnectionStatus.text = "입장 완료 !";
        PhotonNetwork.LoadLevel("Main");
    }
}