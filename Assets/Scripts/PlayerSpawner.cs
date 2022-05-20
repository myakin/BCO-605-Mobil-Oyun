using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif

public class PlayerSpawner : MonoBehaviour {
    public static PlayerSpawner instance;

    private void Awake() {
        instance = this;
    }
    
    public void SpawnPlayer(string playerPrefabName, string aUserName) {
        GameObject player = Instantiate(Resources.Load(playerPrefabName) as GameObject, transform.position, transform.rotation);
        player.GetComponent<HUDManagerController>().hudManager.SetCharacterName(aUserName);
    }

    public void SpawnPlayerOnMultiplayerMode(string playerPrefabName, string aUserName) {
        // GameObject player = Instantiate(Resources.Load(playerPrefabName) as GameObject, transform.position, transform.rotation);
        // player.GetComponent<HUDManagerController>().hudManager.SetCharacterName(aUserName);
        

    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerSpawner))]
public class PlayerSpawnerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        PlayerSpawner script = (PlayerSpawner) target;

        if (GUILayout.Button("Spawn Player")) {
            script.SpawnPlayer("ExoRed", "Editor");
        }

    }
}
#endif

