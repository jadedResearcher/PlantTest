using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Keeps track of seed inventory and knows which seed was clicked on. 
 */
public class SeedBarController : MonoBehaviour {
	public GameObject seedPrefab;
	List<GameObject> seeds;
	GameObject selectedSeed;
	public float initialSeedPosition = 5;
	float lastSeedY = 5;
	float seedBuffer = 1;
	// Use this for initialization
	void Start () {
		lastSeedY = initialSeedPosition;
		seeds = new List<GameObject> ();
		initRandomSeeds (5);
		selectSeed (seeds [0]);

	}

	public GameObject giveSelectedSeed(GameObject newParent){
		GameObject ret = selectedSeed;
		selectedSeed.transform.parent = newParent.transform;
		seeds.Remove (selectedSeed);
		selectedSeed.transform.localPosition = new Vector2(0,0);
		rePositionSeeds ();
		selectSeed (seeds [0]);
		return ret;

	}

	public void rePositionSeeds(){
		lastSeedY = initialSeedPosition;
		foreach (GameObject s in seeds) {
			lastSeedY = lastSeedY - seedBuffer;
			Vector2 position = new Vector2 (0, lastSeedY);
			s.transform.localPosition = position;
		}
	}

	public void selectSeed(GameObject seed){
		Debug.Log ("Selecting seed: " + seed);
		selectedSeed = seed;
		foreach (GameObject s in seeds) {
			SpriteRenderer sr = s.GetComponent<SpriteRenderer> ();
			if(selectedSeed.Equals(s)){
				//Debug.Log("setting color to selected");

			sr.color = Color.yellow;
			}else{
				//Debug.Log("setting color to unselected");
				sr.color = Color.white;
			}
		}

	}

	private void initRandomSeeds(int numSeeds){
		for (int i = 0; i<numSeeds; i++) {
			GameObject seed = GameObject.Instantiate(seedPrefab);
			SeedController sc = seed.GetComponent<SeedController>();
			sc.dna = DNA.randomDNA();
			addSeed(seed);
		}
	}

	public void addSeed(GameObject seed){
		seed.transform.parent = this.transform;
		seeds.Add (seed);
		lastSeedY = lastSeedY - seedBuffer;
		Vector2 position = new Vector2 (0, lastSeedY);
		seed.transform.localPosition = position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
