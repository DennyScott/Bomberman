using UnityEngine;
using System.Collections;

public class ExplodeBomb : MonoBehaviour {

	public GameObject Player;
	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		Invoke ("Kaboom", 3);
	}

	void Kaboom(){
		Player.GetComponent<BombInventory> ().bombPlaced -= 1;
		MakeExplosion ();
		Destroy(gameObject);
	}

	void MakeExplosion(){
		Instantiate (Explosion, transform.position, transform.rotation);
		Instantiate (Explosion, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
		Instantiate (Explosion, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
		Instantiate (Explosion, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
		Instantiate (Explosion, new Vector3(transform.position.x, transform.position.y -1, transform.position.z), transform.rotation);
	}



}
