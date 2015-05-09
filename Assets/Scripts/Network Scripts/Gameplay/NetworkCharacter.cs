using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour {

	private Vector3 _correctPlayerPos;
    private Quaternion _correctPlayerRot;
 
	void Start() {
		if(photonView.isMine) {
			
		}
	}
    // Update is called once per frame
    void Update() {
        UpdateOtherPlayers();
    }

    void UpdateOtherPlayers() {
        if (photonView.isMine) {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, _correctPlayerPos, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation, _correctPlayerRot, 0.1f);
    }


	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        } else {
            // Network player, receive data
            _correctPlayerPos = (Vector3) stream.ReceiveNext();
            _correctPlayerRot = (Quaternion) stream.ReceiveNext();
        }
	}
}
