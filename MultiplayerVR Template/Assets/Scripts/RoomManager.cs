using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

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

        if(PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiPlayerVrConstants.MAP_TYPE_KEY, out var mapType))
        {
            Debug.Log($"Joined room with map type { (string) mapType}");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"NETWORKED player {newPlayer.NickName} joined room {PhotonNetwork.CurrentRoom.Name}. Player count: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    private void CreateAndJoinRoom()
    {
        var randomRoomName = "Room" + Random.Range(0, 10000);
        var roomPropsInLobby = new [] {  MultiPlayerVrConstants.MAP_TYPE_KEY };
        var customRoomProps = new Hashtable { {MultiPlayerVrConstants.MAP_TYPE_KEY, MultiPlayerVrConstants.MAP_TYPE_VALUE_SCHOOL } };
        var roomOptions = new RoomOptions
        {
            MaxPlayers = 20,
            CustomRoomPropertiesForLobby = roomPropsInLobby,
            CustomRoomProperties = customRoomProps,
        };

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion
}