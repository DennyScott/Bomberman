using UnityEngine;
using System.Collections;

public class ExplodeBomb : MonoBehaviour {

	public GameObject Player;
	public GameObject Explosion;
	public int Radius;

	// Use this for initialization
	void Start () {
		Invoke ("Kaboom", 3);
	}

	void Kaboom(){
		Player.GetComponent<BombInventory> ().bombPlaced -= 1;
		MakeExplosion ();
		Destroy(gameObject);
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			transform.GetComponent<Collider>().isTrigger = false;
		}
	}

	void MakeExplosion(){
		Instantiate (Explosion, transform.position, transform.rotation);
		MakeEastBombs();
		MakeWestBombs();
		MakeNorthBombs();
		MakeSouthBombs();
	}

	void MakeEastBombs() {
		for (int i = 1; i <= Radius; i++) {
			Instantiate(Explosion, new Vector3(transform.position.x + i, transform.position.y, transform.position.z), transform.rotation);
		}
	}

	void MakeWestBombs() {
		for (int i = 1; i <= Radius; i++) {
			Instantiate(Explosion, new Vector3(transform.position.x -i, transform.position.y, transform.position.z), transform.rotation);
		}
	}

	void MakeNorthBombs() {
		for (int i = 1; i <= Radius; i++) {
			Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y + i, transform.position.z), transform.rotation);
		}
	}

	void MakeSouthBombs() {
		for (int i = 1; i <= Radius; i++) {
			Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y - i, transform.position.z), transform.rotation);
		}
	}

}
