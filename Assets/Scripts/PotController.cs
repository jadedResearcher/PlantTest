using UnityEngine;
using System.Collections;

/*
 *   if a pot is clicked on and empty, it adds the current seed to it. 
 * 
 *   pots are responsible for growing their seeds.
 * 
 * 	 seeds are responsible for rendering their stems (procedural graphics?)
 * 	 and then deciding where to put leaf and flower sprites on those stems
 *   and what color and size and rotation they should be
 * 
 * 	 leafs should grow first, while stem still growing. flower should grow after
 *   stem is done. 
 * 
 *   seed color should be based on flower color?
 */ 
public class PotController : MonoBehaviour {
	public GameObject mySeed = null;
	public SeedBarController seedBarController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void addSeed(){
		mySeed = seedBarController.giveSelectedSeed (this.gameObject);
		SeedController sc = mySeed.GetComponent<SeedController> ();
		sc.growing = true;
	}

	void OnMouseDown(){
		if (mySeed == null) {
			addSeed ();
		}
	}
}
