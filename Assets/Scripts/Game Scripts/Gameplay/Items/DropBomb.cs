using UnityEngine;
using System.Collections;

public class DropBomb : MonoBehaviour {

	public GameObject bomb;

	private BombInventory _bombInventory;

	void Start(){
		_bombInventory = GetComponent<BombInventory> ();
	}

	// Update is called once per frame
	void Update() {
		if (_bombInventory.bombCount > _bombInventory.bombPlaced){
			if (Input.GetButtonUp("Fire1")) {
				GameObject clone = Instantiate(bomb, transform.position, transform.rotation) as GameObject;
				_bombInventory.bombPlaced += 1;
				var explodeBomb = clone.GetComponent<ExplodeBomb>();
				explodeBomb.Player = gameObject;
				explodeBomb.Radius = _bombInventory.Radius;

			}
			
		}
	
	}
	
}
