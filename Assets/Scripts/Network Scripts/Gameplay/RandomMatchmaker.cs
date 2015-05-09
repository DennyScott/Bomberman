using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

    public static System.Action<GameObject> JoinedRoom;
 
    // Use this for initialization
    void Start() {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    void OnGUI() {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby() {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed() {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom() {
        var player = PhotonNetwork.Instantiate("Player", Vector3.zero,new Quaternion(90, 0, 0, 0), 0);
        player.GetComponent<Movement>().enabled = true;
        player.GetComponentInChildren<DropBomb>().enabled = true;
        player.GetComponentInChildren<BombInventory>().enabled = true;

        if (JoinedRoom != null) {
            JoinedRoom(player);
        }
    }
}