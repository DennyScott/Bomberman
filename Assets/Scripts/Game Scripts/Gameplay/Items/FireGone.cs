using UnityEngine;
using System.Collections;

public class FireGone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("Fire", 1);
	}

	void Fire(){
		Destroy (gameObject);
	}



}
