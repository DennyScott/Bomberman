using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Health> ().KillPlayer ();
		}

		if (col.gameObject.tag == "Block") {
			Destroy (col.gameObject);
			
		}

	}
}
