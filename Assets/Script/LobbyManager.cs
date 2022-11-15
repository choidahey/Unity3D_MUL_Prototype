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
        ConnectionStatus.text = "Master Server�� ���� ���Դϴ�.";
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
                ConnectionStatus.text = "���� Ȯ�� ��...";
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                ConnectionStatus.text = "Offline : ��Ʈ��ũ ���� ����, ��Ʈ��ũ�� Ȯ�����ּ���.\n�ٽ� ���� ��...";
                PhotonNetwork.ConnectUsingSettings();
            }

        }

    }
    public override void OnConnectedToMaster()
    {
        loginBtn.interactable = true;
        ConnectionStatus.text = "������ �Է��� �ּ���.";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        loginBtn.interactable = false;
        ConnectionStatus.text = "Offline : ��Ʈ��ũ ���� ����, ��Ʈ��ũ�� Ȯ�����ּ���.\n�ٽ� ���� ��...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //ConnectionStatus.text = "No empty room. creating new room...";
        ConnectionStatus.text = "���� Ȯ�� ���Դϴ�.";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }
    public override void OnJoinedRoom()
    {
        ConnectionStatus.text = "���� �Ϸ� !";
        PhotonNetwork.LoadLevel("Main");
    }
}