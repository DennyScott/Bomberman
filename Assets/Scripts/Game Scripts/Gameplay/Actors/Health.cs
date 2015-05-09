using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public void KillPlayer(){
		transform.position = new Vector2 (0,0);
	}

}
