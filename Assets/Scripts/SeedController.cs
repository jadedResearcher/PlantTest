using UnityEngine;
using System.Collections;
/*
 * a seed contains all the DNA for a new plant.  
 * 
 * two identical seeds should generate MOSTLY identical plants. 
 * 
 * a seed is directly responsible for growing the first stem and giving it it's DNA.
 * 
 * a seed begins to grow in response to an impulse from the pot.
 * 
 * a stem is responsible for using it's DNA to decide what it looks like
 * as well as growing leaves and flowers.
 */ 
public class SeedController : MonoBehaviour {
	public GameObject stemPrefab;
	public DNA dna;
	public bool growing = false;
	// Use this for initialization
	void Start () {
	
	}

	private void growAStem(){
		//Debug.Log ("My DNA is: " + dna);
		growing = false;
		GameObject stem = GameObject.Instantiate(stemPrefab);
		stem.transform.parent = this.transform;
		StemController sc = stem.GetComponent<StemController>();
		stem.transform.localPosition = new Vector2 (0, 0);
		dna.numStems ++;
		sc.setDNA (dna);//also starts it growing
	}
	
	// Update is called once per frame
	void Update () {
		if (growing == true) {
			growAStem();
		}
	}
}
