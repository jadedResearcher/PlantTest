using UnityEngine;
using System.Collections;


/*
 *  each stem picks a sprite to represent itself
 * (that touches the parent sprite)
 * 
 *  it also keeps track of how old it is and at
 *  stemAge it decides if it should generate a stem
 *  leafAge it decides if it should generate a leaf
 *  and at flowerAge it decides if it should generate a flower.
 */
public class StemController : MonoBehaviour {
	private DNA dna; //private so you have to call a method to set it
	public GameObject stemPrefab;
	public Sprite[] possibleSprites = new Sprite[6];
	public int chosenSprite = -1;
	// Use this for initialization
	void Start () {

	}

	public void setDNA(DNA d){
		dna = d;
		chooseSprite ();
		StartCoroutine (grow() );
	}

	private IEnumerator grow(){
		yield return new WaitForSeconds (Random.Range(0,10));
			//Debug.Log ("Should I grow?");

		if(chosenSprite == -1){ //cant choose sprite without dna 
			Debug.LogError("how is my sprite still -1???");
		}
		if (dna.numStems < dna.maxStems) {
			growAStem ();
			StartCoroutine (grow ());
		} else {
			//Debug.Log ("Apparently not..."  + dna.numStems + " is more than: " + dna.maxStems);
		}

	}

	//if my parent is a stem, choose so my sprite hooks up with theirs
	//else, choose randomly.		

	private void chooseSprite(){
		//Debug.Log ("choosing sprite");
		StemController parentSC = transform.parent.GetComponent<StemController> ();
		if (parentSC == null) {
			chosenSprite = Random.Range (0, 5);
		} else {
			chooseSpriteBasedOnParentChoice(parentSC.chosenSprite);
		}
		loadChosenSprite ();

	}


	/*
		 * 0 01  top left and top right
		 * 1 02  top left and bottom left
		 * 2 03  top left and bottom right
		 * 3 12  top right and bottom left
		 * 4 13  top right and bottom right
		 * 5 23  bottom left and bottom right
		 */ 
	private void chooseSpriteBasedOnParentChoice(int parentChoice){
		if (parentChoice == 0) {
			if(Random.Range(0,100) > 50 ){
				chooseTopLeft();
			}else{
				chooseTopRight ();
			}
		}else if(parentChoice == 1){
			if(Random.Range(0,100) > 50 ){
				chooseTopLeft();
			}else{
				chooseBottomLeft ();
			}
		}else if(parentChoice == 2){
			if(Random.Range(0,100) > 50 ){
				chooseTopLeft();
			}else{
				chooseBottomRight ();
			}
		}else if(parentChoice == 3){
			if(Random.Range(0,100) > 50 ){
				chooseTopRight();
			}else{
				chooseBottomLeft ();
			}
		}else if(parentChoice == 4){
			if(Random.Range(0,100) > 50 ){
				chooseBottomRight();
			}else{
				chooseTopRight ();
			}
		}else if(parentChoice == 5){
			if(Random.Range(0,100) > 50 ){
				chooseBottomLeft();
			}else{
				chooseBottomRight ();
			}
		}
	}

	//meet up with my top left, so your bottom right
	private void chooseTopLeft(){
		// 0,1,2,
		transform.localPosition = new Vector2 (-0.4f, 0.4f);
		float rand = Random.Range (0, 100);
		if (rand < 33) {
			chosenSprite = 5;
		} else if (rand < 66) {
			chosenSprite = 4;
		} else {
			chosenSprite = 2;
		}
	}

	private void chooseTopRight(){
		//0,3,4
		transform.localPosition = new Vector2 (0.4f, 0.4f);
		float rand = Random.Range (0, 100);
		if (rand < 33) {
			chosenSprite = 1;
		} else if (rand < 66) {
			chosenSprite = 3;
		} else {
			chosenSprite = 5;
		}
	}

	private void chooseBottomLeft(){
		//1,3,5
		transform.localPosition = new Vector2 (-0.4f, -0.4f);
		float rand = Random.Range (0, 100);
		if (rand < 33) {
			chosenSprite = 0;
		} else if (rand < 66) {
			chosenSprite = 3;
		} else {
			chosenSprite = 4;
		}
	}

	private void chooseBottomRight(){
		//2,4,5
		transform.localPosition = new Vector2 (0.4f, -0.4f);
		float rand = Random.Range (0, 100);
		if (rand < 33) {
			chosenSprite = 0;
		} else if (rand < 66) {
			chosenSprite = 1;
		} else {
			chosenSprite = 2;
		}
	}

	private void loadChosenSprite(){
		SpriteRenderer r = GetComponent<SpriteRenderer> ();
		r.sprite = possibleSprites [chosenSprite];
	}

	private void growAStem(){

		GameObject stem = GameObject.Instantiate(stemPrefab);
		stem.transform.parent = this.transform;
		StemController sc = stem.GetComponent<StemController>();
		dna.numStems ++;
		sc.setDNA (dna);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
