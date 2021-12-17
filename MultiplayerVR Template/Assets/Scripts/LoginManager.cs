using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoginManager : MonoBehaviourPunCallbacks
{
    #region Unit Methods

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region UI Callback Methods

    public void LoginAnonymously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    #endregion
    
    
    #region Photon Callback Methods

    public override void OnConnected()
    {
        Debug.Log("On Connected is called. The server is available");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
    }

    #endregion
}
