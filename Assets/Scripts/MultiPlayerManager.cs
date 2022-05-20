using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class MultiPlayerManager : MonoBehaviourPunCallbacks {
    public static MultiPlayerManager instance;

    private void Awake() {
        if (instance==null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance!=this) {
            Destroy(gameObject);
        }
    }

    private string playerPrefabName, userName;

    public void LoadPlayer(string aPlayerPrefabName, string aUserName) {
        playerPrefabName = aPlayerPrefabName;
        userName = aUserName;

        // connect to server
        ConnectToServer();


        // StartCoroutine(SpawnPlayerCoroutine(aPlayerPrefabName, aUserName));
        // SceneLoader.instance.LoadSceneAdditive("MultiplayerScene",
        //     delegate {
        //         SceneLoader.instance.UnloadScene("Intro");
        //     }
        // ); 
        
    }

    private void ConnectToServer() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to server");

        // connect to a chat room
        PhotonNetwork.JoinRoom("MatchRoom");

    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined Room");
        // load level and instantiate player
        StartCoroutine(SpawnPlayerOnMultiuplayerCoroutine());
        PhotonNetwork.LoadLevel("MultiplayerScene");
    }

 

    public override void OnJoinRoomFailed(short returnCode, string message) {
        Debug.Log("Joining room failed "+returnCode+" "+message);

        if (returnCode==32758) {
            PhotonNetwork.CreateRoom("MatchRoom");
        }
    }

    
    private IEnumerator SpawnPlayerCoroutine(string aPlayerPrefabName, string aUserName) {
        while(PlayerSpawner.instance==null) {
            yield return null;
        }
        PlayerSpawner.instance.SpawnPlayer(aPlayerPrefabName, aUserName);
    }

    private IEnumerator SpawnPlayerOnMultiuplayerCoroutine() {
        while(PlayerSpawner.instance==null) {
            yield return null;
        }

        GameObject player = PhotonNetwork.Instantiate(playerPrefabName, PlayerSpawner.instance.transform.position, PlayerSpawner.instance.transform.rotation);
        player.GetComponent<HUDManagerController>().hudManager.SetCharacterName(userName);
        player.GetComponent<PlayerController>().UpdateUserNameOnOtherPlayers(userName);
    }
}
