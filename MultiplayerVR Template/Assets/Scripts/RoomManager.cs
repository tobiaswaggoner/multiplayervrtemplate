using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    #region UI Callback Methods

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Photon Callback Methods

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"LOCAL player {PhotonNetwork.NickName} joined room {PhotonNetwork.CurrentRoom.Name}. Player count: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"NETWORKED player {newPlayer.NickName} joined room {PhotonNetwork.CurrentRoom.Name}. Player count: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    private void CreateAndJoinRoom()
    {
        var randomRoomName = "Room" + Random.Range(0, 10000);
        var roomOptions = new RoomOptions { MaxPlayers = 20};

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
}